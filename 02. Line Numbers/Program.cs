using System;

namespace LineNumbers;

public class LineNumbers
{
    static void Main()
    {
        string inputFilePath = @"..\..\..\text.txt";
        string outputFilePath = @"..\..\..\output.txt";

        ProcessLines(inputFilePath, outputFilePath);
    }
    public static void ProcessLines(string inputFilePath, string outputFilePath)
    {
        File.ReadAllLines(inputFilePath);
        {
            using StreamReader reader = new StreamReader(inputFilePath);

            int counter = 0;
            using StreamWriter writer = new StreamWriter(outputFilePath);
            while (reader.EndOfStream != true)
            {
                string line = reader.ReadLine();
                int letterCounter = line.Count(ch => char.IsLetter(ch));
                int punctuationMarksCounter = 0;
                foreach (var ch in line)
                {
                    if (char.IsPunctuation(ch))
                    {
                        punctuationMarksCounter++;
                    }
                }
                counter++;

                writer.WriteLine($"Line {counter}: {line} ({letterCounter})({punctuationMarksCounter})");
            }

        }
    }
}