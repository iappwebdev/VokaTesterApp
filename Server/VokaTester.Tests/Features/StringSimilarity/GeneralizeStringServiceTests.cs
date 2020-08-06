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
            string res = this.generalizeStringService.SanitizeString("une  fête!");
            Assert.AreEqual("une fête", res);
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
            bool res = this.generalizeStringService.HasArticle("une fête", out string article, out string word);
            Assert.IsTrue(res);
            Assert.AreEqual("une", article);
            Assert.AreEqual("fête", word);
        }


        [Test]
        public void HasArticle2()
        {
            bool res = this.generalizeStringService.HasArticle("une bonne fête", out string article, out string word);
            Assert.IsTrue(res);
            Assert.AreEqual("une", article);
            Assert.AreEqual("bonne fête", word);
        }

        [Test]
        public void HasArticle3()
        {
            bool res = this.generalizeStringService.HasArticle("ma fête", out string article, out string word);
            Assert.IsFalse(res);
            Assert.AreEqual(string.Empty, article);
            Assert.AreEqual("ma fête", word);
        }
    }
}