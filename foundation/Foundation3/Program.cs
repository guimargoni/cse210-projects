using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 4), 45, 15.0),
            new Swimming(new DateTime(2022, 11, 5), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            SaveActivityToJson(activity);
        }
    }

    static void SaveActivityToJson(Activity activity)
    {
        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(activity, jsonOptions);
        string fileName = $"{activity.GetType().Name}_{activity.Date:yyyyMMdd}.json";

        File.WriteAllText(fileName, json);
        Console.WriteLine($"Saved {activity.GetType().Name} details to {fileName}");
    }
}