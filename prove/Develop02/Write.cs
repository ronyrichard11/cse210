using System;

public class Write{
    
    public List<string> _entries = new List<string>();
    public string _entry = "";

    public void Display()
    {
        Console.WriteLine($"{_entry}\n");
    }
}
