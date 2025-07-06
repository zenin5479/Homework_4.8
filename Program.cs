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
               File.Create(pathTwo).Close();
            }
            else
            {
               // Очищаем содержимое файла
               File.Create(pathTwo).Close();
            }

            ClassFor2DArray.SplittingLines(inputArray, multipleElement, nameFileTwo);
         }

         Console.ReadKey();
      }
   }
}