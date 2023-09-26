﻿namespace CopyBinaryFile
{
    using System;
    public class CopyBinaryFile
    {
        static void Main() 
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";
            CopyFile(inputFilePath, outputFilePath);
        }
        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
           using FileStream read = new FileStream(inputFilePath, FileMode.Open);
           using FileStream write = new FileStream(outputFilePath, FileMode.Create);
           byte[] buffer = new byte[1024];
           int size = 0;

           while ((size = read.Read(buffer, 0, buffer.Length)) != 0)
           {
                write.Write(buffer, 0, size);
           }

        }
    } 
}