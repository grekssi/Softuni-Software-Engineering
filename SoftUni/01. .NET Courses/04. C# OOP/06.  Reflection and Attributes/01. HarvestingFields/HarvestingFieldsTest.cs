 using System.Collections;
 using System.Collections.Generic;
 using System.IO;
 using System.Linq;
 using System.Reflection;
 using System.Text;

 namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static StringBuilder files = new StringBuilder();
        public static void Main()
        {
            

            var myType = typeof(HarvestingFields);
            FieldInfo[] fields = myType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            while (true)
            {
                var command = Console.ReadLine();
                switch (command)
                {
                    case "HARVEST":
                        Console.WriteLine(files);
                        return;
                    case "private":
                        AppendFile(fields.Where(x => x.IsPrivate));
                        break;
                    case "protected":
                        AppendFile(fields.Where(x => x.IsFamily));
                        break;
                    case "public":
                        AppendFile(fields.Where(x => x.IsPublic));
                        break;
                    case "all":
                        AppendFile(fields);
                        break;
                }
            }
            
        }

        public static void AppendFile(IEnumerable<FieldInfo> files1)
        {
            var currentString = new StringBuilder();
            foreach (var field in files1)
            {
                string accessMofidier = field.Attributes.ToString();
                if (accessMofidier.Equals("Family"))
                {
                    accessMofidier = "Protected";
                }
                files.AppendLine($"{accessMofidier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
