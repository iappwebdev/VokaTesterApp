namespace VokaTester.Features.StringSimilarity.Models.WeightedLevenshtein
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class CharacterSubstitutionBase : ICharacterSubstitution
    {
        private readonly double costs;
        private readonly List<char[]> variationsLists;
        private readonly List<List<char[]>> combinationsLists = new List<List<char[]>>();

        public CharacterSubstitutionBase(
            List<char[]> variationsLists,
            double costs)
        {
            if (costs < 0 || costs > 1)
            {
                throw new ArgumentException($"{nameof(costs)} should be between 0.0 and 1.0.");
            }

            if (!variationsLists.Any())
            {
                throw new ArgumentException($"{nameof(variationsLists)} contains no elements.");
            }

            this.costs = costs;
            this.variationsLists = variationsLists;

            foreach (char[] variations in variationsLists)
            {
                this.combinationsLists.Add(this.GetPermutations(variations).ToList());
            }
        }

        protected CharacterSubstitutionBase(char[] variations, double costs)
        {
            this.costs = costs;
            this.combinationsLists.Add(this.GetPermutations(variations).ToList());
        }

        public double Cost(char c1, char c2)
        {
            foreach (List<char[]> combinations in this.combinationsLists)
            {
                foreach (char[] comb in combinations)
                {
                    if (c1 == comb[0] && c2 == comb[1])
                    {
                        return this.costs;
                    }
                }
            }

            return 1.0;
        }

        public IEnumerable<T[]> GetPermutations<T>(IEnumerable<T> list, int length = 2)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            IEnumerable<T[]> result =
                GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }).ToArray<T>());

            return result;
        }
    }
}
