using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Daves Chicken";
        job1._jobTitle = "Executive Marketing Promoter";
        job1._startYear = 2024;
        job1._endYear = 2027;

        Console.WriteLine(job1._company);

        Job job2 = new Job();
        job2._company = "Applebees";
        job2._jobTitle = "Underwater Ceramics Technician";
        job2._startYear = 2023;
        job2._endYear = 2024;

        Console.WriteLine(job2._company);
    }
}