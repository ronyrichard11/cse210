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
            
            static void SelectionList(string name){Console.WriteLine($"\nHello {name}, Welcome to your Personalized Journal!");
            Console.WriteLine($"Type in the number, to do the corresponding action!\n");
            Console.WriteLine($"1 - Write\n2 - Display\n3 - Save\n4 - Load\n5 - Quit\n");
            Console.Write($"What would you like to do? ");
            }

            SelectionList(name);
            selection = int.Parse(Console.ReadLine());
            
            

            while (selection == 1){
                Write write1 = new Write();
                Console.WriteLine($"Prompt of the Day:\n ");
                Console.WriteLine($"Begin typing your entry below:\n");
                
                write1._entry = Console.ReadLine();
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

            while (selection == 5){
                Environment.Exit(0);
            }

        }
    }
}