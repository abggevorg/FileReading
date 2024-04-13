using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FileReadingLBR;


    public class SimpleEncryptionStrategy : IEncryptionStrategy
    {
        //simple encryption adding <encrypted> in the beggining and the end of the text 
        //We are not lusing encryption only decryption
        public string Encrypt(string text)
        {
            string newEncryptedText = "<encrypted>" + text + "<encrypted>";
            return new string(newEncryptedText.Reverse().ToArray());
    }
        public string Decrypt(string encryptedText)
        {
        string textDecryptedText = new string(encryptedText.Reverse().ToArray());
            return textDecryptedText.Replace("<encrypted>", "");

    }


    }
