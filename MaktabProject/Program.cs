Console.WriteLine("Please enter an integer array:");
var firstinput = Console.ReadLine();
string[] arrayInput = firstinput.Split(',');
for (int i = 0; i < arrayInput.Length; i++)
{
    arrayInput[i] = arrayInput[i].Trim();
}
int[] inputNumber = new int[arrayInput.Length];
for (int i = 0; i < arrayInput.Length; i++)
{
    inputNumber[i] = Convert.ToInt32(arrayInput[i]);
}
Console.WriteLine("Please select a method");
Console.WriteLine("1- Search");
Console.WriteLine("2- Search an Index");
Console.WriteLine("3- Maximum");
Console.WriteLine("4- Minimum");
Console.WriteLine("5- Search in Binary");
Console.WriteLine("6- Sort");
Console.WriteLine("7- BubbleSort");
Console.WriteLine("8- InsertSort");
Console.WriteLine("9- InsertionSort");
int methodType = Convert.ToInt32(Console.ReadLine());
int z = 0;
if (methodType == 1 || methodType == 2 || methodType == 5)
{
    Console.WriteLine("Enter a number to search :");
    z = Convert.ToInt32(Console.ReadLine());
}
switch (methodType)
{
    case 1:
        Console.WriteLine(search(inputNumber, z));
        break;
    case 2:
        var _result = searchIndex(inputNumber, z);
        foreach (var item in _result)
        {
            if (item != 0)
                Console.Write(item + " - ");
        }
        break;
    case 3:
        Console.WriteLine(Maximum(inputNumber));
        break;
    case 4:
        Console.WriteLine(Minimum(inputNumber));
        break;
    case 5:
        Console.WriteLine(BinarySearch(inputNumber, 0, inputNumber.Length - 1, z));
        break;
    case 6:
        PrintArray(sort(inputNumber));
        break;
    case 7:
        PrintArray(BubbleSort(inputNumber));
        break;
    case 8:
        PrintArray(InsertSort(inputNumber));
        break;
    case 9:
        PrintArray(InsertionSort(inputNumber));
        break;
    default:
        break;
}
bool search(int[] arr, int z)
{
    foreach (var item in arr)
    {
        if (item == z)
            return true;
    }
    return false;
}
int[] searchIndex(int[] arr, int z)
{
    int[] result = new int[arr.Length];
    int j = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == z)
        {
            result[j] = j + 1;
            j++;
        }
    }
    return result;
}
int Maximum(int[] arr)
{
    int max = arr[0];
    foreach (var item in arr)
    {
        if (item > max)
            max = item;
    }
    return max;
}
int Minimum(int[] arr)
{
    int min = arr[0];
    foreach (var item in arr)
    {
        if (item < min)
            min = item;
    }
    return min;
}
int BinarySearch(int[] arr, int low, int high, int x)
{
    int mid = low + (high - low) / 2;
    if (low > high)
        return -1;
    if (x == arr[mid])
        return mid + 1;
    else if (x < arr[mid])
        return BinarySearch(arr, low, mid - 1, x);
    else if (x > arr[mid])
        return BinarySearch(arr, mid + 1, high, x);
    return -1;
}

int[] sort(int[] arr)
{
    int[] temp = new int[arr.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        temp[i] = arr[i];
    }
    int[] result = new int[arr.Length];
    for (int i = 0; i < temp.Length; i++)
    {
        int minIndex = MinIndex(temp);
        result[i] = temp[minIndex];
        temp[minIndex] = int.MaxValue;
    }
    return result;
}

int[] BubbleSort(int[] arr)
{
    for (int j = 0; j < arr.Length; j++)
    {
        for (int i = 0; i < arr.Length - 1 - j; i++)
        {
            if (arr[i] > arr[i + 1])
                Swap(arr, i, i + 1);
        }
    }
    return arr;
}
int[] InsertSort(int[] arr)
{
    int[] result = new int[arr.Length];
    for (int i = 0; i < result.Length; i++)
    {
        result[i] = int.MaxValue;
    }
    foreach (var item in arr)
    {
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] > item)
            {
                ShiftToRight(result, i);
                result[i] = item;
                break;
            }
        }
    }
    return result;
}

int[] InsertionSort(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        int key = arr[i];
        int j = i - 1;
        while (j >= 0 && arr[j] > key)
        {
            arr[j + 1] = arr[j];
            j = j - 1;
        }
    }
    return arr;
}

int MinIndex(int[] arr)
{
    int minIndex = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] < arr[minIndex])
            minIndex = i;
    }
    return minIndex;
}

void PrintArray(int[] arr)
{
    foreach (var item in arr)
    {
        Console.Write($"{item} - ");
    }
}
void ShiftToRight(int[] arr, int index)
{
    for (int i = arr.Length - 1; i > index; i--)
    {
        arr[i] = arr[i - 1];
    }
}
void Swap(int[] arr, int index1, int index2)
{
    int temp = arr[index1];
    arr[index1] = arr[index2];
    arr[index2] = temp;
}