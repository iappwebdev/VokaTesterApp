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
            var vokabel = new Vokabel { Frz = "� plus" };
            Assert.IsFalse(vokabel.HasChar_a);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_�_True()
        {
            var vokabel = new Vokabel { Frz = "� plus" };
            Assert.IsTrue(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_�_False()
        {
            var vokabel = new Vokabel { Frz = "alors" };
            Assert.IsTrue(vokabel.HasChar_a);
        }

        [Test]
        public void Contains_�_True()
        {
            var vokabel = new Vokabel { Frz = "le th��tre" };
            Assert.IsTrue(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_�);
        }

        [Test]
        public void Contains_�_False()
        {
            var vokabel = new Vokabel { Frz = "attention" };
            Assert.IsFalse(vokabel.HasChar_�);
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
            var vokabel = new Vokabel { Frz = "le gar�on" };
            Assert.IsFalse(vokabel.HasChar_c);
            Assert.IsTrue(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_e);
        }

        [Test]
        public void Contains_�_True()
        {
            var vokabel = new Vokabel { Frz = "le gar�on" };
            Assert.IsTrue(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_a);
            Assert.IsTrue(vokabel.HasChar_e);
        }

        [Test]
        public void Contains_�_False()
        {
            var vokabel = new Vokabel { Frz = "comme" };
            Assert.IsFalse(vokabel.HasChar_�);
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
            var vokabel = new Vokabel { Frz = "un caf�" };
            Assert.IsFalse(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_a);
            Assert.IsTrue(vokabel.HasChar_c);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_�_True()
        {
            var vokabel = new Vokabel { Frz = "un caf�" };
            Assert.IsTrue(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_a);
            Assert.IsTrue(vokabel.HasChar_c);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_�_False()
        {
            var vokabel = new Vokabel { Frz = "regarder" };
            Assert.IsFalse(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_a);
        }

        [Test]
        public void Contains_�_True()
        {
            var vokabel = new Vokabel { Frz = "apr�s" };
            Assert.IsTrue(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_a);
        }

        [Test]
        public void Contains_�_False()
        {
            var vokabel = new Vokabel { Frz = "�lev�" };
            Assert.IsFalse(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_�);
        }

        [Test]
        public void Contains_�_True()
        {
            var vokabel = new Vokabel { Frz = "une f�te" };
            Assert.IsTrue(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_�_False()
        {
            var vokabel = new Vokabel { Frz = "un kilom�tre" };
            Assert.IsFalse(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_u);
        }

        [Test]
        public void Contains_�_True()
        {
            var vokabel = new Vokabel { Frz = "No�l" };
            Assert.IsTrue(vokabel.HasChar_�);
        }

        [Test]
        public void Contains_�_False()
        {
            var vokabel = new Vokabel { Frz = "une f�te" };
            Assert.IsFalse(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_e);
            Assert.IsTrue(vokabel.HasChar_�);
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
            var vokabel = new Vokabel { Frz = "co�ter" };
            Assert.IsFalse(vokabel.HasChar_u);
            Assert.IsTrue(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_e);
        }


        [Test]
        public void Contains_�_True()
        {
            var vokabel = new Vokabel { Frz = "ao�t" };
            Assert.IsTrue(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_a);
        }

        [Test]
        public void Contains_�_False()
        {
            var vokabel = new Vokabel { Frz = "Salut" };
            Assert.IsFalse(vokabel.HasChar_�);
            Assert.IsTrue(vokabel.HasChar_a);
            Assert.IsTrue(vokabel.HasChar_u);
        }
    }
}