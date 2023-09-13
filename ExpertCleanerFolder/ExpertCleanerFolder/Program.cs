using System;

/// <summary>
/// При запуске программа должна:
/// Показать, сколько весит папка до очистки. Использовать метод из задания 2. 
/// Выполнить очистку.
/// Показать сколько файлов удалено и сколько места освобождено.
/// Показать, сколько папка весит после очистки.
/// </summary>
namespace ExpertCleanerFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var size = SizeFolder.GetSizeFolder(args[0]);
                Console.WriteLine("Исходный размер папки: " + size);
                var delited = ExpertCleaner.CleanerFolder(args[0]);
                Console.WriteLine("Освобождено места: " + delited);
                var newSize = SizeFolder.GetSizeFolder(args[0]);
                Console.WriteLine("Текущий размер папки: " + newSize);
            }
            catch (Exception ex)
            {
                //Выводим текст исключения в консоль
                Console.WriteLine("Ошибка расчета: " + ex.Message);
            }
            Console.ReadKey();
        }
    }

}
