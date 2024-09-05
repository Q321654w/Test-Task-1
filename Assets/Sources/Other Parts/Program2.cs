using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

internal class Program2
{
    public static async Task Main(string[] args)
    {
        var currencyName = Console.ReadLine();

        var url = "https://www.cbr.ru/scripts/XML_daily.asp";
        var doc = XDocument.Load(url);

        var root = doc.Root;

        var targetNode = root.Elements("Valute").Where(p => p.Element("Name").Value == currencyName);
        foreach (var element in targetNode.Elements())
        {
            Console.WriteLine($"{element.Name}: {element.Value}");
        }
    }
}