using System;

internal class Program4
{
    public static void Main(string[] args)
    {
        if (!int.TryParse(Console.ReadLine(), out int length))
            return;

        int[] array = new int[length];

        var arrayElementsString = Console.ReadLine();
        var arrayString = arrayElementsString.Split(' ');

        for (int i = 0; i < length; i++)
        {
            if (!int.TryParse(arrayString[i], out int element))
                return;

            array[i] = element;
        }

        for (int i = length - 1; i > -1; i--)
        {
            var currentElement = array[i];
            if (currentElement > 0)
                Console.Write(currentElement + " ");
        }
    }
}