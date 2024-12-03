namespace AdventOfCode2024.Days.Day2;

public static class Shared
{
    public static async Task<List<List<int>>> GetReports()
    {
        var input = await File.ReadAllLinesAsync("Days/Day2/input.txt");
        return input.Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList())
            .ToList();
    }

    public static bool IsSafeReport(List<int> report)
    {
        var ascending = report[1] > report[0];

        for (var i = 0; i < report.Count - 1; i++)
            if ((ascending && report[i + 1] <= report[i]) ||
                (!ascending && report[i + 1] >= report[i]) ||
                Math.Abs(report[i] - report[i + 1]) > 3)
                return false;

        return true;
    }
}

public static class Part1
{
    public static async Task<int> Run()
    {
        var reports = await Shared.GetReports();
        return reports.Count(Shared.IsSafeReport);
    }
}

public static class Part2
{
    public static async Task<int> Run()
    {
        var reports = await Shared.GetReports();
        var unsafeReports = reports.Where(x => !Shared.IsSafeReport(x)).ToList();
        var additionalSafeReports = unsafeReports.Count(unsafeReport => unsafeReport
            .Select((_, i) => unsafeReport.Where((_, index) => index != i).ToList())
            .Where((_, i) => Shared.IsSafeReport(unsafeReport.Where((_, index) => index != i).ToList()))
            .Any());

        return reports.Count(Shared.IsSafeReport) + additionalSafeReports;
    }
}