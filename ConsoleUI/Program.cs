using FileReadingLBR;
using FileReadingLBR.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Xml;

namespace ConsoleFileReader
{
    class Program
    {
        static void Main(string[] args)
        {



            var test = new
            {
                name = "rick",
                company = "Westwind",
                entered = DateTime.UtcNow
            };


            string json = JsonConvert.SerializeObject(test);
            Console.WriteLine(json); // single line JSON string

            string jsonFormatted = JValue.Parse(json).ToString(Newtonsoft.Json.Formatting.Indented);

            Console.WriteLine(jsonFormatted);

    
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
                Console.WriteLine("2. Read Xml File");
                Console.WriteLine("3. Read Encrypted File");
                Console.WriteLine("4. Read Json File");
                Console.WriteLine("9. Clear history");
                Console.WriteLine("0. Exit");

                Console.Write("Option: ");
                userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ReadFile(FileType.Text);
                    break;
                case "2":
                     ReadFile(FileType.Xml);
                    break;
                case "3":
                    ReadFile(FileType.EncryptedText);
                    break;
                case "4":
                    ReadFile(FileType.Json);
                    break;
                    case "9":
                    Console.Clear();
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

        static void ReadFile(FileType fileType)
        {
            IRoleSecurity security = new SimpleRoleSecurity();
            IEncryptionStrategy encryption = new SimpleEncryptionStrategy();
            ReadFIle readFIle = new ReadFIle(security, encryption);
            string role = null;

            string[] files = [];

            //if file is a txt file, search only text files and late the user choose one of them.------------------
            if (fileType == FileType.Text) {
              
                //Getting all files 
                string directoryPath = "../../../../src/text"; // Current directory
                files = Directory.GetFiles(directoryPath, "*.txt");
                Console.Write("Please give your role (admin|user): ");
                role = Console.ReadLine();
            }

            //if file is a XML file, search only XML files and late the user choose one of them. ------------------
            if (fileType == FileType.Xml)
            {
               
                //Getting all files 
                string directoryPath = "../../../../src/xml"; // Current directory
                files = Directory.GetFiles(directoryPath, "*.xml");
                Console.Write("Please give your role (admin|user): ");
                role = Console.ReadLine();
            }

            if (fileType == FileType.EncryptedText)
            {

                //Getting all files 
                string directoryPath = "../../../../src/encrypted"; // Current directory
                files = Directory.GetFiles(directoryPath);
        
            }
            if (fileType == FileType.Json)
            {

                //Getting all files 
                string directoryPath = "../../../../src/json"; // Current directory
                files = Directory.GetFiles(directoryPath,"*.json");

            }

            //Show all avalibe files
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Select a file:");
            Console.ForegroundColor = ConsoleColor.White;
            //showing files
            for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + Path.GetFileName(files[i]));
                }

            Console.Write("Enter the number of the file to select: ");
            string userInput = Console.ReadLine();


            //get the selected file
            if (int.TryParse(userInput, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= files.Length)
            {
                string selectedFile = files[selectedIndex - 1];
                string fileName = Path.GetFileName(selectedFile);
      
                Console.Write("\nSelected file: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(fileName + "\n");
                Console.ForegroundColor = ConsoleColor.White;


                //selected file path to read the file via ReadFile Library 

                /*   */
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("-----------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(readFIle.ConsoleText(selectedFile, fileType, role));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("-----------------------------------");
                /*   */
                //selected file path to read the file via ReadFile Library open files with notepad - comment out line below and comment code above to see the result

                // readFIle.notepad(selectedFile, fileType, role);


            }
            //invalid input from the user
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid selection.");
                Console.ForegroundColor = ConsoleColor.White;
          
            }
        }    
    }  
}