namespace FileReadingLBR;
using System;
using System.IO;

/*
 *Library for reading files
 **As simple as posible
 
Gevorg Abgaryan 
*/
public class ReadFIle
{

    public static string Text(string fileLocation)
    {
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

                throw new FileNotFoundException("File not found", fileLocation);
            }
        }
        catch (Exception e)
        {
           // Console.Write("Error reading file:" + e.Message);
            return string.Format("Error reading file:" + e.Message);

        }
    }
}