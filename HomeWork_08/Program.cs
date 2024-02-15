using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //args = new string[2];
            if (args.Length != 2)
            {
                Console.WriteLine("Неверное количество аргументов.\nВведите 2 аргумента:");
                Console.WriteLine("1. Расширение файла без точки.\n" +
                    "2. Полный или частичный текст, который нужно найти.");
                Console.ReadKey();
            }
            else if (args[0] == "mkv" || args[0] == "mp4")
            {
                Console.WriteLine("Видеоформат != текстовый формат\nВведите тектовое расширение.");
                Console.ReadKey();
            }
            else
            {
                string currentDir = Directory.GetCurrentDirectory();

                string res = FindAllFilesWithSecifiedExtensionAndSpecifiedText(args[0], args[1], currentDir);

                Console.WriteLine(res != "" ? res : "Files not found!");
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Поиск файлов с указанным расширением и с указанном текстом, либо полным, либо частичным
        /// </summary>
        /// <param name="extension">Расширение файла</param>
        /// <param name="fileContent">Полный либо частичный текст, который нужно найти в файле</param>
        /// <param name="startDir">Стартовая директория поиска. 
        /// По умолчанию берется директория, откуда запускается приложение.</param>
        /// <returns>Возвращает информацию о найденных файлах</returns>
        static string FindAllFilesWithSecifiedExtensionAndSpecifiedText(string extension, string fileContent, string startDir)
        {
            string res = "";
            foreach (string name in Directory.GetFiles(startDir))
            {
                if (Path.GetExtension(name) == "." + extension)
                    using (StreamReader sr = new StreamReader(name))
                    {
                        string fileText = sr.ReadToEnd();
                        if (fileText.ToLower().Contains(fileContent.ToLower()))
                        {
                            return $"File \"{Path.GetFileName(name)}\" " +
                                $"with extension: {Path.GetExtension(name)} found!" +
                                $"\nDirectory: {startDir}" +
                                $"\nFile contents: {fileText}\n\n";
                        }
                    }
            }
            foreach (string directory in Directory.GetDirectories(startDir))
            {
                if (FindAllFilesWithSecifiedExtensionAndSpecifiedText(extension, fileContent, directory) != "")
                    res += FindAllFilesWithSecifiedExtensionAndSpecifiedText(extension, fileContent, directory);
            }
            return res;
        }
    }
}
