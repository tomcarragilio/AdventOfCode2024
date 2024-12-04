namespace AdventOfCode2024.Days.Day4;

public static class Shared
{
    public static async Task<List<string>> GetLines()
    {
        var lines = await File.ReadAllLinesAsync("Days/Day4/input.txt");
        return lines.ToList();
    }
}

public static class Part1
{
    public static async Task<int> Run()
    {
        var lines = await Shared.GetLines();
        var rows = lines.Count;
        var cols = lines[0].Length;

        var count = 0;
        const string target = "XMAS";

        var directions = new List<(int dx, int dy)>
        {
            (1, 0), // East
            (1, 1), // Southeast
            (0, 1), // South
            (-1, 1), // Southwest
            (-1, 0), // West
            (-1, -1), // Northwest
            (0, -1), // North
            (1, -1) // Northeast
        };

        foreach (var y in Enumerable.Range(0, rows))
        {
            foreach (var x in Enumerable.Range(0, cols))
            {
                foreach (var (dx, dy) in directions)
                {
                    var positions = Enumerable.Range(0, 4)
                        .Select(i => (x: x + i * dx, y: y + i * dy))
                        .ToList();

                    if (!positions.All(pos => IsValid(pos.x, pos.y))) continue;
                    {
                        var str = new string(positions.Select(pos => lines[pos.y][pos.x]).ToArray());
                        if (str == target) count++;
                    }
                }
            }
        }

        return count;

        bool IsValid(int x, int y) => x >= 0 && x < cols && y >= 0 && y < rows;
    }
}

public static class Part2
{
    public static async Task<int> Run()
    {
        var lines = await Shared.GetLines();
        var rows = lines.Count;
        var cols = lines[0].Length;

        return Enumerable.Range(0, rows)
            .Sum(y => Enumerable.Range(0, cols)
                .Count(x => 
                    x > 0 && y > 0 && x < cols - 1 && y < rows - 1 &&
                    lines[y][x] == 'A' &&
                    (
                        (lines[y - 1][x - 1] == 'M' && lines[y + 1][x + 1] == 'S') ||
                        (lines[y - 1][x - 1] == 'S' && lines[y + 1][x + 1] == 'M')
                    ) &&
                    (
                        (lines[y + 1][x - 1] == 'M' && lines[y - 1][x + 1] == 'S') ||
                        (lines[y + 1][x - 1] == 'S' && lines[y - 1][x + 1] == 'M')
                    )
                )
            );
    }
}
