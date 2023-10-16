using System;
using System.IO;

namespace Thylek
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                start:
                Console.WriteLine("Make sure Your base TEXT file is in the same place as this APPs executable...");
                Console.WriteLine("Enter path to the folder:");
                string cesta = Console.ReadLine();
                //string plocha = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                //Your base text file
                string text = "text.txt";
                string lines;
                string[] cutted;

                //Creates files and writes into them if the inserted directory exists
                if (Directory.Exists(cesta))
                {
                    string[] hry = Directory.GetDirectories(cesta);

                    foreach (string folder in hry)
                    {
                        string kok = Path.GetFileName(folder);

                        string fileName = cesta + '\\' + kok + '\\' + kok + ".txt";
                        //If the game txt file already exists it won't overwrite it
                        if (!(File.Exists(fileName)))
                        {
                            using (var sw = new StreamWriter(fileName, false))
                            {
                                cutted = kok.Split(" - ");
                                sw.WriteLine(kok);
                                sw.WriteLine("");
                                
                                //Depending on console, adds name of the console
                                switch (cutted[0])
                                {
                                    case "PS1":
                                        sw.WriteLine("Nabízím tuto plně funkční hru " + cutted[1] + " pro PlayStation 1.");
                                        break;
                                    case "PS2":
                                        sw.WriteLine("Nabízím tuto plně funkční hru " + cutted[1] + " pro PlayStation 2.");
                                        break;
                                    case "PS3":
                                        sw.WriteLine("Nabízím tuto plně funkční hru " + cutted[1] + " pro PlayStation 3.");
                                        break;
                                    case "PSP":
                                        sw.WriteLine("Nabízím tuto plně funkční hru " + cutted[1] + " pro PSP.");
                                        break;
                                    case "PS Vita":
                                        sw.WriteLine("Nabízím tuto plně funkční hru " + cutted[1] + " pro PlayStation Vita.");
                                        break;
                                    default:
                                        sw.WriteLine("Nabízím tuto plně funkční hru 'Název hry' pro 'Název konzole'.");
                                        break;
                                }
                                
                                //Adds Your base text into the created text file
                                sw.WriteLine("");
                                if (File.Exists(text))
                                {
                                    lines = File.ReadAllText(text);
                                    sw.WriteLine(lines);
                                }
                                else
                                {
                                    Console.WriteLine("Your base text file is missing...");
                                }
                            }
                            Console.WriteLine(kok + " OK...");
                        }
                        else
                        {
                            Console.WriteLine("File '" + kok + "' already exists...");
                        }
                    }
                    Console.WriteLine("DONE!");
                }
                else
                {
                    Console.WriteLine("Entered path doesn't exist...");
                    goto start;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!!! Please copy this message to the developer:");
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}