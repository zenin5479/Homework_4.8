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

         string nameOne = "A";
         string nameFileOne = "a.txt";
         string nameFileFour = "finish.txt";

         int rowOne = VariousMethods.SizeRow(nameOne);
         int columnOne = VariousMethods.SizeColumn(nameOne);
        
         string pathOne = Path.GetFullPath(nameFileOne);

         double minOne = 0;
         double[,] sourceOne = VariousMethods.VvodArray(pathOne, nameFileOne);
         if (sourceOne.GetLength(0) == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFileOne);
         }
         else
         {
            double[,] searchOne = VariousMethods.InputArray(sourceOne, rowOne, columnOne, nameOne);
            bool flOne = VariousMethods.SearchingPositiv(searchOne);
            if (flOne)
            {
               Console.WriteLine("В двумерном массиве {0} нет искомых положительных элементов", nameOne);
            }
            else
            {
               minOne = VariousMethods.SearchingMinPositiv(searchOne, nameOne);
            }
         }

         double result = VariousMethods.CalculatingValue(minOne, minTwo, minThree);
         Console.WriteLine("Результат Amin * Bmin – Cmin: {0}", result);
         //Console.WriteLine("Результат Amin * Bmin – Cmin: {0:f2}", result);
         //Console.WriteLine("Результат Amin * Bmin – Cmin: {0:f}", result);

         string[] stringArray = VariousMethods.VivodString(result);
         string pathFour = Path.GetFullPath(nameFileFour);
         if (!File.Exists(pathFour))
         {
            Console.WriteLine("Файл {0} не существует. Создаем новый", nameFileFour);
            File.Create(pathFour);
         }
         else
         {
            // Очищаем содержимое файла
            Console.WriteLine("Файл {0} содержит предыдущие результаты. Очищаем данные", nameFileFour);
            File.Create(pathFour).Close();
         }

         VariousMethods.FileWriteString(stringArray, nameFileFour);
         Console.ReadKey();
      }
   }
}