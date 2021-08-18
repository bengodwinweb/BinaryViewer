using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace BinaryViewer
{
    public static class EnumExtender
    {
        public static List<T> GetList<T>(params T[] ignored) where T : struct, IComparable, IConvertible, IFormattable // should be where T : Enum
        {
            var list = new List<T>((T[]) Enum.GetValues(typeof(T)));

            if (ignored != null)
            {
                list.RemoveAll(x => ignored.Contains(x));
            }

            return list;
        }

        public static T GetEnumFromString<T>(string enumString) where T : struct, IComparable, IConvertible, IFormattable // where T : Enum
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enum");
            }

            if (string.IsNullOrEmpty(enumString))
            {
                return default(T);
            }


            var listOfEnums = GetList<T>();

            enumString = enumString.ToUpper();
            if (listOfEnums.Any(x => x.ToString().ToUpper() == enumString))
            {
                enumString = enumString.Replace(' ', '_');
                return listOfEnums.FirstOrDefault(x => x.ToString().ToUpper() == enumString);
            }
            else
            {
                return listOfEnums.FirstOrDefault(x => ((Enum) (object) x).Description().ToUpper() == enumString);
            }
        }

        public static string Description(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentException("Description(" + nameof(value) + " == null)");
            }

            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }

            return value.ToString().Replace('_', ' ').Trim();
        }
    }
}
