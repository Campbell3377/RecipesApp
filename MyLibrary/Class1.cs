using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyLibrary
{
    public class Hash
    {
        public bool CreateUser(string username, string password)
        {
            bool isUserCreated = false;

            if (IsUsernameTaken(username))
            {
                return isUserCreated;
            }

            byte[] salt = GenerateSalt();
            byte[] hash = PBKDF2(password, salt, 10000, 32);
            string hashString = Convert.ToBase64String(hash);
            string saltString = Convert.ToBase64String(salt);

            XDocument doc;
            string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/members.xml");
            if (File.Exists(xmlFilePath))
            {
                doc = XDocument.Load(xmlFilePath);
            }
            else
            {
                doc = new XDocument(new XElement("members"));
            }
            XElement newUser = new XElement("member",
                new XElement("username", username),
                new XElement("hash", hashString),
                new XElement("salt", saltString)
            );
            doc.Element("members").Add(newUser);
            doc.Save(xmlFilePath);

            isUserCreated = true;
            return isUserCreated;
        }

        private bool IsUsernameTaken(string username)
        {
            string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/members.xml");

            if (!File.Exists(xmlFilePath))
            {
                return false;
            }

            XDocument doc = XDocument.Load(xmlFilePath);
            XElement member = doc.Descendants("member").FirstOrDefault(m => m.Element("username").Value == username);

            if (member != null)
            {
                return true;
            }

            return false;
        }

        public string GetPassword(string username)
        {
            string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/members.xml");

            if (!File.Exists(xmlFilePath))
            {
                return "File Not Found";
            }

            XDocument doc = XDocument.Load(xmlFilePath);
            XElement member = doc.Descendants("member").FirstOrDefault(m => m.Element("username").Value == username);

            if (member != null)
            {
                return member.Element("hash").Value;
            }
            else
            {
                return "User not found";
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/members.xml");
            XDocument doc = XDocument.Load(xmlFilePath);
            XElement userElement = doc.Descendants("member")
                .FirstOrDefault(e => e.Element("username").Value == username);
            if (userElement == null)
            {
                return false;
            }
            byte[] hash = Convert.FromBase64String(userElement.Element("hash").Value);
            byte[] salt = Convert.FromBase64String(userElement.Element("salt").Value);
            byte[] computedHash = PBKDF2(password, salt, 10000, 32);
            string hashString = Convert.ToBase64String(hash);
            string computedHashString = Convert.ToBase64String(computedHash);
            return hash.SequenceEqual(computedHash);
        }

        private byte[] GenerateSalt()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16];
                rng.GetBytes(salt);
                return salt;
            }
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int hashByteSize)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                pbkdf2.IterationCount = iterations;
                //pbkdf2.HashSize = hashByteSize;
                return pbkdf2.GetBytes(hashByteSize);
            }
        }

        private static byte[] StringToByteArray(string hex)
        {
            int numBytes = hex.Length / 2;
            byte[] bytes = new byte[numBytes];
            for (int i = 0; i < numBytes; i++)
            {
                string byteValue = hex.Substring(i * 2, 2);
                bytes[i] = Convert.ToByte(byteValue, 16);
            }
            return bytes;
        }

    }
}
