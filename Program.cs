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
         string nameOne = "A";
         string nameFileOne = "a.txt";
         string nameFileTwo = "finish.txt";

         int rowOne = ClassFor2DArray.SizeRow(nameOne);
         int columnOne = ClassFor2DArray.SizeColumn(nameOne);
         string pathOne = Path.GetFullPath(nameFileOne);

         int[,] sourceOne = ClassFor2DArray.EnterArrayInt(pathOne, nameFileOne);
         if (sourceOne.GetLength(0) == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFileOne);
         }
         else
         {
            int[,] searchOne = ClassFor2DArray.InputArrayInt(sourceOne, rowOne, columnOne, nameOne);
            bool flOne = ClassFor2DArray.SearchingPositivInt(searchOne);
            if (flOne)
            {
               Console.WriteLine("В двумерном массиве {0} нет искомых положительных элементов", nameOne);
            }
            else
            {

            }
         }

         //string[] stringArray = ClassFor2DArray.VivodString(result);
         string pathFour = Path.GetFullPath(nameFileTwo);
         if (!File.Exists(pathFour))
         {
            Console.WriteLine("Файл {0} не существует. Создаем новый", nameFileTwo);
            File.Create(pathFour);
         }
         else
         {
            // Очищаем содержимое файла
            File.Create(pathFour).Close();
         }

         //ClassFor2DArray.FileWriteString(stringArray, nameFileFour);
         Console.ReadKey();
      }
   }
}