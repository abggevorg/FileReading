namespace FileReadingLBR;
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

    public static string ConsoleText(string fileLocation,FileType filetype)
    {
        string fileName = Path.GetFileName(fileLocation);
        if (filetype == FileType.Text || filetype == FileType.Xml) {
            // Console.Write(fileLocation);
            try
            {

                if (File.Exists(fileLocation))
                {

                    string readText = File.ReadAllText(fileLocation);
                    return readText;
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
      
            return null;
       
    }
    public static void notepad(string fileLocation, FileType filetype) 
        {
             string readText = "";

            // Check if the file exists
            if (System.IO.File.Exists(fileLocation))
            {
            // Use Process.Start to open the file with the default application
            Process.Start("notepad.exe", fileLocation);
            readText = File.ReadAllText(fileLocation);
           
        }
            else
            {
                Console.WriteLine("File does not exist.");
            }
      
        }

    
}