using SixLabors.ImageSharp;
using System;
using System.IO;
using System.Linq;


namespace JpgToPngConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Массовый конвертер JPG в PNG";
            Console.WriteLine("=== Массовый конвертер изображений (JPG -> PNG) ===");

            // 1. Запрашиваем путь к папке
            Console.Write("\nВведите путь к папке с JPG-файлами: ");
            string? inputFolder = Console.ReadLine()?.Trim('"'); // Убираем кавычки, если путь скопирован как путь

            if (string.IsNullOrWhiteSpace(inputFolder) || !Directory.Exists(inputFolder))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: Указанная папка не существует.");
                Console.ResetColor();
                return;
            }

            // 2. Ищем все файлы с расширениями .jpg и .jpeg
            var extensions = new[] { "*.jpg", "*.jpeg" };
            var files = extensions
                .SelectMany(ext => Directory.GetFiles(inputFolder, ext, SearchOption.TopDirectoryOnly))
                .ToArray();

            if (files.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("В указанной папке не найдено файлов с расширением .jpg или .jpeg");
                Console.ResetColor();
                return;
            }

            // 3. Создаем целевую папку внутри исходной
            string outputFolder = Path.Combine(inputFolder, "Converted_PNG");
            try
            {
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Не удалось создать папку для сохранения: {ex.Message}");
                Console.ResetColor();
                return;
            }

            Console.WriteLine($"\nНайдено файлов для обработки: {files.Length}");
            Console.WriteLine($"Результаты будут сохранены в: {outputFolder}\n");
            Console.WriteLine("Начало конвертации...");

            int successCount = 0;
            int failCount = 0;

            // 4. Процесс конвертации
            for (int i = 0; i < files.Length; i++)
            {
                string currentFile = files[i];
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(currentFile);
                string outputFilePath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                Console.Write($"[{i + 1}/{files.Length}] Обработка: {Path.GetFileName(currentFile)}... ");

                try
                {
                    // Загружаем изображение и сохраняем в формате PNG
                    using (Image image = Image.Load(currentFile))
                    {
                        image.SaveAsPng(outputFilePath);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Успешно");
                    Console.ResetColor();
                    successCount++;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка ({ex.Message})");
                    Console.ResetColor();
                    failCount++;
                }
            }

            // 5. Итоги работы
            Console.WriteLine("\n========================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Конвертация завершена!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Успешно конвертировано: {successCount}");
            if (failCount > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибок при обработке: {failCount}");
            }
            Console.ResetColor();
            Console.WriteLine("========================================");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}