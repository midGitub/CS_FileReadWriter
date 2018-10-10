using System;
using System.IO;
using System.Text;

public static class FileReadWriter
{
    public class Result
    {
        public bool success;
        public string content;
    }

    public static FileReadWriter.Result WriteFile(string filePath, string content)
    {
        return WriteFile(filePath, content, Encoding.UTF8);
    }

    public static FileReadWriter.Result WriteFile(string filePath, string content, Encoding encoding, bool createDirectory = true)
    {
        string directoryPath = Path.GetDirectoryName(filePath);

        if (Directory.Exists(directoryPath) == false)
        {
            if (createDirectory)
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, encoding))
            {
                writer.WriteLine(content);
            }
            return new FileReadWriter.Result()
            {
                success = true,
                content = content,
            };
        }
        catch (Exception exception)
        {
            return new FileReadWriter.Result()
            {
                success = false,
                content = exception.Message,
            };
        }
    }

    public static FileReadWriter.Result ReadFile(string filePath)
    {
        return ReadFile(filePath, Encoding.UTF8);
    }

    public static FileReadWriter.Result ReadFile(string filePath, Encoding encoding)
    {
        try
        {
            FileInfo fileInfo = new FileInfo(filePath);
            string content;

            using (StreamReader reader = new StreamReader(fileInfo.OpenRead(), encoding))
            {
                content = reader.ReadToEnd();
            }

            return new FileReadWriter.Result()
            {
                success = true,
                content = content
            };
        }
        catch (Exception exception)
        {
            return new FileReadWriter.Result()
            {
                success = false,
                content = exception.Message
            };
        }
    }

    public static string ToRelativePath(string filePath)
    {
        if (filePath == null || filePath.Length == 0)
        {
            return "/";
        }

        if (filePath[0] == '/')
        {
            return filePath;
        }
        else
        {
            return "/" + filePath;
        }
    }
}