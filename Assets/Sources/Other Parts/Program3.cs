using System;

internal class Program3
{
    public static void Main(string[] args)
    {
        var length = 20;
        int[] array = new int[length];

        var arrayElementsString = Console.ReadLine();
        if (arrayElementsString == null)
            return;

        var arrayString = arrayElementsString.Split(' ');

        for (int i = 0; i < length; i++)
        {
            if (!int.TryParse(arrayString[i], out int element))
                return;

            array[i] = element;
        }

        Array.Sort(array);

        Console.WriteLine(array[length - 1] + array[length - 2] + array[length - 3]);
    }
}