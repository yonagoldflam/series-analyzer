using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
int[] conversionToIntArray(string input)
{
    string[] temp = input.Split(','); 
    int[] result = new int[temp.Length];
    for (int i = 0; i < temp.Length; i++)
    {
        result[i] = int.Parse(temp[i]);
    }
    
    return result;
}

bool atLeast3PositiveNumbers(int[] input)
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
void printMenu()
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

int[] getSeriesAndConvertToIntArray()
{
    string txt = Console.ReadLine();
    int[] intArray =  conversionToIntArray(txt);
    return intArray;
}

string getChoice()
{
    return Console.ReadLine();
}

void printSeries(int[] intArray)
{
    foreach (int i in intArray)
    {
        Console.WriteLine(i);
    }
}
int[] reverse(int[] intArray)
{
    int[] reversedArr = new int[intArray.Length];
    int tup = 0;
    for (int i = intArray.Length -1; i >= 0; i--)
    {
        reversedArr[tup] = intArray[i];
        tup++;
    }
    return reversedArr;
}

int[] bubbleSort(int[] intArray)
{
    for (int i = 0; i < intArray.Length; i++)
    {
        bool flag = true;
        for (int j = 0; j < intArray.Length - i - 1; j++)
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

int maxValue(int[] intArray)
{
    int max = 0;
    foreach (int i in intArray)
    {
        max = i > max ? i : max;
    }
    return max;
}

int minValue(int[] intArray)
{
    int min = intArray[0];
    foreach(int i in intArray)
    {
        min = i < min ? i : min;
    }
    return min;
}

int sum(int[] intArray)
{
    int sum = 0;
    foreach (int i in intArray)
    {
        sum += i;
    }
    return sum;
}

double average(int[] intArray)
{
    double len = intArray.Length;
    return sum(intArray) / len;
}

int len(int[] intArray)
{
    int counter = 0;
    foreach (int i in intArray)
    {
        counter++;
    }
    return counter;
}

void main()
{
    int[] series = getSeriesAndConvertToIntArray();
    bool flag = true;
    while (flag)
    { 
        printMenu();
        string choose = getChoice();
        switch (choose)
        {
            case "a":
                series = getSeriesAndConvertToIntArray();
                if (!atLeast3PositiveNumbers(series))
                {
                    Console.WriteLine("Your input does not contain at least three positive digits.");
                    continue;
                }
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
                flag = false;
                break;
        }
    }
}

main();
