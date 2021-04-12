using System;
using System.Windows.Forms;

namespace Encryption_Vigenera_2lab
{
    class EncryptClass
    {
        public static string GetWord(string getWord, string getKeyword)
        {
            string word = getWord.ToLower(); //само слово
            string key = getKeyword.ToLower(); //ключевое слово

            string res = ""; //результат

            int keyword_index = 0; //позиция буквы из ключевого слова в данный момент

            int divide = 1;

            foreach (char symbol in word)
            {
                if (symbol.ToString() != " ") //удаление пробелов
                {
                    int a = Array.IndexOf(Form1.characters, symbol); //позиция буквы самого слова
                    int b = Array.IndexOf(Form1.characters, key[keyword_index]); //позция буквы ключевого слова
                    int c = a + b; //сложение этих позиций
                    if (c >= Form1.N) //если дошёл до границы, то вычитание длины САМОГО слова
                        c = c - Form1.N;
                    res += Form1.characters[c]; //составление слова

                    keyword_index++;

                    if (keyword_index == key.Length) //если выход за границы КЛЮЧЕВОГО слова
                        keyword_index = 0;

                    if (divide == 5)
                    {
                        res += " ";
                        divide = 0;
                    }
                    divide++;
                }
                else
                {
                    res += " ";
                }
            }
            return res;
        }
    }
}
