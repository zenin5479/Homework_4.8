using System;
using System.IO;

// Разработать программу для обработки двумерного массива
// При выполнении задания необходимо разработать подпрограмму,
// получающую в качестве исходных данных одномерный массив
// В качестве этого одномерного массива необходимо передавать одну строку исходного массива
// Выбрать подходящий тип подпрограмм
// Использовать досрочный выход из цикла при реализации и программы, и подпрограммы
// Предусмотреть случай, когда в исходном массиве искомых значений нет
// Для проверки программы разработать тесты, охватывающие все возможные случаи
// Проверить, есть ли в целочисленном двумерном массиве хотя бы одна строка,
// содержащая элемент, кратный заданному числу, и найти её номер

namespace Homework_4._8
{
   internal class Program
   {
      static void Main(string[] args)
      {
         // Переводит (,) в (.)
         //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

         // Написать перегрузки методов без названия массива
         // linewise - построчно
         // multipleElement - кратный элемент
         // splittingLines - разделение на строки
         string nameFileOne = "a.txt";
         string nameFileTwo = "finish.txt";

         int rowOne = ClassFor2DArray.SizeRow();
         int columnOne = ClassFor2DArray.SizeColumn();
         int multipleElement = ClassFor2DArray.MultipleElement();

         string pathOne = Path.GetFullPath(nameFileOne);

         int[,] sourceOne = ClassFor2DArray.EnterArrayInt(pathOne, nameFileOne);
         if (sourceOne.GetLength(0) == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFileOne);
         }
         else
         {
            SplittingLines(sourceOne, multipleElement);

            bool flOne = ClassFor2DArray.SearchingPositivInt(sourceOne);
            if (flOne)
            {
               Console.WriteLine("В двумерном массиве нет искомых положительных элементов");
            }
            else
            {

            }
         }

         string pathTwo = Path.GetFullPath(nameFileTwo);
         if (!File.Exists(pathTwo))
         {
            Console.WriteLine("Файл {0} не существует. Создаем новый", nameFileTwo);
            File.Create(pathTwo);
         }
         else
         {
            // Очищаем содержимое файла
            File.Create(pathTwo).Close();
         }

         Console.ReadKey();
      }

      static void SplittingLines(int[,] source, int multiple)
      {
         // Добавить массив для строки, заполнить его значения исходного массива и передать в метод SearchingMultiple
         int[] ar = new int[source.GetLength(1)];
         int i = 0;
         while (i < source.GetLength(0))
         {
            int j = 0;
            while (j < source.GetLength(1))
            {
               ar[j] = source[i, j];
            }


            if (SearchingMultiple(ar, multiple))
            {
               //fprintf(f, "В массиве найдена строка %d с элементом, кратным %d\n", i + 1, t);
            }

            i++;
         }
      }

      static bool SearchingMultiple(int[] lines, int t)
      {
         // Обновить до while
         for (int j = 0; j < lines.Length; j++)
         {
            if (lines[j] % t == 0)
            {
               return true;
            }
         }
         return false;
      }

      //bool find_kratnost(int* x, int m, int t)
      //{
      //   for (int j = 0; j < m; j++)
      //   {
      //      if (x[j] % t == 0)
      //      {
      //         return true;
      //      }
      //   }
      //   return false;
      //}

      //void perexod(int** x, int n, int m, int t, FILE* f)
      //{
      //   for (int i = 0; i < n; i++)
      //   {
      //      if (find_kratnost(x[i], m, t))
      //      {
      //         fprintf(f, "В массиве найдена строка %d с элементом, кратным %d\n", i + 1, t);
      //      }
      //   }
      //}
   }
}