// See https://aka.ms/new-console-template for more information
using Hw2_AttributeReflection;
using System.Reflection;


CreateScript(typeof(Product));

static void CreateScript(Type type)
{
    var tableAttribute = type.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(TableAttribute));
    var tableName = GetTableName(tableAttribute);

    var columnWithAttributes = type.GetProperties().Where(x => x.GetCustomAttributes(true).Length > 0);
    List<object> columnsAttributes = GetColumnAttribute(columnWithAttributes);
    List<ColumnProperties> attributeValues = GetColumnAttributeValues(columnsAttributes);


    Console.WriteLine($"Tablo adı => {tableName}");
    var i = 1;
    foreach (var item in attributeValues)
    {

        Console.WriteLine($"{i}. Kolon => Adı = {item.Name}/ Tipi = {item.Type}/ Gereklilik={item.IsRequired}");
        i++;
    }

}
static List<ColumnProperties> GetColumnAttributeValues(List<object> list)
{
    List<ColumnProperties> attributeValues = new List<ColumnProperties>();
    foreach (var item in list)
    {
        ColumnProperties propertyValues = new ColumnProperties();
        propertyValues.Name = (string)item.GetType().GetProperty("Name").GetValue(item, null);
        propertyValues.Type = (Type)item.GetType().GetProperty("Type").GetValue(item, null);
        propertyValues.IsRequired = (bool)item.GetType().GetProperty("IsRequired").GetValue(item, null);
        attributeValues.Add(propertyValues);
    }
    return attributeValues;
}
static List<Object> GetColumnAttribute(IEnumerable<PropertyInfo> infos)
{
    List<object> columnsAttributes = new List<object>();
    foreach (var item in infos)
    {
        if (item.GetCustomAttributes(true).Where(x => x.GetType() == typeof(ColumnAttribute)) != null)
        {
            var objectToAdd = item.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(ColumnAttribute));
            if (objectToAdd != null)
            {
                columnsAttributes.Add(objectToAdd);
            }

        }
    }
    return columnsAttributes;
}

static string GetTableName(object tableAttribute)
{
    var bannedChars = "çÇğĞıİöÖşŞüÜ";
    string tableName = (string)tableAttribute?.GetType().GetProperty("Name")?.GetValue(tableAttribute, null);
    var result = tableName.Any(x => bannedChars.Contains(x));
    if (result)
    {
        throw new Exception($"{tableName} türkçe karakter içermemelidir. ");
    }
    return tableName;
}
