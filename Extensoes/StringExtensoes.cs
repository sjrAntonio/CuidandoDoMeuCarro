using System.Text.RegularExpressions;

namespace CuidandoDoMeuCarro.Extensoes
{
    public static class StringExtensoes
    {
        public static string clearString(this string value) 
        { 
            value = value.Replace("\t", "");
            value = value.Replace("\n", "");
            value = Regex.Replace(value, @"\s+", " ");
            value = value.Trim();

            return value;
        }
    }
}
