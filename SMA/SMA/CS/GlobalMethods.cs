using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
namespace SMA.CS
{
    public static class GlobalMethods
    {
        static string emailRegex=@"\w{3,100}@\w*.\w{2,11}";
        static int SaltValueSize = 50;
        public static bool isValidMail(string mail)
        {
            bool toReturn = false;
            if (Regex.IsMatch(mail,emailRegex))
                toReturn=true;
            else
                toReturn=false;

            return toReturn;
        }
        public static bool isValidPassword(string pass,string confPass)
        {
            if(pass.ToString()==confPass.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool userNameValidation(string userName)
        {
            return (Comunication.existsUserName(userName)) ;
        }
        public static void registerUser(string defaultLanguage,string userName,string firstName ,string lastName,string phone 
                                                                                            ,string email ,string password )
        {
            string salt = GenerateSaltValue();
            string hashedPassword = HashPassword(password, salt, new SHA256Managed());

            Comunication.registerUser(defaultLanguage, userName, firstName, lastName, phone, email, hashedPassword, salt);
            Debug.WriteLine(hashedPassword);
            Debug.WriteLine(salt);
        }








        //_____________________________________________________________________________________________________
        private static string GenerateSaltValue()
        {
            UnicodeEncoding utf16 = new UnicodeEncoding();

            if (utf16 != null)
            {
                Random random = new Random(unchecked((int)DateTime.Now.Ticks));

                if (random != null)
                {
                    // Create an array of random values.

                    byte[] saltValue = new byte[SaltValueSize];

                    random.NextBytes(saltValue);

                    // Convert the salt value to a string. Note that the resulting string
                    // will still be an array of binary values and not a printable string. 
                    // Also it does not convert each byte to a double byte.

                    string saltValueString = utf16.GetString(saltValue);

                    // Return the salt value as a string.

                    return saltValueString;
                }
            }

            return null;
        }

        private static string HashPassword(string clearData, string saltValue, HashAlgorithm hash)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();

            if (clearData != null && hash != null && encoding != null)
            {
                if (saltValue == null)
                {
                    // Generate a salt string.
                    saltValue = GenerateSaltValue();
                }
                
                byte[] binarySaltValue = new byte[SaltValueSize];

                binarySaltValue[0] = byte.Parse(saltValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[1] = byte.Parse(saltValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[2] = byte.Parse(saltValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[3] = byte.Parse(saltValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);

                byte[] valueToHash = new byte[SaltValueSize + encoding.GetByteCount(clearData)];
                byte[] binaryPassword = encoding.GetBytes(clearData);

                // Copy the salt value and the password to the hash buffer.

                binarySaltValue.CopyTo(valueToHash, 0);
                binaryPassword.CopyTo(valueToHash, SaltValueSize);

                byte[] hashValue = hash.ComputeHash(valueToHash);

                // The hashed password is the salt plus the hash value (as a string).

                string hashedPassword = saltValue;

                foreach (byte hexdigit in hashValue)
                {
                    hashedPassword += hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
                }

                // Return the hashed password as a string.

                return hashedPassword;
            }

            return null;
        }
    }
}