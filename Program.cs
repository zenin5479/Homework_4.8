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
            int[,] inputArray = ClassFor2DArray.InputArrayInt(sourceOne, rowOne, columnOne);
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

            SplittingLines(inputArray, multipleElement, nameFileTwo);
         }

         Console.ReadKey();
      }

      static void SplittingLines(int[,] input, int multiple, string nameFile)
      {
         int[] lines = new int[input.GetLength(1)];
         int i = 0;
         while (i < input.GetLength(0))
         {
            int j = 0;
            while (j < input.GetLength(1))
            {
               lines[j] = input[i, j];
               j++;
            }

            if (SearchingMultiple(lines, multiple))
            {
               string line = "В массиве найдена строка " + (i + 1) + " с элементом, кратным " + multiple;
               Console.WriteLine(line);
               ClassFor2DArray.FileAppendStringArray(line, nameFile);
            }

            Array.Clear(lines, 0, lines.Length);
            i++;
         }
      }

      static bool SearchingMultiple(int[] lines, int multiple)
      {
         int i = 0;
         while (i < lines.Length)
         {
            if (lines[i] % multiple == 0)
            {
               return true;
            }

            i++;
         }

         return false;
      }
   }
}