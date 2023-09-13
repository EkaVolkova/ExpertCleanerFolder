using System;
using System.IO;

/// <summary>
/// При запуске программа должна:
/// Показать, сколько весит папка до очистки. Использовать метод из задания 2. 
/// Выполнить очистку.
/// Показать сколько файлов удалено и сколько места освобождено.
/// Показать, сколько папка весит после очистки.
/// </summary>
namespace ExpertCleanerFolder
{
    static class SizeFolder
    {
        /// <summary>
        /// Подсчитывает размер папки в байтах
        /// </summary>
        /// <param name="path"></param>
        /// <returns>количество байт, занимаемых содержимым папки</returns>
        static public long GetSizeFolder(string path)
        {
            //Проверка, что путь задан
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Не задана директория");

            //Создали экземпляр класса для работы с директорией
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            //ПРоверили, что директория существует
            if (!directoryInfo.Exists)
                throw new ArgumentException("Папка не существует");

            long sum = 0;
            //Выгрузили информацию по всем файлам в директории
            var files = directoryInfo.GetFiles();
            //Просуммировали размеры файлов
            foreach (var file in files)
            {
                sum += file.Length;
            }
            //Выгрузили информацию по всем директориям в директории
            var directories = directoryInfo.GetDirectories();

            foreach (var directory in directories)
            {
                //для каждой директории запустили программу расчета размера
                sum += GetSizeFolder(directory.FullName);

            }
            return sum;
        }
    }

}
