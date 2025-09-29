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
      static void Main()
      {
         string nameFileOne = "a.txt";
         string nameFileTwo = "finish.txt";

         int rowOne = MethodsForArray.SizeRow();
         int columnOne = MethodsForArray.SizeColumn();
         int multipleElement = MethodsForArray.MultipleElement();

         string pathOne = Path.GetFullPath(nameFileOne);
         int[,] sourceOne = MethodsForArray.EnterArrayInt(pathOne, nameFileOne);
         if (sourceOne.GetLength(0) == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFileOne);
         }
         else
         {
            int[,] inputArray = MethodsForArray.InputArrayInt(sourceOne, rowOne, columnOne);
            string pathTwo = Path.GetFullPath(nameFileTwo);
            File.Create(pathTwo).Close();
            MethodsForArray.SplittingLines(inputArray, multipleElement, nameFileTwo);
         }

         Console.ReadKey();
      }
   }
}