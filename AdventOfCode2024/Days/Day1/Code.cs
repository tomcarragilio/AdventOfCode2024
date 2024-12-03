namespace AdventOfCode2024.Days.Day1;

public class Part1
{
    public static async Task<int> Run()
    {
        var input = await File.ReadAllLinesAsync("Days/Day1/input.txt");
        var list1 = input.Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0].Trim())).Order().ToList();
        var list2 = input.Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1].Trim())).Order().ToList();

        var totalDistance = 0;
        
        for(var i = 0; i < list1.Count(); i++)
        {
            totalDistance += Math.Abs(list1[i] - list2[i]);
        }
        
        return totalDistance;
    }
}