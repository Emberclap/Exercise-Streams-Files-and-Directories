namespace DirectoryTraversal
{
    using System;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main() 
        {
            string path = Console.ReadLine(); 
            string reportFileName = @"\report.txt"; 
            string reportContent = TraverseDirectory(path); 
            Console.WriteLine(reportContent); 
            WriteReportToDesktop(reportContent, reportFileName); 
        }
        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> exttensionsFiles = new SortedDictionary<string, List<FileInfo>>();
            string[] files = Directory.GetFiles(inputFolderPath);
            
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!exttensionsFiles.ContainsKey(fileInfo.Extension))
                {
                    exttensionsFiles.Add(fileInfo.Extension, new List<FileInfo>());
                }
            }
            StringBuilder stringBuilder = new StringBuilder();

           
            foreach (var exttensionFiles in exttensionsFiles.OrderByDescending(ef=> ef.Value.Count))
            {
                stringBuilder.AppendLine(exttensionFiles.Key);

                foreach (var file in exttensionFiles.Value.OrderBy(f => f.Length))
                {
                    stringBuilder.AppendLine($"-{file.Name} - {(double)file.Length / 1024:f3}kb");
                }
            }
            return stringBuilder.ToString().TrimEnd();
        }

        
        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + reportFileName;
            File.WriteAllText(filePath, textContent);
        } 
    }
}