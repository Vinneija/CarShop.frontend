using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;


namespace CarShop.Library
{
    private const string FileName = "TestData.txt";
    private const string SourcePath = @"C:\CarFileOperatorFiles\";
    private const string TargetPath = @"C:\CarFileOperatorFiles\targetPath";
    private const string FilePath = @"C:\CarFileOperatorFiles\TestData.txt";

    public static void Main(string[] args)
    {
        try
        {
            //CreateDirectoryIfNotExists();
            //CreateFileIfNotExists();
            //GetAllDirectories();
            //GetAllFilesInDirectory();
            //GetFileInfo();
            RewriteFileAndNewLine();
            //WriteBytesToFile();
            //ReadFileWithStream();
        }
        catch (DirectoryNotFoundException exception)
        {
            Console.WriteLine("Exception message: " + exception);
        }
        catch (FileLoadException exception)
        {
            Console.WriteLine("Exception message: " + exception);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine("Exception message: " + exception);
        }
        catch (Exception exception)
        {
            Console.WriteLine("Exception message: " + exception);
        }

        Console.ReadLine();
    }

    private static void CreateDirectoryIfNotExists()
    {
        if (!Directory.Exists(TargetPath))
        {
            Directory.CreateDirectory(TargetPath);
        }
    }

    public static void CreateFileIfNotExists()
    {
        if (!File.Exists(FilePath))
        {
            File.Create(FilePath);
        }
    }

    public static void WritingAllFileText()
    {
        string fileContent = "Line 1: Please choose car operation:\nLine 2: 1.Add car to the shop\nLine 3: 2. Find car by is available\nLine 4: 3. Find car by year\n Line 5: 4. Show list of all presented cars\nLine 6: 5. Buy a car";

        File.WriteAllText(FilePath, fileContent);// writes content to file
    }

    public static void WriteAllFileLines()
    {
        string[] stringArray = { "Line 1", "Line 2", "Line 3", "Line 4", "Line 5", "Line 6" };

        File.WriteAllLines(FilePath, stringArray);// writes array item to file
    }

    public static void WriteBytesToFile()
    {
        string content = "Id\nModel\nYear\nColor\nSold\nIsAvailable";
        var contentInBytes = Encoding.ASCII.GetBytes(content);

        using (FileStream fileStream = File.OpenWrite(FilePath))
        {
            fileStream.Write(contentInBytes, 0, contentInBytes.Length);
        }
    }

    public static void ConvertStringToBytesAndWriteDataToFile()
    {
        string text = "Id, Model, Year, Color, Sold, IsAvailable";
        byte[] data = Encoding.ASCII.GetBytes(text);

        File.WriteAllBytes(FilePath, data);//Creates a new file if not exists
    }

    public static void DeleteFileIfExists()
    {
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
        }
    }

    public static void GetAllDirectories()
    {
        Directory.GetDirectories(SourcePath).ToList().ForEach(Console.WriteLine);
        Console.WriteLine(Environment.NewLine);
    }

    public static void GetAllFilesInDirectory()
    {
        Directory.GetFiles(SourcePath).ToList().ForEach(Console.WriteLine);
        Console.WriteLine(Environment.NewLine);
    }

    public static void GetFileInfo()
    {
        var file = new FileInfo(FilePath);

        var info = @$"  
                        File directory: {file.Directory}
                        File name: {file.Name}
                        File extension: {file.Extension}
                        File size: {file.Length}
                        File creation time: {file.CreationTime}";

        Console.WriteLine(info + Environment.NewLine);
    }

    public static void ReadAllFileText()
    {
        var fileContent = File.ReadAllText(FilePath);
        Console.WriteLine(fileContent);
    }

    public static void ReadTextByLines()
    {
        foreach (var line in File.ReadLines(FilePath))
        {
            Console.WriteLine(line);
        }
    }

    public static void ReadFileWithStream()
    {
        using (FileStream fileStream = File.OpenRead(FilePath))
        {
            byte[] bytes = new byte[1024];
            var temp = new UTF8Encoding(true);

            while (fileStream.Read(bytes, 0, bytes.Length) > 0)
            {
                Console.WriteLine(temp.GetString(bytes));
            }
        }
    }

    public static void AppendStringToFile()
    {
        var stringContent = "Appended line";

        using (StreamWriter streamWriter = File.AppendText(FilePath))
        {
            streamWriter.WriteLine(Environment.NewLine + stringContent);
        }
    }

    public static void RewriteFileAndNewLine()
    {
        var list = File.ReadLines(FilePath).ToCarList();

        CarList.Add("New added line");

        File.WriteAllLines(FilePath, CarList);
    }

}


