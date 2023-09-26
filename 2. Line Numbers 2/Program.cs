using System;
using System.Text;

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
        StringBuilder stringBuilder = new StringBuilder();

        string[] lines= File.ReadAllLines(inputFilePath);

        for (int i = 0; i < lines.Length; i++)   
        {
            int letterCount = lines[i].Count(ch =>char.IsLetter(ch));
            int punctuationCount = lines[i].Count(ch =>char.IsPunctuation(ch));
            stringBuilder.AppendLine($"Line {i+1}: {lines[i]} ({letterCount})({punctuationCount})");
        }
        File.WriteAllText(outputFilePath, stringBuilder.ToString().TrimEnd());

    }
}