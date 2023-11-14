using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProyectoFinal2;

namespace ProyectoFinal2
{
    public class ValidarLibrary
    {
        public static bool Isnumeric(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^(-)?[0-9]+$");
        }

        public static bool BetweenInclusive(string numero, int valor1, int valor2)
        {
            bool result = true;
            if (!Isnumeric(numero))
            {
                result = false;
            }

            if (int.Parse(numero) < valor1 || int.Parse(numero) > valor2)
            {
                result = false;
            }

            return result;
        }

        public static bool BetweenInclusive(string numero, double valor1, double valor2)
        {
            bool result = true;
            if (!Isnumeric(numero))
            {
                result = false;
            }

            if ((double)int.Parse(numero) < valor1 || (double)int.Parse(numero) > valor2)
            {
                result = false;
            }

            return result;
        }

        public static bool BetweenInclusive(string numero, decimal valor1, decimal valor2)
        {
            bool result = true;
            if (!Isnumeric(numero))
            {
                result = false;
            }

            if ((decimal)int.Parse(numero) < valor1 || (decimal)int.Parse(numero) > valor2)
            {
                result = false;
            }

            return result;
        }

        public static bool BetweenInclusive(string numero, float valor1, float valor2)
        {
            bool result = true;
            if (!Isnumeric(numero))
            {
                result = false;
            }

            if ((float)int.Parse(numero) < valor1 || (float)int.Parse(numero) > valor2)
            {
                result = false;
            }

            return result;
        }

        public static bool IsAlphabetic(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^[a-zA-ZñÑ ]+$");
        }

        public static bool IsAlphaNumeric(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^[a-zA-Z0-9ñÑ]+$");
        }

        public static bool IsWhiteSpace(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        public static bool IsDomicilio(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^[a-zA-ZáéíóúÁÉÍÓÚñÑ\\s°,\\-0-9]+$");
        }

        public static bool IsDate(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text) || !IsDateValid(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^(0?[1-9]|[12][0-9]|3[01])/(0?[1-9]|1[0-2])/\\d{4}");
        }

        private static bool IsDateValid(string text)
        {
            bool result = true;
            string text2 = string.Empty;
            string text3 = string.Empty;
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '/')
                {
                    if (num == 0)
                    {
                        num = i;
                    }
                    else
                    {
                        num2 = i;
                    }
                }
            }

            for (int j = 0; j < num; j++)
            {
                text2 += text[j];
            }

            for (int k = num + 1; k < num2; k++)
            {
                text3 += text[k];
            }

            int num3 = int.Parse(text2);
            int num4 = int.Parse(text3);
            if ((num4 == 4 || num4 == 6 || num4 == 9 || num4 == 11) && num3 > 30)
            {
                result = false;
            }

            if (num4 == 2 && num3 > 29)
            {
                result = false;
            }

            return result;
        }

        public static bool IsPhone(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^\\(?\\d{2,5}\\)?-?\\d{6,8}$");
        }

        public static bool IsEdad(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            if (Isnumeric(text) && int.Parse(text) < 0)
            {
                return false;
            }

            return Regex.IsMatch(text, "^(?:1[0-1][0-9]|120|[1 -9][0-9]?)$");
        }

        public static bool IsDNI(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            if (Regex.IsMatch(text, "^[0-9]{1,9}(\\.[0-9]{0,2})?$+$") && IsDNIvalid(text))
            {
                return true;
            }

            return false;
        }

        private static bool IsDNIvalid(string text)
        {
            bool result = false;
            if (Isnumeric(text))
            {
                int num = int.Parse(text);
                if (num > 3000000 && num < 100000000)
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsEmail(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^(([^<>()\\[\\]\\.,;:\\s@\\”]+(\\.[^<>()\\[\\]\\.,;:\\s@\\”]+)*)|(\\”.+\\”))@(([^<>()[\\]\\.,;:\\s@\\”]+\\.)+[^<>()[\\]\\.,;:\\s@\\”]{2,})$");
        }

        public static bool IsSalario(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^\\d+(,\\d{1,2})?$");
        }

        public static bool IsPrecio(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^\\$?\\s?\\d{1,16}(,\\d{2})?$");
        }

        public static bool IsTemperatura(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^-?\\d+°[cC]$");
        }

        public static bool IsDay(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^(?i)(lunes|martes|miercoles|jueves|viernes|sabado|domingo)$");
        }

        public static bool IsMonth(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^(?i)(enero|febrero|marzo|abril|mayo|junio|julio|agosto|septiembre|octubre|noviembre|diciembre)$");
        }

        public static bool IsHora(string text)
        {
            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            if (Regex.IsMatch(text, "^\\d{2}:\\d{2}(?:\\s?hs)?$") && IsHoraValid(text))
            {
                return true;
            }

            return false;
        }

        private static bool IsHoraValid(string text)
        {
            bool result = false;
            string text2 = string.Empty;
            string text3 = string.Empty;
            for (int i = 0; i < 2; i++)
            {
                text2 += text[i];
            }

            for (int j = 3; j < 5; j++)
            {
                text3 += text[j];
            }

            int num = int.Parse(text2);
            int num2 = int.Parse(text3);
            if (num >= 0 && num < 25 && num2 >= 0 && num2 < 60)
            {
                result = true;
            }

            return result;
        }

        public static bool IsMaxLongitud(string text, int longitud)
        {
            return text.Length <= longitud;
        }

        public static bool IsMinLongitud(string text, int longitud)
        {
            return text.Length >= longitud;
        }

        public static bool IsEqualLongitud(string text, int longitud)
        {
            return text.Length == longitud;
        }

        public static bool IsCUIL(string text)
        {
            if (text.Length != 13 || string.IsNullOrWhiteSpace(text) || !IsValidCUIL(text))
            {
                return false;
            }

            return Regex.IsMatch(text, "^\\d{2}-\\d{8}-\\d$");
        }

        private static bool IsValidCUIL(string cuil)
        {
            bool result = false;
            int num = 0;
            string text = cuil.Replace("-", string.Empty);
            string text2 = "6789456789";
            long result2 = 0L;
            if (long.TryParse(text, out result2))
            {
                int num2 = int.Parse(text[text.Length - 1].ToString());
                for (int i = 0; i < 10; i++)
                {
                    int num3 = int.Parse(text2.Substring(i, 1));
                    int num4 = int.Parse(text.Substring(i, 1));
                    int num5 = num3 * num4;
                    num += num5;
                }

                num %= 11;
                result = num == num2;
            }

            return result;
        }
    }
}

