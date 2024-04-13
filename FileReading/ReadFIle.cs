namespace FileReadingLBR;

using FileReadingLBR.Security;
using System;
using System.Diagnostics;
using System.IO;

/*
 *Library for reading files
 **As simple as posible
 
Gevorg Abgaryan 
*/
public class ReadFIle
{
    readonly IRoleSecurity _security;

    public ReadFIle(IRoleSecurity security) {
        _security = security;
    }
    public  string ConsoleText(string fileLocation, FileType filetype, string? role)
    {
        string fileName = Path.GetFileName(fileLocation);

        if (filetype == FileType.Text || filetype == FileType.Xml)
        {
            try
            {
                if (!_security.HasPermission(role, fileLocation))
                {
                    throw new UnauthorizedAccessException("Access denied.");
                }
                else
                {
                    return File.ReadAllText(fileLocation);
                }

                // Read and return the content of the XML file

            }
            catch (Exception e)
            {
                // Console.Write("Error reading file:" + e.Message);
                return string.Format("Error reading file: " + e.Message);

            }
        }

            //if encrypted file
            if (filetype == FileType.EncryptedText)
            {
            //change the encription statagy if needed. can be any encription class implementing IEncryptionStrategy interface
            IEncryptionStrategy encryptionStrategy = new SimpleEncryptionStrategy();
            try
            {

                if (File.Exists(fileLocation))
                {

                    string encryptedText = File.ReadAllText(fileLocation);
                    string decryptedText = encryptionStrategy.Decrypt(encryptedText);
                    return decryptedText;
                }
                else
                {

                    throw new FileNotFoundException("File not found/File does not exist. ", fileName);
                }
            }
            catch (Exception e)
            {
                // Console.Write("Error reading file:" + e.Message);
                return string.Format("Error reading file:" + e.Message);

            }
          

        }
        return string.Empty;
    }




    //extra for GUI can also be used in ConsoneUI 
    public  async  void notepad(string fileLocation, FileType filetype, string? role)
    {
        string readText = "";

   

        if(filetype == FileType.Xml || filetype == FileType.Text)
        {
            try
            {
                if (!_security.HasPermission(role, fileLocation))
                {
                    throw new UnauthorizedAccessException("Access denied.");
                }
                else
                {
                    // Check if the file exists
                    if (File.Exists(fileLocation))
                    {
                        // Use Process.Start to open the file with the default application
                        Process.Start("notepad.exe", fileLocation);
                        // readText = File.ReadAllText(fileLocation);

                    }
                    else
                    {
                        Console.WriteLine("File not found/File does not exist.");
                    }
                }

                // Read and return the content of the XML file

            }
            catch (Exception e)
            {
                // Console.Write("Error reading file:" + e.Message);
                Console.WriteLine( string.Format("Error reading file: " + e.Message));

            }
        }

        //if encrypted file
        if (filetype == FileType.EncryptedText)
        {
            string encryptedText = "";
            string decryptedText = "";
            IEncryptionStrategy encryptionStrategy = new SimpleEncryptionStrategy();
            if (File.Exists(fileLocation))
            {

                encryptedText = File.ReadAllText(fileLocation);
                decryptedText = encryptionStrategy.Decrypt(encryptedText);
                File.WriteAllText(fileLocation, decryptedText);
                // Use Process.Start to open the file with the default application
                Process.Start("notepad.exe", fileLocation);
                // readText = File.ReadAllText(fileLocation);

            }
            else
            {
                Console.WriteLine("File not found/File does not exist.");
            }
            await Task.Delay(3000);
            File.WriteAllText(fileLocation, encryptedText);
        }

    }
    
}