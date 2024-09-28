using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._title = "CEO";
        job1._company = "BYU Tech";
        job1._startYear = 1930;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._title = "Fireman";
        job2._company = "FireForce";
        job2._startYear = 2000;
        job2._endYear = 2024;

        Job job3 = new Job();
        job3._title = "Figther";
        job3._company = "UFC";
        job3._startYear = 1990;
        job3._endYear = 2024;

        Resume resume = new Resume();
        resume._name = "Guilherme Medeiros";

        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume._jobs.Add(job3);

        resume.Display();
    }
}