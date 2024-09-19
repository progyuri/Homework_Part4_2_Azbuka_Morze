using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Part4_2
{
    internal class Program
    {
        static Dictionary<char, string> morseCodeDictionary = new Dictionary<char, string>
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
            {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
            {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
            {'Z', "--.."},

            {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"}, {'5', "....."},
            {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."}, {'0', "-----"},

            {'.', ".-.-.-"}, {',', "--..--"}, {'?', "..--.."}, {'\'', ".----."}, {'!', "-.-.--"},
            {'/', "-..-."}, {'(', "-.--."}, {')', "-.--.-"}, {'&', ".-..."}, {':', "---..."},
            {';', "-.-.-."}, {'=', "-...-"}, {'+', ".-.-."}, {'-', "-....-"}, {'_', "..--.-"},
            {'"', ".-..-."}, {'$', "...-..-"}, {'@', ".--.-."}, {' ', "/"}
        };

        static Dictionary<string, char> textDictionary = new Dictionary<string, char>();

        static void Main(string[] args)
        {
            // Инициализация обратного словаря
            foreach (var kvp in morseCodeDictionary)
            {
                textDictionary[kvp.Value] = kvp.Key;
            }

            Console.WriteLine("Добро пожаловать в переводчик азбуки Морзе!");
            Console.WriteLine("Выберите режим:");
            Console.WriteLine("1. Перевести текст в азбуку Морзе");
            Console.WriteLine("2. Перевести азбуку Морзе в текст");

            var choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Введите текст для перевода:");
                string inputText = Console.ReadLine().ToUpper();
                string morseCode = TranslateToMorseCode(inputText);
                Console.WriteLine("Перевод в азбуку Морзе:");
                Console.WriteLine(morseCode);
            }
            else if (choice == "2")
            {
                Console.WriteLine("Введите азбуку Морзе для перевода (используйте пробел для разделения символов и '/' для разделения слов):");
                string inputMorseCode = Console.ReadLine();
                string text = TranslateFromMorseCode(inputMorseCode);
                Console.WriteLine("Перевод в текст:");
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
            }
        }

        static string TranslateToMorseCode(string text)
        {
            StringBuilder morseCodeBuilder = new StringBuilder();

            foreach (char character in text)
            {
                if (morseCodeDictionary.TryGetValue(character, out string morseCode))
                {
                    morseCodeBuilder.Append(morseCode + " ");
                }
                else
                {
                    morseCodeBuilder.Append("? ");
                }
            }

            return morseCodeBuilder.ToString().Trim();
        }

        static string TranslateFromMorseCode(string morseCode)
        {
            StringBuilder textBuilder = new StringBuilder();
            string[] morseWords = morseCode.Split('/');

            foreach (string morseWord in morseWords)
            {
                string[] morseCharacters = morseWord.Trim().Split(' ');

                foreach (string morseCharacter in morseCharacters)
                {
                    if (textDictionary.TryGetValue(morseCharacter, out char character))
                    {
                        textBuilder.Append(character);
                    }
                    else
                    {
                        textBuilder.Append('?');
                    }
                }

                textBuilder.Append(' ');
            }

            return textBuilder.ToString().Trim();
        }
    }
}
