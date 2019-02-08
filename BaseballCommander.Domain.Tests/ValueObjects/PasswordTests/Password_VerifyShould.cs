using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseballCommander.Domain.Tests.ValueObjects.PasswordTests
{
    [TestClass]
    public class Password_VerifyShould : BaseTest
    {
        private readonly string _validPassword;
        private readonly byte[] _validHash;
        private readonly byte[] _validSalt;

        public Password_VerifyShould()
        {
            _validPassword = "password";
            var password = new Domain.ValueObjects.Password(_validPassword);
            _validHash = password.Hash;
            _validSalt = password.Salt;
        }

        [TestMethod]
        public void FailWhenEmpty()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var empty = new Domain.ValueObjects.Password("");
            });
        }

        [TestMethod]
        public void FailWhenHashLengthIsWrong()
        {
            var random = new Random();
            var length = random.Next();
            while (length == 64) length = random.Next();
            var hash = new byte[length];
            var password = new Domain.ValueObjects.Password(_validPassword, hash, _validSalt);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var verify = password.Verify();
            });
        }

        [TestMethod]
        public void FailWhenSaltLengthIsWrong()
        {
            var random = new Random();
            var length = random.Next();
            while (length == 128) length = random.Next();
            var salt = new byte[length];
            var password = new Domain.ValueObjects.Password(_validPassword, _validHash, salt);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var verify = password.Verify();
            });
        }

        [TestMethod]
        public void FailWithIncorrectPassword()
        {
            var password = new Domain.ValueObjects.Password("wrongpassword", _validHash, _validSalt);
            Assert.IsFalse(password.Verify());
        }

        [TestMethod]
        public void PassWithCorrectPassword()
        {
            var password = new Domain.ValueObjects.Password(_validPassword, _validHash, _validSalt);
            Assert.IsTrue(password.Verify());
        }
    }
}