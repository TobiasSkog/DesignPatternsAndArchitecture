using System.Reflection;
using System.Text;

namespace DesignPatterns.Utils;
public static class Draw
{
    private static readonly int maxWidth = Console.WindowWidth;
    private static int MaxPropertyNameLength { get; set; } = 0;
    private static int MaxAmountOfProperties { get; set; } = 0;

    public static void PrintAllObjectsInfo<T>(List<T> objectList, string headerText, string splitByProperty, string informationSeparator = ": ", int lineWidth = 40)
    {
        if (objectList == null || objectList.Count == 0)
        {
            Console.WriteLine("No objects found in the provided list.");
            return;
        }

        var categorizedObjects = CreateDictionaryFromObjectList(objectList, splitByProperty);
        int padding = (lineWidth - headerText.Length) / 2;

        Console.Clear();


        PrintHeader(headerText, lineWidth, padding);

        int productCount = 0;
        foreach (var category in categorizedObjects.Keys)
        {
            PrintCategoryHeader(category, splitByProperty, informationSeparator, lineWidth, padding);
            foreach (var information in categorizedObjects[category])
            {
                if (productCount == MaxAmountOfProperties)
                {
                    productCount = 0;
                    PrintLine(lineWidth);
                }

                PrintPropertyDetail(information, lineWidth, informationSeparator);
                productCount++;
            }

            productCount = 0;
        }
        PrintLine(lineWidth);
    }

    private static Dictionary<string, List<PropertyDetail>> CreateDictionaryFromObjectList<T>(List<T> objectList, string splitByProperty)
    {
        if (objectList == null || objectList.Count == 0)
        {
            return [];
        }

        string category = string.Empty;
        Dictionary<string, List<PropertyDetail>> categorizedObjects = [];

        foreach (var obj in objectList)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            MaxAmountOfProperties = MaxAmountOfProperties > properties.Length - 1 ? MaxAmountOfProperties : properties.Length - 1;

            List<PropertyDetail> objectInformation = [];
            foreach (PropertyInfo property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(obj);
                if (propertyName == splitByProperty)
                {
                    category = propertyValue.ToString();
                }
                else
                {
                    var objectInformationResult = GetObjectDetails(propertyName, propertyValue);
                    MaxPropertyNameLength = MaxPropertyNameLength > objectInformationResult.Name.Length ? MaxPropertyNameLength : objectInformationResult.Name.Length;
                    objectInformation.Add(objectInformationResult);
                }
            }
            if (!string.IsNullOrEmpty(category))
            {
                if (!categorizedObjects.TryGetValue(category, out List<PropertyDetail>? value))
                {
                    value = [];
                    categorizedObjects[category] = value;
                }
                value.AddRange(objectInformation);
            }
        }

        return categorizedObjects;
    }

    private static PropertyDetail GetObjectDetails(string propertyName, object? propertyValue)
    {
        return new PropertyDetail(propertyName, propertyValue.ToString());
    }
    private static void PrintPropertyDetail(PropertyDetail propertyDetail, int lineWidth, string informationSeparator)
    {
        int formattedPadding = MaxPropertyNameLength % 2 == 0 ? MaxPropertyNameLength : MaxPropertyNameLength + 3;
        int padding = (int)MathF.Floor(formattedPadding / 7);

        int additionalWidthConstrain = formattedPadding + padding;

        string formattedPropertyName = AdjustTextLength(propertyDetail.Name, lineWidth, padding).PadRight(formattedPadding);
        string formattedPropertyValue = AdjustTextLength(informationSeparator + propertyDetail.Value, lineWidth, padding, additionalWidthConstrain);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(new string(' ', padding) + formattedPropertyName);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(formattedPropertyValue);
        Console.ResetColor();
    }
    private static string AdjustTextLength(string text, int lineWidth, int padding = 0, int additionalWidthConstraints = 0)
    {
        if (text.Length + additionalWidthConstraints <= lineWidth)
        {
            return text;
        }

        int start = 0;
        var words = text.Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        int availableWidth = lineWidth - padding - additionalWidthConstraints;
        StringBuilder result = new();

        foreach (var word in words)
        {
            if (result.Length - start + word.Length + 1 <= availableWidth)
            {
                if (result.Length > start)
                {
                    result.Append(' ');
                }
                result.Append(word);
            }
            else
            {
                result.Append("\n" + new string(' ', padding + additionalWidthConstraints) + word);
                start = result.Length - word.Length;
            }
        }

        return result.ToString();
    }

    private static void PrintHeader(string headerText, int lineWidth, int padding)
    {
        PrintLine(lineWidth, true);
        Console.WriteLine(CenterText(headerText, lineWidth, padding));
        PrintLine(lineWidth, true);
        Console.WriteLine();
    }
    private static void PrintCategoryHeader(string subHeaderText, string splitByProperty, string informationSeparator, int lineWidth, int padding)
    {
        PrintLine(lineWidth);
        Console.WriteLine(CenterText(splitByProperty + informationSeparator + subHeaderText, lineWidth, padding));
        PrintLine(lineWidth);
    }
    private static string CenterText(string text, int lineWidth, int padding)
    {
        string centeredText = new string(' ', padding) + text + new string(' ', padding);
        return centeredText;
    }

    private static void PrintLine(int lineWidth, bool bold = false)
    {
        string line = new(bold ? '=' : '-', lineWidth);
        Console.WriteLine(line);
    }
    public static void PrintLineSeparator(bool bold = false)
    {
        string line = new(bold ? '=' : '-', maxWidth - 1);
        Console.WriteLine(line);
    }
}

public class PropertyDetail(string name, string value)
{
    public string Name = name;
    public string Value = value;
}