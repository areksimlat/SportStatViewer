using System;
using System.Linq;
using System.Text;

namespace SportStatViewer.Data
{
    public enum VoivodeshipNames
    {        
        Dolnoslaskie,
        Kujawskopomorskie,
        Lubelskie,
        Lubuskie,
        Lodzkie,
        Malopolskie,
        Mazowieckie,
        Opolskie,
        Podkarpackie,
        Podlaskie,
        Pomorskie,
        Slaskie,
        Swietokrzyskie,
        Warminskomazurskie,
        Wielkopolskie,
        Zachodniopomorskie,
        None
    }

    public static class VoivodeshipNamesExtensions
    {
        public static VoivodeshipNames Parse(string name)
        {
            string strLetterOnly = new string(((from c in name where char.IsLetter(c) select c).ToArray())).ToUpper();

            StringBuilder stringBuilder = new StringBuilder(strLetterOnly);
            stringBuilder.Replace('Ą', 'A')
                         .Replace('Ć', 'C')
                         .Replace('Ę', 'E')
                         .Replace('Ł', 'L')
                         .Replace('Ń', 'N')
                         .Replace('Ó', 'O')
                         .Replace('Ś', 'S')
                         .Replace('Ż', 'Z')
                         .Replace('Ź', 'Z');
            
            string strWihoutPolish = stringBuilder.ToString();
            string fixedName = strWihoutPolish[0] + strWihoutPolish.Substring(1).ToLower();

            if (!Enum.IsDefined(typeof(VoivodeshipNames), fixedName))
                return VoivodeshipNames.None;

            return (VoivodeshipNames)Enum.Parse(typeof(VoivodeshipNames), fixedName);
        }  
        
        public static string GetName(VoivodeshipNames name)
        {
            switch (name)
            {
                case VoivodeshipNames.Dolnoslaskie:
                    return "Dolnośląskie";
                case VoivodeshipNames.Kujawskopomorskie:
                    return "Kujawsko-pomorskie";
                case VoivodeshipNames.Lodzkie:
                    return "Łódzkie";
                case VoivodeshipNames.Lubelskie:
                    return "Lubelskie";
                case VoivodeshipNames.Lubuskie:
                    return "Lubuskie";
                case VoivodeshipNames.Malopolskie:
                    return "Małopolskie";
                case VoivodeshipNames.Mazowieckie:
                    return "Mazowieckie";
                case VoivodeshipNames.Opolskie:
                    return "Opolskie";
                case VoivodeshipNames.Podkarpackie:
                    return "Podkarapackie";
                case VoivodeshipNames.Podlaskie:
                    return "Podlaskie";
                case VoivodeshipNames.Pomorskie:
                    return "Pomorskie";
                case VoivodeshipNames.Slaskie:
                    return "Śląskie";
                case VoivodeshipNames.Swietokrzyskie:
                    return "Świętokrzyskie";
                case VoivodeshipNames.Warminskomazurskie:
                    return "Warmińsko-mazurskie";
                case VoivodeshipNames.Wielkopolskie:
                    return "Wielkopolskie";
                case VoivodeshipNames.Zachodniopomorskie:
                    return "Zachodniopomorskie";
            }

            return "";
        }  
    }
}
