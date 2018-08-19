using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Http.Controllers;

namespace Util.Converters
{
    public class Converter
    {
        protected const string DEFAULT_PASS = "$@ramas123";
        public AccountAccess ToAccessAccount(string value)
        {
            if (value == AccountAccess.ADMIN.ToString())
                return AccountAccess.ADMIN;
            else if (value == AccountAccess.ALL.ToString())
                return AccountAccess.ALL;
            else if (value == AccountAccess.USER.ToString())
                return AccountAccess.USER;
            else if (value == AccountAccess.ROOT.ToString())
                return AccountAccess.ROOT;
            //else if (value == AccountAccess.CUSER.ToString())
            //    return AccountAccess.CUSER;
            //else if (value == AccountAccess.PUSER.ToString())
            //    return AccountAccess.PUSER;
            return AccountAccess.UNDEFINED;
        }
        public string GetHeaderKeyPair(HttpActionContext actionContext, string key)
        {
            return actionContext?.Request?.Headers?.Where(x => x.Key.Equals(key))?
                .FirstOrDefault().Value?.FirstOrDefault();
        }
        public string AccessAccountToString(AccountAccess access)
        { return access.ToString(); }

        public string Encrypt256(string value)
        {
            return Encrypt256(value, DEFAULT_PASS);
        }

        public string Decrypt256(string value)
        {
            return Decrypt256(value, DEFAULT_PASS);
        }

        public string Encrypt256(string value, string pass)
        {
            if (!string.IsNullOrEmpty(value))
            {
                byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(value);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(pass);
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
                byte[] bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);
                string str = Convert.ToBase64String(bytesEncrypted);
                return str;
            }
            return null;
        }

        public string Decrypt256(string value, string pass)
        {
            if (!string.IsNullOrEmpty(value))
            {
                byte[] bytesToBeDecrypted = Convert.FromBase64String(value);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(pass);
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
                byte[] bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);
                string str = Encoding.UTF8.GetString(bytesDecrypted);
                return str;
            }
            return null;
        }

        public string GetString(string value)
        {
            var splitArray = Regex.Split(value, @"(?<=\p{L})(?=\p{N})");
            if (splitArray != null)
                if (splitArray.Length == 2)
                    return splitArray[0];
            return null;
        }

        public int GetInteger(string value, out bool status)
        {
            status = false;
            int id = -1;
            var splitArray = Regex.Split(value, @"(?<=\p{L})(?=\p{N})");
            if (splitArray != null)
                if (splitArray.Length == 2)
                    if (int.TryParse(splitArray[1], out id))
                        status = !status;
            return id;
        }

        private byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}
