namespace VokaTester.Tests.Data.Models
{
    using NUnit.Framework;
    using VokaTester.Data.Models;

    public class StringSimilarityServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Contains_a_True()
        {
            var vokabel = new Vokabel { Frz = "alors" };
            Assert.IsTrue(vokabel.HasChar_a);
        }

        [Test]
        public void Contains_a_False()
        {
            var vokabel = new Vokabel { Frz = "à plus" };
            Assert.IsFalse(vokabel.HasChar_a);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_à_True()
        {
            var vokabel = new Vokabel { Frz = "à plus" };
            Assert.IsTrue(vokabel.HasChar_à);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_à_False()
        {
            var vokabel = new Vokabel { Frz = "alors" };
            Assert.IsTrue(vokabel.HasChar_a);
        }

        [Test]
        public void Contains_â_True()
        {
            var vokabel = new Vokabel { Frz = "le théâtre" };
            Assert.IsTrue(vokabel.HasChar_â);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_é);
        }

        [Test]
        public void Contains_â_False()
        {
            var vokabel = new Vokabel { Frz = "attention" };
            Assert.IsFalse(vokabel.HasChar_â);
            Assert.IsTrue(vokabel.HasChar_a);
            Assert.IsTrue(vokabel.HasChar_e);
        }


        [Test]
        public void Contains_c_True()
        {
            var vokabel = new Vokabel { Frz = "comme" };
            Assert.IsTrue(vokabel.HasChar_c);
            Assert.IsTrue(vokabel.HasChar_e);
        }

        [Test]
        public void Contains_c_False()
        {
            var vokabel = new Vokabel { Frz = "le garçon" };
            Assert.IsFalse(vokabel.HasChar_c);
            Assert.IsTrue(vokabel.HasChar_ç);
            Assert.IsTrue(vokabel.HasChar_e);
        }

        [Test]
        public void Contains_ç_True()
        {
            var vokabel = new Vokabel { Frz = "le garçon" };
            Assert.IsTrue(vokabel.HasChar_ç);
            Assert.IsTrue(vokabel.HasChar_a);
            Assert.IsTrue(vokabel.HasChar_e);
        }

        [Test]
        public void Contains_ç_False()
        {
            var vokabel = new Vokabel { Frz = "comme" };
            Assert.IsFalse(vokabel.HasChar_ç);
            Assert.IsTrue(vokabel.HasChar_c);
            Assert.IsTrue(vokabel.HasChar_e);
        }

        [Test]
        public void Contains_e_True()
        {
            var vokabel = new Vokabel { Frz = "regarder" };
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_a);
        }

        [Test]
        public void Contains_e_False()
        {
            var vokabel = new Vokabel { Frz = "un café" };
            Assert.IsFalse(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_a);
            Assert.IsTrue(vokabel.HasChar_c);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_é_True()
        {
            var vokabel = new Vokabel { Frz = "un café" };
            Assert.IsTrue(vokabel.HasChar_é);
            Assert.IsTrue(vokabel.HasChar_a);
            Assert.IsTrue(vokabel.HasChar_c);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_é_False()
        {
            var vokabel = new Vokabel { Frz = "regarder" };
            Assert.IsFalse(vokabel.HasChar_é);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_a);
        }

        [Test]
        public void Contains_è_True()
        {
            var vokabel = new Vokabel { Frz = "après" };
            Assert.IsTrue(vokabel.HasChar_è);
            Assert.IsTrue(vokabel.HasChar_a);
        }

        [Test]
        public void Contains_è_False()
        {
            var vokabel = new Vokabel { Frz = "élevé" };
            Assert.IsFalse(vokabel.HasChar_è);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_é);
        }

        [Test]
        public void Contains_ê_True()
        {
            var vokabel = new Vokabel { Frz = "une fête" };
            Assert.IsTrue(vokabel.HasChar_ê);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_ê_False()
        {
            var vokabel = new Vokabel { Frz = "un kilomètre" };
            Assert.IsFalse(vokabel.HasChar_ê);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_è);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_ë_True()
        {
            var vokabel = new Vokabel { Frz = "Noël" };
            Assert.IsTrue(vokabel.HasChar_ë);
        }

        [Test]
        public void Contains_ë_False()
        {
            var vokabel = new Vokabel { Frz = "une fête" };
            Assert.IsFalse(vokabel.HasChar_ë);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_ê);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_u_True()
        {
            var vokabel = new Vokabel { Frz = "Bonjour" };
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_u_False()
        {
            var vokabel = new Vokabel { Frz = "coûter" };
            Assert.IsFalse(vokabel.HasChar_u);
            Assert.IsTrue(vokabel.HasChar_û);
            Assert.IsTrue(vokabel.HasChar_e);
        }


        [Test]
        public void Contains_û_True()
        {
            var vokabel = new Vokabel { Frz = "août" };
            Assert.IsTrue(vokabel.HasChar_û);
            Assert.IsTrue(vokabel.HasChar_a);
        }

        [Test]
        public void Contains_û_False()
        {
            var vokabel = new Vokabel { Frz = "Salut" };
            Assert.IsFalse(vokabel.HasChar_û);
            Assert.IsTrue(vokabel.HasChar_a);
            Assert.IsTrue(vokabel.HasChar_u);
        }
    }
}