using System.Text.RegularExpressions;

namespace AdventOfCode2024.Days.Day3;

public static class Shared
{
    public const string Pattern = @"mul\((-?\d+),(-?\d+)\)";
    public static async Task<string> GetCode()
    {
        var lines = await File.ReadAllLinesAsync("Days/Day3/input.txt");

        return string.Join("", lines);
    }
}

public static class Part1
{
    public static async Task<int> Run()
    {
        var code = await Shared.GetCode();
        var matches = Regex.Matches(code, Shared.Pattern);

        return matches
            .Sum(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value));
    }
}

public static class Part2
{
    public static async Task<int> Run()
    {
        var code = await Shared.GetCode();

        return code.Split("do()")
            .Select(x => x.Split("don't()")[0])
            .SelectMany(x => Regex.Matches(x, Shared.Pattern)
                .Select(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value)))
            .Sum();
    }
}