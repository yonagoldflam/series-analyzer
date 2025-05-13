using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Example
{
    class Program()
    {
        static void Main(string[] args)
        {
            Manu(args);
        }

        static void Manu(string[] stringArr)
        {            
            int[] series = ConversionToIntArray(stringArr);
            if (!CheckNums(series) || !AtLeast3PositiveNumbers(series))
            {
                series = GetSeriesAndConvertToIntArray();
            }
            bool clickedExit = false;
            while (!clickedExit)
            {
                PrintMenu();
                string choose = GetChoice();
                switch (choose)
                {
                    case "a":
                        series = GetSeriesAndConvertToIntArray();
                        break;

                    case "b":
                        PrintSeries(series);
                        break;

                    case "c":
                        PrintSeries(Reverse(series));
                        break;

                    case "d":
                        PrintSeries(BubbleSort(series));
                        break;

                    case "e":
                        Console.WriteLine(MaxValue(series));
                        break;

                    case "f":
                        Console.WriteLine(MinValue(series));
                        break;

                    case "g":
                        Console.WriteLine(Average(series));
                        break;

                    case "h":
                        Console.WriteLine(Len(series));
                        break;

                    case "i":
                        Console.WriteLine(Sum(series));
                        break;

                    case "j":
                        clickedExit = true;
                        break;

                    default:
                        Console.WriteLine("Your choose does not match the rules, please choice again.");
                        break;

                }
            }
        }

        static int[] GetSeriesAndConvertToIntArray()
        {
            while (true) //runs until valid input is received.
            {
                Console.WriteLine(SeriesInputInstructions());
                string userInput = Console.ReadLine();
                string[] stringArray = ConversionToStringArray(userInput);
                int[] intArray = ConversionToIntArray(stringArray);
                if (!CheckNums(intArray))
                {
                    Console.WriteLine("Your input does not contain only digits.");
                    continue;
                }
                else if (!AtLeast3PositiveNumbers(intArray))
                {
                    Console.WriteLine("Your input does not contain at least three positive digits.");
                    continue;
                }
                return intArray;
            }

        }

        
        static int Len(int[] intArray)
        {
            int counter = 0;
            foreach (int i in intArray)
            {
                counter++;
            }
            return counter;
        }

        
        static int Len(string[] intArray)
        {
            int counter = 0;
            foreach (string i in intArray)
            {
                counter++;
            }
            return counter;
        }

        
        static string[] ConversionToStringArray(string input)
        {
            return input.Split(',', ' ');
        }
        
        
        static int[] ConversionToIntArray(string[] input)
        {
            int[] result = new int[Len(input)];
            for (int i = 0; i < input.Length; i++)
            {
                bool isNum = int.TryParse(input[i], out result[i]);
                if (!isNum)
                {
                    return [];
                }
            }
            return result;
        }

        
        static bool AtLeast3PositiveNumbers(int[] input)
        {
            bool isPositiveNumber;
            int counter = 0;
            foreach (int i in input)
            {
                isPositiveNumber = i > 0 ? true : false;
                if (isPositiveNumber)
                {
                    counter++;
                }
                else
                {
                    return false;
                }
            }
            return counter > 2;
        }

        
        static void PrintMenu()
        {
            string txtMenu = "press a to Input a Series." +
                            "\npress b to Display the series in the order it was entered." +
                            "\npress c to Display the series in the reversed order it was entered." +
                            "\npress d to Display the series in sorted order (from low to high)." +
                            "\npress e to Display the Max value of the series." +
                            "\npress f to Display the Min value of the series." +
                            "\npress g to Display the Average of the series." +
                            "\npress h to Display the Number of elements in the series." +
                            "\npress i to Display the Sum of the series." +
                            "\npress j to Exit.";
            Console.WriteLine(txtMenu);
        }


        static string GetChoice()
        {
            var choose = Console.ReadLine();
            return choose != null ? choose : "aa";
        }

        
        static void PrintSeries(int[] intArray)
        {
            foreach (int i in intArray)
            {
                Console.WriteLine(i);
            }
        }
        
        
        static int[] Reverse(int[] intArray)
        {
            int[] reversedArr = new int[Len(intArray)];
            int tup = 0;
            for (int i = Len(intArray) - 1; i >= 0; i--)
            {
                reversedArr[tup] = intArray[i];
                tup++;
            }
            return reversedArr;
        }

        
        static int[] BubbleSort(int[] intArray)
        {
            for (int i = 0; i < Len(intArray); i++)
            {
                bool flag = true;
                for (int j = 0; j < Len(intArray) - i - 1; j++)
                {
                    if (intArray[j] > intArray[j + 1])
                    {
                        int temp = intArray[j];
                        intArray[j] = intArray[j + 1];
                        intArray[j + 1] = temp;
                        flag = false;
                    }
                }
                if (flag)
                {
                    return intArray;
                }

            }
            return intArray;
        }

        
        static int MaxValue(int[] intArray)
        {
            int max = intArray[0];
            foreach (int i in intArray)
            {
                max = i > max ? i : max;
            }
            return max;
        }

        
        static int MinValue(int[] intArray)
        {
            int min = intArray[0];
            foreach (int i in intArray)
            {
                min = i < min ? i : min;
            }
            return min;
        }

        
        static double Average(int[] intArray)
        {

            double len = Len(intArray);
            return Sum(intArray) / len;
        }

        
        static int Sum(int[] intArray)
        {
            int sum = 0;
            foreach (int i in intArray)
            {
                sum += i;
            }
            return sum;
        }
        
        static bool CheckNums(int[] intArr)
        {
            return Len(intArr) > 0;
        }


        static string SeriesInputInstructions()
        {
            string ruls = "Enter a series of numbers; please note the rules:" + 
                          "\n1. Enter only positive numbers" + 
                          "\n2. Enter at least 3 numbers" +
                          "\n3. Separate values ​​only with a comma **or** a space";
            return ruls;
        }
    }
}







