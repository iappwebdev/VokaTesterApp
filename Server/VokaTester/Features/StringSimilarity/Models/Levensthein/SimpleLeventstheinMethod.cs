namespace VokaTester.Features.StringSimilarity.Models.Levensthein
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class SimpleLevenstheinMethod
    {
        [Flags]
        public enum Operations
        {
            None,
            Insert = 1,
            Remove = 2,
            Edit = 4,
            Copy = 8
        }

        public double CopyCost { get; set; } = 1;

        public double EditCost { get; set; } = 2;

        public double InsertCost { get; set; } = 1;

        public double RemoveCost { get; set; } = 1;

        public double WhiteSpacePreference { get; set; } = 1;

        public string Source { get; set; }

        public string Target { get; set; }

        public List<EditOperation> GetEditSequence()
        {
            return ProcessEditSequence(
                this.Source, 
                this.Target, 
                this.InsertCost, 
                this.RemoveCost, 
                this.EditCost, 
                this.CopyCost, 
                this.WhiteSpacePreference);
        }

        private static List<EditOperation> ProcessEditSequence(
            string source,
            string target,
            double insertCost,
            double removeCost,
            double editCost,
            double copyCost,
            double whiteSpacePreference)
        {
            // Forward: building score matrix

            // Best operation (among insert, edit/copy, remove) to perform
            Operations[,] nextOperation = new Operations[source.Length + 1, target.Length + 1];

            // Minimum cost so far
            double[,] pathCost = new double[source.Length + 1, target.Length + 1];

            // Edge: all removes
            for (int i = 1; i <= source.Length; i++)
            {
                nextOperation[i, 0] = Operations.Remove;
                pathCost[i, 0] = removeCost * i;
            }

            // Edge: all inserts
            for (int i = 1; i <= target.Length; i++)
            {
                nextOperation[0, i] = Operations.Insert;
                pathCost[0, i] = insertCost * i;
            }

            // fill the cost and operation table
            for (int i = 1; i <= source.Length; i++)
            {
                char sourceCharacter = source[i - 1];
                for (int j = 1; j <= target.Length; j++)
                {
                    // here we choose the operation with the least cost
                    char targetCharacter = target[j - 1];
                    bool copy = sourceCharacter == targetCharacter;
                    double insert = pathCost[i, j - 1] + insertCost;
                    double remove = pathCost[i - 1, j] + removeCost;
                    double edit = pathCost[i - 1, j - 1] + (copy ? copyCost : editCost);

                    if (char.IsWhiteSpace(sourceCharacter) && char.IsWhiteSpace(targetCharacter) && !copy)
                    {
                        insert -= whiteSpacePreference;
                        remove -= whiteSpacePreference;
                        edit -= whiteSpacePreference;
                    }

                    double min = Math.Min(Math.Min(insert, remove), edit);

                    if (min == insert)
                    {
                        nextOperation[i, j] |= Operations.Insert;
                    }

                    if (min == remove)
                    {
                        nextOperation[i, j] |= Operations.Remove;
                    }

                    if (min == edit)
                    {
                        nextOperation[i, j] |= copy ? Operations.Copy : Operations.Edit;
                    }

                    pathCost[i, j] = min;
                }
            }

            // Backward: knowing costs and operations let's building edit sequence (in reverse order, from end to start)
            List<EditOperation> result = new List<EditOperation>(source.Length + target.Length);

            Operations previousOperation = Operations.None;
            for (int x = target.Length, y = source.Length; (x > 0) || (y > 0);)
            {
                EditOperationKind op = 
                    GetNextOperation(
                        nextOperation[y, x],
                        insertCost, 
                        removeCost, 
                        editCost, 
                        copyCost, 
                        ref previousOperation);

                switch (op)
                {
                    case EditOperationKind.Insert:
                        x--;
                        result.Add(new EditOperation(target[x], op));
                        break;

                    case EditOperationKind.Remove:
                        y--;
                        result.Add(new EditOperation(source[y], op));
                        break;

                    default: // EditOperationKind.Edit, EditOperationKind.Copy
                        x--;
                        y--;
                        result.Add(new EditOperation(target[x], op));
                        Debug.Assert((op == EditOperationKind.Edit) || (op == EditOperationKind.Copy));
                        break;
                }
            }

            result.Reverse();
            return result;
        }

        private static EditOperationKind GetNextOperation(
            Operations nextOperation,
            double insertCost,
            double removeCost,
            double editCost,
            double copyCost,
            ref Operations previousOperation)
        {
            if ((previousOperation != Operations.None) && ((nextOperation & previousOperation) == previousOperation))
            {
                return previousOperation switch
                {
                    Operations.Insert => EditOperationKind.Insert,
                    Operations.Remove => EditOperationKind.Remove,
                    Operations.Edit => EditOperationKind.Edit,
                    Operations.Copy => EditOperationKind.Copy,
                    _ => throw new ArgumentOutOfRangeException(nameof(previousOperation)),
                };
            }

            double min = double.MaxValue;
            EditOperationKind operation = EditOperationKind.Edit;

            if ((nextOperation & Operations.Copy) != Operations.None)
            {
                min = copyCost;
                operation = EditOperationKind.Copy;
                previousOperation = Operations.Copy;
            }
            else if ((nextOperation & Operations.Edit) != Operations.None)
            {
                min = editCost;
                previousOperation = Operations.Edit;
            }

            if ((min >= removeCost) && ((nextOperation & Operations.Remove) != Operations.None))
            {
                min = removeCost;
                operation = EditOperationKind.Remove;
                previousOperation = Operations.Remove;
            }

            if ((min >= insertCost) && ((nextOperation & Operations.Insert) != Operations.None))
            {
                operation = EditOperationKind.Insert;
                previousOperation = Operations.Insert;
            }

            return operation;
        }
    }
}
