namespace VokaTester.Tests.Features.StringSimilarity
{
    using NUnit.Framework;
    using VokaTester.Features.StringSimilarity;
    using VokaTester.Features.StringSimilarity.Dto;

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
        public void HasNoArticle1()
        {
            ArticleInfo res = this.generalizeStringService.GetArticleInfo("fête");
            Assert.IsFalse(res.HasPossibleArticle);
            Assert.IsFalse(res.HasArticle);
            Assert.IsFalse(res.IsMasc);
            Assert.IsFalse(res.IsFem);
            Assert.AreEqual(string.Empty, res.PossibleArticle);
            Assert.AreEqual(string.Empty, res.Article);
            Assert.AreEqual("fête", res.Word);
        }

        [Test]
        public void HasNoArticle2()
        {
            ArticleInfo res = this.generalizeStringService.GetArticleInfo("ma fête");
            Assert.IsTrue(res.HasPossibleArticle);
            Assert.IsFalse(res.HasArticle);
            Assert.IsFalse(res.IsMasc);
            Assert.IsFalse(res.IsFem);
            Assert.AreEqual("ma", res.PossibleArticle);
            Assert.AreEqual(string.Empty, res.Article);
            Assert.AreEqual("ma fête", res.Word);
        }

        [Test]
        public void HasArticle1()
        {
            ArticleInfo res = this.generalizeStringService.GetArticleInfo("une fête");
            Assert.IsTrue(res.HasPossibleArticle);
            Assert.IsFalse(res.HasArticle);
            Assert.IsTrue(res.IsMasc);
            Assert.IsFalse(res.IsFem);
            Assert.AreEqual("une", res.PossibleArticle);
            Assert.AreEqual("une", res.Article);
            Assert.AreEqual("fête", res.Word);
        }

        [Test]
        public void HasArticle2()
        {
            ArticleInfo res = this.generalizeStringService.GetArticleInfo("une bonne fête");
            Assert.IsTrue(res.HasPossibleArticle);
            Assert.IsTrue(res.HasArticle);
            Assert.IsFalse(res.IsMasc);
            Assert.IsTrue(res.IsFem);
            Assert.AreEqual("une", res.PossibleArticle);
            Assert.AreEqual("une", res.Article);
            Assert.AreEqual("bonne fête", res.Word);
        }

        [Test]
        public void HasArticle3()
        {
            ArticleInfo res = this.generalizeStringService.GetArticleInfo("un garçon");
            Assert.IsTrue(res.HasPossibleArticle);
            Assert.IsTrue(res.HasArticle);
            Assert.IsTrue(res.IsMasc);
            Assert.IsFalse(res.IsFem);
            Assert.AreEqual("un", res.PossibleArticle);
            Assert.AreEqual("un", res.Article);
            Assert.AreEqual("garçon", res.Word);
        }

        [Test]
        public void PrevCharNull1()
        {
            char? res = this.generalizeStringService.GetPrevChar(string.Empty, 0);
            Assert.IsNull(res);
        }

        [Test]
        public void PrevCharNull2()
        {
            char? res = this.generalizeStringService.GetPrevChar(string.Empty, 1);
            Assert.IsNull(res);
        }

        [Test]
        public void PrevCharNull3()
        {
            char? res = this.generalizeStringService.GetPrevChar("ab", 0);
            Assert.IsNull(res);
        }

        [Test]
        public void PrevCharNull4()
        {
            char? res = this.generalizeStringService.GetPrevChar("a", 1);
            Assert.IsNull(res);
        }

        [Test]
        public void PrevChar1()
        {
            char? res = this.generalizeStringService.GetPrevChar("ab", 1);
            Assert.AreEqual('a', res);
        }

        [Test]
        public void PrevChar2()
        {
            char? res = this.generalizeStringService.GetPrevChar("abc", 2);
            Assert.AreEqual('b', res);
        }


        [Test]
        public void NextCharNull1()
        {
            char? res = this.generalizeStringService.GetNextChar(string.Empty, 0);
            Assert.IsNull(res);
        }

        [Test]
        public void NextCharNull2()
        {
            char? res = this.generalizeStringService.GetNextChar(string.Empty, 1);
            Assert.IsNull(res);
        }

        [Test]
        public void NextCharNull3()
        {
            char? res = this.generalizeStringService.GetNextChar("ab", 1);
            Assert.IsNull(res);
        }

        [Test]
        public void NextCharNull4()
        {
            char? res = this.generalizeStringService.GetNextChar("a", 1);
            Assert.IsNull(res);
        }

        [Test]
        public void NextChar1()
        {
            char? res = this.generalizeStringService.GetNextChar("ab", 0);
            Assert.AreEqual('b', res);
        }


        [Test]
        public void NextChar2()
        {
            char? res = this.generalizeStringService.GetNextChar("ab", 1);
            Assert.IsNull(res);
        }

        [Test]
        public void NextChar3()
        {
            char? res = this.generalizeStringService.GetNextChar("abc", 1);
            Assert.AreEqual('c', res);
        }

        [Test]
        public void ShortString1()
        {
            string res = this.generalizeStringService.GetSurroundingString("a", 0);
            Assert.AreEqual("a", res);
        }

        [Test]
        public void ShortString2()
        {
            string res = this.generalizeStringService.GetSurroundingString("ab", 0);
            Assert.AreEqual("ab", res);
        }

        [Test]
        public void ShortString3()
        {
            string res = this.generalizeStringService.GetSurroundingString("ab", 1);
            Assert.AreEqual("ab", res);
        }

        [Test]
        public void StartString1()
        {
            string res = this.generalizeStringService.GetSurroundingString("abc", 0);
            Assert.AreEqual("ab", res);
        }

        [Test]
        public void StartString2()
        {
            string res = this.generalizeStringService.GetSurroundingString("abc", 1);
            Assert.AreEqual("abc", res);
        }

        [Test]
        public void StartString3()
        {
            string res = this.generalizeStringService.GetSurroundingString("abc", 2);
            Assert.AreEqual("bc", res);
        }

        [Test]
        public void StartString4()
        {
            string res = this.generalizeStringService.GetSurroundingString("abcdef", 0);
            Assert.AreEqual("ab", res);
        }

        [Test]
        public void MiddleString1()
        {
            string res = this.generalizeStringService.GetSurroundingString("abcdef", 1);
            Assert.AreEqual("abc", res);
        }


        [Test]
        public void MiddleString2()
        {
            string res = this.generalizeStringService.GetSurroundingString("abcdef", 2);
            Assert.AreEqual("bcd", res);
        }

        [Test]
        public void MiddleString3()
        {
            string res = this.generalizeStringService.GetSurroundingString("abcdef", 3);
            Assert.AreEqual("cde", res);
        }

        [Test]
        public void EndString1()
        {
            string res = this.generalizeStringService.GetSurroundingString("abcdef", 4);
            Assert.AreEqual("def", res);
        }

        [Test]
        public void EndString2()
        {
            string res = this.generalizeStringService.GetSurroundingString("abcdef", 5);
            Assert.AreEqual("ef", res);
        }

        [Test]
        public void EndString3()
        {
            string res = this.generalizeStringService.GetSurroundingString("abcdef", 10);
            Assert.AreEqual("ef", res);
        }
    }
}