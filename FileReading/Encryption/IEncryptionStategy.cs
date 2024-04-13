using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLBR;
public interface IEncryptionStrategy
{
    string Encrypt(string text);
    string Decrypt(string encryptedText);


}
