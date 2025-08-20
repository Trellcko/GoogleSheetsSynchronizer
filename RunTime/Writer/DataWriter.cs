using System;
using System.Reflection;
using UnityEngine;

namespace Trellcko.GoogleSheetsSynchronizer
{
    public class DataWriter : IDataWriter
    {
        public void Write(SynchronizedData target, ParserOutputData data)
        {
            FieldInfo fieldInfo = target.GetType().GetField(data.Header,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo == null)
            {
                Debug.LogError($"No field '{data.Header}' in type {target.GetType()}");
                return;
            }

            object converted;
            if (fieldInfo.FieldType.IsArray)
            {
                converted =  StringToArray(data.Values, fieldInfo.FieldType);
            }
            else if (data.Values.Length == 1)
            {
                converted = StringToType(data.Values[0], fieldInfo.FieldType);
            }
            else
            {
                Debug.LogError($"Field {data.Header} is not an array but multiple values provided");
                return;
            }

            fieldInfo.SetValue(target, converted);
        }

        private static object StringToArray(string[] dataValues, Type arrayType)
        {
            Type elementType = arrayType.GetElementType();
            Array typedArray = Array.CreateInstance(elementType, dataValues.Length);
            for (int i = 0; i < dataValues.Length; i++)
            {
                object convertedValue = StringToType(dataValues[i], elementType);
                typedArray.SetValue(convertedValue, i);
            }

            return typedArray;
        }
    

    private static object StringToType(string str, Type type)
        {
            if (type == typeof(string))
                return str;

            if (type.IsEnum)
                return Enum.Parse(type, str);

            return Convert.ChangeType(str, type);
        }
    }
}