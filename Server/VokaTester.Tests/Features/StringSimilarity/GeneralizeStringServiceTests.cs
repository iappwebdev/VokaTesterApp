namespace VokaTester.Tests.Features.StringSimilarity
{
    using NUnit.Framework;
    using VokaTester.Features.StringSimilarity;

    public class GeneralizeStringServiceTests
    {
        private readonly GeneralizeStringService generalizeStringService = new GeneralizeStringService();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AreEqual1()
        {
            string res = this.generalizeStringService.SanitizeString("une  f�te!");
            Assert.AreEqual("une f�te", res);
        }

        [Test]
        public void AreEqual2()
        {
            string res = this.generalizeStringService.SanitizeString("qu'est-ce que c'est?");
            Assert.AreEqual("qu'est-ce que c'est", res);
        }
        
        [Test]
        public void HasArticle1()
        {
            bool res = this.generalizeStringService.HasArticle("une f�te", out string article, out string word);
            Assert.IsTrue(res);
            Assert.AreEqual("une", article);
            Assert.AreEqual("f�te", word);
        }


        [Test]
        public void HasArticle2()
        {
            bool res = this.generalizeStringService.HasArticle("une bonne f�te", out string article, out string word);
            Assert.IsTrue(res);
            Assert.AreEqual("une", article);
            Assert.AreEqual("bonne f�te", word);
        }

        [Test]
        public void HasArticle3()
        {
            bool res = this.generalizeStringService.HasArticle("ma f�te", out string article, out string word);
            Assert.IsFalse(res);
            Assert.AreEqual(string.Empty, article);
            Assert.AreEqual("ma f�te", word);
        }
    }
}