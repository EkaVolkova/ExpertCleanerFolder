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
    static class ExpertCleaner
    {
        /// <summary>
        /// Удаляет папки и файлы, которые не использовались более 30 минут
        /// </summary>
        /// <param name="path">путь до папки</param>
        /// <returns>освобожденное на диске место</returns>
        static public long CleanerFolder(string path)
        {
            //количество удаленных байт памяти
            long sumDelited = 0;

            //Проверка, что путь задан
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Не задана директория");

            //Создали экземпляр класса для работы с директорией
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            //ПРоверили, что директория существует
            if (!directoryInfo.Exists)
                throw new ArgumentException("Папка не существует");

            //Выгрузили информацию по всем файлам в директории
            var files = directoryInfo.GetFiles();
            //Проверили время последнего использования по каждому файлу и удалили старые
            foreach (var file in files)
            {
                if (file.LastAccessTime + TimeSpan.FromMinutes(30) < DateTime.Now)
                {
                    sumDelited += file.Length;
                    file.Delete();
                }
            }

            //Выгрузили информацию по всем директориям в директории
            var directories = directoryInfo.GetDirectories();

            foreach (var directory in directories)
            {
                //для каждой директории запустили очиститель (чтобы удалить файлы и папки внутри)
                sumDelited += CleanerFolder(directory.FullName);

                //Проверили время последнего использования по каждой директории и удалили старые
                if (directory.LastAccessTime + TimeSpan.FromMinutes(30) < DateTime.Now)
                {
                    directory.Delete();
                }

            }
            return sumDelited;

        }

    }

}
