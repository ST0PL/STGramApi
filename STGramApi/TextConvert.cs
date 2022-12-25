using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STGramApi
{
    //Набор инструментов для обработки текста
    static class TextConvert
    {

        static string[] Russian =
        {
                "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л",
                "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц",
                "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я",
        };
        static string[] English =
        {
                "A", "B", "V", "G", "D", "E", "Е", "J", "Z", "I", "Y", "K", "L", "M",
                "N", "O", "P", "R", "S", "T", "U", "F", "H", "C", "CH",
                "SH", "SHCH", "", "Y", "", "E", "YU", "YA",
        };
        static bool CheckCyrillic(string value)
        {

            //Проверка строки на кириллицу

            int K = 0;
            bool fullru = false;
            foreach (var x in value)
            {
                foreach (var z in Russian)
                {
                    if (x.ToString().ToUpper() == z)
                    {
                        K++;
                    }
                }
            }
            if (K > 0)
            {
                fullru = true;
            }
            return fullru;
        }
        public static string Translit(string value)
        {

            //Транслит текста с русского на английский

            if (CheckCyrillic(value))
            {
                string @new = "";
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i].ToString() == " ")
                    {
                        @new += " ";
                    }
                    else if (English.Contains(value[i].ToString().ToUpper()))
                    {
                        @new += value[i].ToString().ToUpper();
                        continue;
                    }
                    for (int z = 0; z < Russian.Length; z++)
                    {
                        if (value[i].ToString().ToUpper() == Russian[z])
                        {
                            @new += English[z];
                        }
                    }
                }
                return @new;
            }
            else
            {
                return value;
            }
        }
    }
}
