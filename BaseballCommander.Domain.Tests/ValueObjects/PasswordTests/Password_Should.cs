using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseballCommander.Domain.Tests.ValueObjects.PasswordTests
{
    [TestClass]
    public class Password_Should : BaseTest
    {
        public Password_Should()
        {
        }

        [TestMethod]
        public void SetTheHashAndSalt()
        {
            var password = new Domain.ValueObjects.Password("password");
            Assert.IsFalse(password.PlainText == null);
            Assert.IsFalse(password.Hash == null);
            Assert.IsFalse(password.Salt == null);
        }

        [TestMethod]
        public void FailWhenEmpty()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var empty = new Domain.ValueObjects.Password("");
            });
        }
    }
}