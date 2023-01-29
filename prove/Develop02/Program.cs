using System;

class Program
{
    static void Main(string[] args)
    {
        string name = "xzaq";

        while (name == "xzaq"){
            Console.Write($"What is your name? ");
            name = Console.ReadLine();
        }

        if (name != "xzaq"){
            
            int selection = 0;
            List<string> _entries = new List<string>();
            
            static void SelectionList(string name){
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"\nHello {name}, Welcome to your Personalized Journal!");
            Console.WriteLine($"Type in the number, to do the corresponding action!\n");
            Console.WriteLine($"1 - Write\n2 - Display\n3 - Save\n4 - Load\n5 - Quit\n");
            Console.Write($"What would you like to do? ");
            }

            SelectionList(name);
            selection = int.Parse(Console.ReadLine());
            
            

            while (selection == 1){

                List<string> myList = new List<string>() {"Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?"};
                Random rnd = new Random();
                int index = rnd.Next(myList.Count);
                string randomString = myList[index];
                DateTime currentDateTime = DateTime.Now;
                

                Write write1 = new Write();
                Console.WriteLine($"\nBegin typing your entry below:\n");
                Console.WriteLine($"Prompt of the Day!");
                Console.WriteLine($"{randomString}\n");
                write1._entry = ($"{currentDateTime} {Console.ReadLine()}");
                _entries.Add(write1._entry);
                
                Console.WriteLine("\nEntry Saved!");
                
                selection = 0;
                SelectionList(name);
                selection = int.Parse(Console.ReadLine());
            }
            
            while (selection == 2){
                foreach (string entry in _entries){
                    Console.WriteLine($"\n{entry}");
                }

                selection = 0;
                SelectionList(name);
                selection = int.Parse(Console.ReadLine());
            }

            while (selection == 3){
                Console.WriteLine($"What do you want to name your file?");
                string filename = Console.ReadLine() + ".txt";
    
                
                using (StreamWriter outputFile = new StreamWriter(filename)){
                    foreach (string entry in _entries){
                        outputFile.WriteLine(entry);
                }
                }
                selection = 0;
                SelectionList(name);
                selection = int.Parse(Console.ReadLine());

            }

            while (selection == 4){
                Console.WriteLine("What is the File Name?\n");
                string filePath = Console.ReadLine() + ".txt";

                using (StreamReader sr = new StreamReader(filePath)){
                    while (!sr.EndOfStream){
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
                
                selection = 0;
                SelectionList(name);
                selection = int.Parse(Console.ReadLine());
            }

            while (selection == 5){
                Console.WriteLine($"Thank you! Goodbye {name}!");
                Environment.Exit(0);
            }

        }
    }
}
