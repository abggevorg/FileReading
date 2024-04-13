using FileReadingLBR;
using System;
using System.IO;
using System.Xml;

namespace ConsoleFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File Read Application - Console UI:");

            string userInput = "";
            while (userInput != "0")
            {
                Console.WriteLine();
             
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Select an option:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Read Text");
                Console.WriteLine("0. Exit");

                Console.Write("Option: ");
                userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ReadTextFile();
                    break;
      
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please try again.");
                    break;
                }
            }
        }

        static void ReadTextFile()
        {  
            Console.WriteLine("");
      
       
            //Getting all files 
            string directoryPath = "../../../../src/text"; // Current directory
            string[] files = Directory.GetFiles(directoryPath, "*.txt");

            //Show all avalibe files
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Select a file:");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + Path.GetFileName(files[i]));
            }

            Console.Write("Enter the number of the file to select: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= files.Length)
            {
                string selectedFile = files[selectedIndex - 1];
                string fileName = Path.GetFileName(selectedFile);
      
                Console.Write("\nSelected file: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(fileName + "\n");
                Console.ForegroundColor = ConsoleColor.White;
                //  selected file path to read the file conteConsole.ForegroundColor = ConsoleColor.Green;nt via ReadFile Library 
                Console.WriteLine( ReadFIle.Text(selectedFile));

            
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }



    }
}