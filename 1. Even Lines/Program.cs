namespace EvenLines
{ using System;
    using System.Text;

    public class EvenLines
    { 
        static void Main()
        { 
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        } 
        public static string ProcessLines(string inputFilePath) 
        { 
           using StreamReader inputStreamReader = new StreamReader(inputFilePath);

            int counter = 0;
            StringBuilder text = new StringBuilder();
            char[] symbolToReplace = {'-', ',','.','!','?'};
            while (inputStreamReader.EndOfStream != true)
            {
                string line = inputStreamReader.ReadLine();
                if (counter % 2 == 0)
                {
                    
                    foreach (char symbol in symbolToReplace)
                    {
                        line = line.Replace(symbol, '@');
                    }
                    text.AppendLine(string.Join(" ", line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse()));
                    
                }
                counter++;
            }
            return text.ToString();
        } 
    }
}