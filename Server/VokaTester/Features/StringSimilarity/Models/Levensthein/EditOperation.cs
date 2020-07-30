namespace VokaTester.Features.StringSimilarity.Models.Levensthein
{
    using System;

    public struct EditOperation
    {
        public EditOperation(char value, EditOperationKind operation)
        {
            Value = value;
            Operation = operation;
        }

        public EditOperationKind Operation { get; }

        public string OperationStr => Enum.GetName(typeof(EditOperationKind), this.Operation);

        public char Value { get; }
    }
}
