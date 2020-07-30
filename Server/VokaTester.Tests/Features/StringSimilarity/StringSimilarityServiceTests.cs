namespace VokaTester.Tests.Features.StringSimilarity
{
    using NUnit.Framework;
    using VokaTester.Features.StringSimilarity;
    using VokaTester.Features.StringSimilarity.Models;

    public class StringSimilarityServiceTests
    {
        private readonly StringSimilarityService stringSimilarityService = new StringSimilarityService();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AreEqual1()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("abcdef", "abcdef");
            Assert.IsTrue(res.IsAnswerEqual);
            Assert.IsTrue(res.IsAnswerSimilar);
            Assert.IsTrue(res.IsAnswerSimilarA);
            Assert.IsTrue(res.IsAnswerSimilarC);
            Assert.IsTrue(res.IsAnswerSimilarE);
            Assert.IsTrue(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreEqual2()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("ABCDEF", "abcdef");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsFalse(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsFalse(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreEqual3()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("Noël", "Noël");
            Assert.IsTrue(res.IsAnswerEqual);
            Assert.IsTrue(res.IsAnswerSimilar);
            Assert.IsTrue(res.IsAnswerSimilarA);
            Assert.IsTrue(res.IsAnswerSimilarC);
            Assert.IsTrue(res.IsAnswerSimilarE);
            Assert.IsTrue(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreEqual4()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("être", "être");
            Assert.IsTrue(res.IsAnswerEqual);
            Assert.IsTrue(res.IsAnswerSimilar);
            Assert.IsTrue(res.IsAnswerSimilarA);
            Assert.IsTrue(res.IsAnswerSimilarC);
            Assert.IsTrue(res.IsAnswerSimilarE);
            Assert.IsTrue(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreSimilar1()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("être", "etre");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsTrue(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsTrue(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreSimilar2()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("êtreA", "etreB");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsFalse(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsFalse(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreSimilar3()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("êtreA", "ätreB");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsFalse(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsFalse(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreSimilar4()
        {

            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("être", "ätre");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsFalse(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsFalse(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreSimilar5()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("Noël", "Noél");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsTrue(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsTrue(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreSimilar6()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("être élevé", "etre eleve");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsTrue(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsTrue(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreSimilar7()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("téléphoner à qn", "telephoner a qn");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsTrue(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsFalse(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void HaveTypo1()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("Bienvenue", "Bien venue");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsFalse(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsFalse(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void HaveTypo2()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("Bienvenue", "Bienveneu");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsFalse(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsFalse(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void HaveTypo3()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("merci", "mersi");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsFalse(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsFalse(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreDifferent1()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("avoir", "être");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsFalse(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsFalse(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }

        [Test]
        public void AreDifferent2()
        {
            SimilarityResult res = this.stringSimilarityService.CheckSimilarity("monsieur", "meusieur");
            Assert.IsFalse(res.IsAnswerEqual);
            Assert.IsFalse(res.IsAnswerSimilar);
            Assert.IsFalse(res.IsAnswerSimilarA);
            Assert.IsFalse(res.IsAnswerSimilarC);
            Assert.IsFalse(res.IsAnswerSimilarE);
            Assert.IsFalse(res.IsAnswerSimilarU);
        }
    }
}