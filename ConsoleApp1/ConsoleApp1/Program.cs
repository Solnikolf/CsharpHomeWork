using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Required locked blocks
        string block45 = "45";
        string baseFgh = "fgh"; // will generate all case variants

        // Case variations of "fgh"
        List<string> fghVariants = GenerateCaseVariants(baseFgh);

        // Independent blocks (symbol blocks included as requested)
        List<string> otherBlocks = new List<string> { "7", "j", "J", "&", "*" };

        // Total number of permutations to track progress
        int totalPermutations = fghVariants.Count * GetTotalPermutationsCount(otherBlocks);
        int processed = 0;

        // Create output file
        using (StreamWriter writer = new StreamWriter("wordlist.txt"))
        {
            foreach (string fgh in fghVariants)
            {
                // Build the list of blocks to permute
                List<string> blocks = new List<string> { block45, fgh };
                blocks.AddRange(otherBlocks);

                // Generate permutations
                foreach (var perm in GetPermutations(blocks))
                {
                    writer.WriteLine(string.Join("", perm) + "#");

                    // Update progress bar
                    processed++;
                    DisplayProgress(processed, totalPermutations);
                }
            }
        }

        Console.WriteLine("\nDone! Wordlist saved as wordlist.txt");
    }

    // Generate all case combinations of a word (e.g., fgh -> fgh, Fgh, fGh...)
    static List<string> GenerateCaseVariants(string input)
    {
        List<string> results = new List<string>();
        int combinations = 1 << input.Length; // 2^n

        for (int mask = 0; mask < combinations; mask++)
        {
            char[] variant = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                bool upper = (mask & (1 << i)) != 0;
                variant[i] = upper ? char.ToUpper(input[i]) : input[i];
            }

            results.Add(new string(variant));
        }

        return results;
    }

    // Permutation generator for list of strings
    static IEnumerable<List<string>> GetPermutations(List<string> items)
    {
        if (items.Count == 1)
            yield return new List<string>(items);

        for (int i = 0; i < items.Count; i++)
        {
            string current = items[i];
            List<string> remaining = new List<string>(items);
            remaining.RemoveAt(i);

            foreach (var perm in GetPermutations(remaining))
            {
                perm.Insert(0, current);
                yield return perm;
            }
        }
    }

    // Calculate the total number of permutations (ignoring case)
    static int GetTotalPermutationsCount(List<string> blocks)
    {
        int total = 1;
        for (int i = 0; i < blocks.Count; i++)
        {
            total *= blocks.Count - i; // Simple factorial calculation
        }
        return total;
    }

    // Display a progress bar in the console
    static void DisplayProgress(int processed, int total)
    {
        int barWidth = 50;  // Width of the progress bar
        double percent = (double)processed / total;

        // Ensure the progress value is between 0 and 1 (no overflows or negative values)
        if (percent > 1.0) percent = 1.0;
        if (percent < 0.0) percent = 0.0;

        int progress = (int)(percent * barWidth);

        // Ensure that progress and remaining spaces are within bounds
        progress = Math.Max(0, Math.Min(progress, barWidth)); // Clamp the progress to [0, barWidth]
        int remaining = Math.Max(0, barWidth - progress);     // Ensure remaining blocks are non-negative

        // Create the progress bar string
        string progressBar = new string('#', progress) + new string('-', remaining);

        // Update the progress bar in the console
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write($"[{progressBar}] {percent * 100:0.00}%");
    }
}