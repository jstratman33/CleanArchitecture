using System;

namespace BaseballCommander.Domain.ValueObjects
{
    public class Password
    {
        public string PlainText { get; }
        public byte[] Hash { get; private set; }
        public byte[] Salt { get; private set; }

        public Password(string text)
        {
            PlainText = text;
            CreateHash(text);
        }

        public Password(string text, byte[] hash, byte[] salt)
        {
            PlainText = text;
            Hash = hash;
            Salt = salt;
        }

        private void CreateHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty or only spaces.", nameof(password));

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                Salt = hmac.Key;
                Hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool Verify()
        {
            if (string.IsNullOrWhiteSpace(PlainText)) throw new ArgumentException("Password cannot be empty or only spaces.", nameof(PlainText));
            if (Hash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", nameof(Hash));
            if (Salt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", nameof(Salt));

            using (var hmac = new System.Security.Cryptography.HMACSHA512(Salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(PlainText));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != Hash[i]) return false;
                }
            }

            return true;
        }

    }
}