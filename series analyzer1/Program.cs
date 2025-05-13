namespace Example
{
    class Program()
    {
        static void Main(string[] args)
        {
            manu(args);
        }

        static void manu(string[] stringArr)
        {
            int[] series = conversionToIntArray(stringArr);
            bool clickedExit = false;
            while (!clickedExit)
            {
                printMenu();
                string choose = getChoice();
                switch (choose)
                {
                    case "a":
                        series = getSeriesAndConvertToIntArray();
                        break;

                    case "b":
                        printSeries(series);
                        break;

                    case "c":
                        printSeries(reverse(series));
                        break;

                    case "d":
                        printSeries(bubbleSort(series));
                        break;

                    case "e":
                        Console.WriteLine(maxValue(series));
                        break;

                    case "f":
                        Console.WriteLine(minValue(series));
                        break;

                    case "g":
                        Console.WriteLine(average(series));
                        break;

                    case "h":
                        Console.WriteLine(len(series));
                        break;

                    case "i":
                        Console.WriteLine(sum(series));
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

        static int[] getSeriesAndConvertToIntArray()
        {
            while (true) //runs until valid input is received.
            {
                Console.WriteLine("Enter a series of numbers containing at least three positive numbers. *Please separate the numbers with a comma - ',' *");
                string text = Console.ReadLine();
                string[] stringArray = conversionToStringArray(text);
                int[] intArray = conversionToIntArray(stringArray);
                if (len(intArray) == 0)
                {
                    Console.WriteLine("Your input does not contain only digits.");
                    continue;
                }
                else if (!atLeast3PositiveNumbers(intArray))
                {
                    Console.WriteLine("Your input does not contain at least three positive digits.");
                    continue;
                }
                return intArray;
            }

        }

        
        static int len(int[] intArray)
        {
            int counter = 0;
            foreach (int i in intArray)
            {
                counter++;
            }
            return counter;
        }

        
        static int len(string[] intArray)
        {
            int counter = 0;
            foreach (string i in intArray)
            {
                counter++;
            }
            return counter;
        }

        
        static string[] conversionToStringArray(string input)
        {
            return input.Split(',');
        }
        
        
        static int[] conversionToIntArray(string[] input)
        {
            int[] result = new int[len(input)];
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

        
        static bool atLeast3PositiveNumbers(int[] input)
        {
            bool isPositiveNumbers;
            int counter = 0;
            foreach (int i in input)
            {
                isPositiveNumbers = i > 0 ? true : false;
                counter += isPositiveNumbers ? 1 : 0;
            }
            return counter > 2;
        }

        
        static void printMenu()
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


        static string getChoice()
        {
            var choose = Console.ReadLine();
            return choose != null ? choose : "aa";
        }

        
        static void printSeries(int[] intArray)
        {
            foreach (int i in intArray)
            {
                Console.WriteLine(i);
            }
        }
        
        
        static int[] reverse(int[] intArray)
        {
            int[] reversedArr = new int[len(intArray)];
            int tup = 0;
            for (int i = len(intArray) - 1; i >= 0; i--)
            {
                reversedArr[tup] = intArray[i];
                tup++;
            }
            return reversedArr;
        }

        
        static int[] bubbleSort(int[] intArray)
        {
            for (int i = 0; i < len(intArray); i++)
            {
                bool flag = true;
                for (int j = 0; j < len(intArray) - i - 1; j++)
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

        
        static int maxValue(int[] intArray)
        {
            int max = intArray[0];
            foreach (int i in intArray)
            {
                max = i > max ? i : max;
            }
            return max;
        }

        
        static int minValue(int[] intArray)
        {
            int min = intArray[0];
            foreach (int i in intArray)
            {
                min = i < min ? i : min;
            }
            return min;
        }

        
        static double average(int[] intArray)
        {

            double leng = len(intArray);
            return sum(intArray) / leng;
        }

        
        static int sum(int[] intArray)
        {
            int sum = 0;
            foreach (int i in intArray)
            {
                sum += i;
            }
            return sum;
        }
    }
}







