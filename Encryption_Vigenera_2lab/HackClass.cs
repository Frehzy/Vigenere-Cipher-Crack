using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption_Vigenera_2lab
{
    public class HackClass
    {
        public static int time = 0;
        public static int nowINT0 = 0;

        public static List<string> GetWord(string getWord, IProgress<int> progress, IProgress<int> nowINT, int maxLengthKey)
        {
            List<string> keysWordFinal = new List<string>(); //лист со ВЗЛОМАННЫМИ ключами

            string keyWordFinal = ""; //ключ временный

            string a = getWord.ToLower(); //сам текст

            var newWORD = a.Replace(" ", "");

            //тут удаление лишних символов
            var res = new Regex("[^А-Яа-яЁё ]");
            MatchCollection matched = res.Matches(newWORD);
            var resultKeyWord = new Regex("[^А-Яа-яЁё ]").Replace(newWORD, string.Empty).ToLower().Replace("ё", "е");
            newWORD = resultKeyWord.Replace(" ", ""); //очистка КЛЮЧЕВОГО СЛОВА от пробелов

            Dictionary<int, int> KeyLength = new Dictionary<int, int>(); //словарь с ключами
            time = -1;

            nowINT0 = 0;

            for (int maxLength = 6; maxLength <= maxLengthKey; maxLength++) //maxLength - длина подСЛОВ, которые ищутся в ЗАШИФРОВАННОМ слове (3 - ааа, 4 - аааа, 5 - ааааа)
            {
                //поиск повторяющихся N-х элементов подряд (maxLength)
                for (int i = 0; i <= newWORD.Length; i++)
                {
                    nowINT.Report(nowINT0);
                    if (i < newWORD.Length - (maxLength - 1))
                    {
                        string b = "";
                        for (int qq = 0; qq < maxLength; qq++)
                            b += newWORD[i + qq].ToString();

                        for (int j = 0; j <= newWORD.Length; j++)
                        {
                            if (j < newWORD.Length - (maxLength - 1))
                            {
                                string c = "";
                                for (int q = 0; q < maxLength; q++)
                                    c += newWORD[j + q].ToString();

                                if ((b == c) && (i != j))
                                {
                                    //вывод повторяющихся элементов
                                    //Console.WriteLine(b + "[" + i + "]" + " Повторяется с " + c + "[" + j + "]");

                                    for (double l = 4; l <= 150; l++) //длина ключа ОТ и ДО (3 до 25)
                                    {
                                        if ((j - i) > 0) //если число положительное (проверка)
                                        {
                                            double Check = (j - i) / l; //и выполняется условие
                                            if (Check % 1 == 0) //и остаток от деления равен 0
                                            {
                                                int l_int = Convert.ToInt32(l);
                                                if (KeyLength.ContainsKey(l_int))
                                                    KeyLength[l_int]++;
                                                else
                                                    KeyLength[l_int] = 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    time++;
                    progress.Report(time);
                }
                time = 0;
                nowINT0++;
                nowINT.Report(nowINT0);
            }

            //УДАЛИТЬ......................................
            /*int temp = 0;
            int tempKey = 0;
            foreach (var i in KeyLength)
            {
                if (i.Value > temp)
                {
                    temp = i.Value;
                    tempKey = i.Key;
                }
                MessageBox.Show($"{i.Key} использовался {i.Value}");
            }*/
            //Console.WriteLine($"Больше всего использовался {tempKey} / {temp}");

            int maxval = 0;
            int keyLength = 0;
            try //если не найдена длина ключа
            {
                maxval = KeyLength.Max(m => m.Value); //наибольшее значение счётчика
                IEnumerable<KeyValuePair<int, int>> listwithmaxvals = KeyLength.Where(w => w.Value == maxval); //список записей с наибольшим значением счётчика
                keyLength = listwithmaxvals.ElementAt(0).Key; //первый элемент с максимальным значением счётчика
            }
            catch
            {
                if (maxval == 0 || keyLength == 0)
                {
                    //на случай, если нужно будет чекнуть на длину ключевого слова
                    //MessageBox.Show("Не найдёно достаточное количество повторяющихся записей", "Не удалось взломать", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return keysWordFinal;
            }

            Dictionary<int, int> secretkeysLength = new Dictionary<int, int>();
            secretkeysLength.Add(keyLength, maxval);

            for (int i = 0; i <= 300; i++)
            {
                foreach (var j in KeyLength)
                {
                    //MessageBox.Show(j.Value.ToString() + " - " + j.Key + "/" + (maxval - i).ToString());
                    if (j.Value == (maxval - i))
                    { 
                        try
                        {
                            secretkeysLength.Add(j.Key, j.Value);
                            //MessageBox.Show($"{i} i элемент/{j.Key} key/{j.Value} value/{(maxval-i).ToString()} maxval - i");
                        }
                        catch
                        { }
                    }
                }
            }
            /*StringBuilder sb = new StringBuilder();
            foreach (var cell in secretkeysLength.ToList())
            {
                sb.AppendLine($"Ключ с длиной {cell.Key.ToString()} встречается {cell.Value.ToString()}");
            }
            if (secretkeysLength.Count > 1)
            {
                MessageBox.Show(sb.ToString(), "Кажется, найдено несколько ключей");
            }*/

            foreach (var nowKeyLength in secretkeysLength)
            {
                var xxx = Enumerable.Range(0, (int)Math.Ceiling((decimal)a.Length / nowKeyLength.Key)) // Получим число слов
                    .Select(i => a.Substring(i * nowKeyLength.Key, Math.Min(a.Length - i * nowKeyLength.Key, nowKeyLength.Key)).ToCharArray())// Разобьём строку на части нужной длины (последнее слово - остатком)
                    .SelectMany(x => x.Select((c, i) => new { index = i, chr = c }))// Разобьём части на символы с запоминанием позиции
                    .GroupBy(x => x.index) // Сгруппируем в "слова"
                    .Select((x, i) => new { Word = i, letters = x.GroupBy(g => g.chr) }) //Сгруппируем каждое слово посимвольно
                    .Select(x => x.letters.Select(l => new { x.Word, l.Key, Count = l.Count() })) //Посчитаем символы
                    .SelectMany(x => Enumerable.Range('а', 'я' - 'а' + 1).Select(e => new //Получим алфавит
                {
                        x.First().Word,
                        Letter = (char)e,
                        Rate = (decimal)(x.FirstOrDefault(w => w.Key == e)?.Count ?? 0) / x.Sum(w => w.Count) //Посчитаем рейт
                }))./*Where(x => x.Rate > 0).*/ToList(); //Выведем все записи с ненулевым рейтом

                List<LetterFreq> letter = new List<LetterFreq>();
                #region частота букв
                letter.Add(new LetterFreq() { letter = 'а', freq = 0.062M });
                letter.Add(new LetterFreq() { letter = 'б', freq = 0.014M });
                letter.Add(new LetterFreq() { letter = 'в', freq = 0.038M });
                letter.Add(new LetterFreq() { letter = 'г', freq = 0.013M });
                letter.Add(new LetterFreq() { letter = 'д', freq = 0.025M });
                letter.Add(new LetterFreq() { letter = 'е', freq = 0.072M });
                letter.Add(new LetterFreq() { letter = 'ж', freq = 0.007M });
                letter.Add(new LetterFreq() { letter = 'з', freq = 0.016M });
                letter.Add(new LetterFreq() { letter = 'и', freq = 0.062M });
                letter.Add(new LetterFreq() { letter = 'й', freq = 0.010M });
                letter.Add(new LetterFreq() { letter = 'к', freq = 0.028M });
                letter.Add(new LetterFreq() { letter = 'л', freq = 0.035M });
                letter.Add(new LetterFreq() { letter = 'м', freq = 0.026M });
                letter.Add(new LetterFreq() { letter = 'н', freq = 0.053M });
                letter.Add(new LetterFreq() { letter = 'о', freq = 0.090M });
                letter.Add(new LetterFreq() { letter = 'п', freq = 0.023M });
                letter.Add(new LetterFreq() { letter = 'р', freq = 0.040M });
                letter.Add(new LetterFreq() { letter = 'с', freq = 0.045M });
                letter.Add(new LetterFreq() { letter = 'т', freq = 0.053M });
                letter.Add(new LetterFreq() { letter = 'у', freq = 0.021M });
                letter.Add(new LetterFreq() { letter = 'ф', freq = 0.002M });
                letter.Add(new LetterFreq() { letter = 'х', freq = 0.009M });
                letter.Add(new LetterFreq() { letter = 'ц', freq = 0.003M });
                letter.Add(new LetterFreq() { letter = 'ч', freq = 0.012M });
                letter.Add(new LetterFreq() { letter = 'ш', freq = 0.006M });
                letter.Add(new LetterFreq() { letter = 'щ', freq = 0.003M });
                letter.Add(new LetterFreq() { letter = 'ъ', freq = 0.014M });
                letter.Add(new LetterFreq() { letter = 'ы', freq = 0.016M });
                letter.Add(new LetterFreq() { letter = 'ь', freq = 0.014M });
                letter.Add(new LetterFreq() { letter = 'э', freq = 0.003M });
                letter.Add(new LetterFreq() { letter = 'ю', freq = 0.006M });
                letter.Add(new LetterFreq() { letter = 'я', freq = 0.018M });
                #endregion

                //ПОПЫТКА НАЙТИ ЕБАНЫЙ КЛЮЧ
                var sum = 0M; //просто счёт это частоты
                var hash = 1M; //херня для нахождения меньшей частоты по ебучей формуле
                string keyWord = "";

                for (int keyLenght = 0; keyLenght < nowKeyLength.Key; keyLenght++) //перебор для соответствующей буквы
                {
                    sum = 0M; //просто счёт это частоты
                    hash = 1M; //херня для нахождения меньшей частоты по ебучей формуле
                    keyWord = ""; //ключ
                    for (int offsets = 31; offsets >= 0; offsets--) //offsets = 31 - a = a, offsets = 30 - я = a, ....
                                                                    //перебор квадрата (формула)
                    {
                        sum = 0M;

                        for (int i = 0; i < letter.Count(); i++) //для всего ГЛОБАЛЬНОГО алфавита
                        {
                            offsets++;
                            if (offsets > letter.Count() - 1)
                            {
                                offsets = 0;
                            }

                            var globalLetterFreq = letter[offsets].freq; //ГЛОБАЛЬНАЯ частота
                            var nowLetterFreq = xxx[i + letter.Count() * keyLenght].Rate; //обычная частота
                            if (keyLenght < 1) //если это 1 буква
                            {
                                if (xxx[i].Rate == 0) //если буквы в тексте нет (в 1 проходе)
                                {
                                    sum = sum + (globalLetterFreq * globalLetterFreq); //если нет совпадений
                                                                                       //Console.WriteLine($"Глобальная буква и частота: {letter[offsets].letter} / {letter[offsets].freq}");
                                }
                                else
                                {
                                    sum = sum + (globalLetterFreq - xxx[i].Rate) * (globalLetterFreq - xxx[i].Rate);
                                    //Console.WriteLine($"Глобальная буква и частота: {letter[offsets].letter} / {letter[offsets].freq} - вычитаемая буква и частота {xxx[i].Letter} / {xxx[i].Rate}");
                                }
                            }
                            else
                            {
                                if (nowLetterFreq == 0) //если буквы в тексте нет (в следующих проходах)
                                {
                                    sum = sum + (globalLetterFreq * globalLetterFreq);
                                    //Console.WriteLine($"Глобальная буква и частота: {letter[offsets].letter} / {letter[offsets].freq}");
                                }
                                else
                                {
                                    sum = sum + (globalLetterFreq - nowLetterFreq) * (globalLetterFreq - nowLetterFreq);
                                    //Console.WriteLine($"Глобальная буква и частота: {letter[offsets].letter} / {letter[offsets].freq} - вычитаемая буква и частота {xxx[i].Letter} / {xxx[i].Rate}");
                                }
                            }
                        }

                        if (sum < hash)
                        {
                            hash = sum;
                            keyWord = letter[-(offsets - 31)].letter.ToString();
                        }
                        //Console.WriteLine($"{-(offsets - 32)} гипотеза = {sum} ({letter[-(offsets - 32)].letter} = A)");
                    }
                    //MessageBox.Show($"{keyWord} - {keyLenght + 1} буква ключа.");
                    keyWordFinal += keyWord;
                }

                //ВЫВОЖУ ЧАСТОТУ КАЖДОЙ БУКВЫ В ЕБУЧЕМ СЛОВЕ
                /*foreach (var x in xxx)
                {
                    Console.WriteLine($"Слово: {x.Word}, Буква: {x.Letter}, Частота: {x.Rate}");
                }*/
                //MessageBox.Show(keyWordFinal);
                keysWordFinal.Add(keyWordFinal);
                keyWordFinal = "";
            }

            return keysWordFinal;
        }

        public class LetterFreq
        {
            public char letter;
            public decimal freq;
        }
    }
}
