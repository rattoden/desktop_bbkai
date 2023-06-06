using desktop_bbkai.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAuthorization()
        {
            Auth forUser = new Auth();
            var actual = forUser.authU("lee", "2");
            var expected = "Успешно!";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestVivodNews()
        {
            NewssA forUser = new NewssA();
            var actual = forUser.vivodNews();
            var expected = "Успешно!";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAddGroup()
        {
            GroupsA addCake = new GroupsA();
            var actual = addCake.addGroup("3212");
            var expected = "Успешно!";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestEditDisc()
        {
            DiscsA editCake = new DiscsA();
            var actual = editCake.editDisc(7003, "Основы алгоритмизации");
            var expected = "Успешно!";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDeleteUser()
        {
            Userii deleteCake = new Userii();
            var actual = deleteCake.deleteU(12021);
            var expected = "Успешно!";
            Assert.AreEqual(expected, actual);
        }
    }
}
