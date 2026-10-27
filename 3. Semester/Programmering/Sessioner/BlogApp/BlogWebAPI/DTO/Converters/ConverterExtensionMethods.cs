using System.Reflection;

public static class ConverterExtensionMethods
{
    public static T CopyPropertiesTo<T>(this object sourceObject, T destinationObject)
    {
        foreach (PropertyInfo destinationProperty in destinationObject.GetType().GetProper
       ties().Where(p => p.CanWrite))
 {
            if (!sourceObject.GetType().GetProperties().Any(sourceProp => sourceProp.Name
           == destinationProperty.Name && sourceProp.PropertyType == destinationProperty.PropertyType
           )) continue;
            var sourceProp = sourceObject.GetType().GetProperty(destinationProperty.Name);
            destinationProperty.SetValue(destinationObject, sourceProp.GetValue(sourceObje
           ct, null), null);
        }
        return destinationObject;
    }
}