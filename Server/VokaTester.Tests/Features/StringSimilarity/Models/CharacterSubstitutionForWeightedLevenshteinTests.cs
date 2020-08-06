namespace VokaTester.Tests.Features.StringSimilarity.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using VokaTester.Features.StringSimilarity.Dto.WeightedLevenshtein;

    public class CharacterSubstitutionForWeightedLevenshteinTests
    {
        private readonly CharacterSubstitution characterSubstitution = new CharacterSubstitution(0.5);

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FullCosts()
        {
            Assert.AreEqual(1.0, this.characterSubstitution.Cost('a', 'é'));
            Assert.AreEqual(1.0, this.characterSubstitution.Cost('û', 'x'));
        }


        [Test]
        public void CostsA()
        {
            Assert.AreEqual(0.5, this.characterSubstitution.Cost('a', 'à'));
            Assert.AreEqual(1.0, this.characterSubstitution.Cost('a', 'è'));
        }

        [Test]
        public void CostsC()
        {
            Assert.AreEqual(0.5, this.characterSubstitution.Cost('c', 'ç'));
            Assert.AreEqual(1.0, this.characterSubstitution.Cost('c', 'è'));
        }

        [Test]
        public void CostsE()
        {
            Assert.AreEqual(0.5, this.characterSubstitution.Cost('é', 'è'));
            Assert.AreEqual(1.0, this.characterSubstitution.Cost('é', 'à'));
        }


        [Test]
        public void CostsI()
        {
            Assert.AreEqual(0.5, this.characterSubstitution.Cost('i', 'î'));
            Assert.AreEqual(1.0, this.characterSubstitution.Cost('i', 'ê'));
        }

        [Test]
        public void CostsU()
        {
            Assert.AreEqual(0.5, this.characterSubstitution.Cost('u', 'û'));
            Assert.AreEqual(1.0, this.characterSubstitution.Cost('û', 'ê'));
        }

        [Test]
        public void TestPermutations()
        {
            List<char[]> res1 = this.characterSubstitution.GetPermutations(new char[] { 'a', 'b' }).ToList();
            Assert.AreEqual(2, res1.Count());

            List<char[]> res2 = this.characterSubstitution.GetPermutations(new char[] { 'c', 'd', 'e' }).ToList();
            Assert.AreEqual(6, res2.Count());

            List<char[]> res3 = this.characterSubstitution.GetPermutations(new char[] { 'f', 'g', 'h', 'i' }).ToList();
            Assert.AreEqual(12, res3.Count());

            List<char[]> res4 = this.characterSubstitution.GetPermutations(new char[] { 'j', 'k', 'l', 'm', 'n' }).ToList();
            Assert.AreEqual(20, res4.Count());
        }
    }
}
