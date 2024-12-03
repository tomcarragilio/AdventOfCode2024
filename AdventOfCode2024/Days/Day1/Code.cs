namespace AdventOfCode2024.Days.Day1;

public static class Shared
{
    public static async Task<(List<int>, List<int>)> GetLists()
    {
        var input = await File.ReadAllLinesAsync("Days/Day1/input.txt");
        var list1 = input.Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0].Trim())).Order()
            .ToList();
        var list2 = input.Select(x => int.Parse(x.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1].Trim())).Order()
            .ToList();
        
        return (list1, list2);
    }
}

public static class Part1
{
    public static async Task<int> Run()
    {
        var (list1, list2) = await Shared.GetLists();
        
        return list1.Select((t, i) => Math.Abs(t - list2[i])).Sum();
    }
}

public static class Part2
{
    public static async Task<int> Run()
    {
        var (list1, list2) = await Shared.GetLists();
        var similarityScore = list1.Sum(i => list2.Count(x => x == i) * i);
        
        return similarityScore;
    }
}