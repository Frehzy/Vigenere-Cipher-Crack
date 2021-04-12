using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Encryption_Vigenera_2lab
{
    public partial class Form1 : MetroForm
    {
        #region Переменные
        public static string GetText; //САМО СЛОВО
        public static string GetKey; //КЛЮЧЕВОЕ СЛОВО
        public static char[] characters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и',
                                                       'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
                                                       'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
                                                       'э', 'ю', 'я'}; //алфавит
        public static int N = characters.Length; //длина "алфавита"
        public static Boolean isOkay = false;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Кнопка "Зашифровать"
        private void encryptButton_Click(object sender, EventArgs e)
        {
            Check();
            if (isOkay == true)
            {
                string result = EncryptClass.GetWord(GetText, GetKey);
                resultTextBox.Text = result;
            }
            TextBox.Enabled = false;
            keyTextBox.Enabled = false;
        }
        #endregion

        #region Кнопка "Расшифровать"
        private void cryptButton_Click(object sender, EventArgs e)
        {
            Check();
            if (isOkay == true)
            {
                string result = DecipherClass.GetReverseWord(GetText, GetKey);
                resultTextBox.Text = result;
            }
            TextBox.Enabled = false;
            keyTextBox.Enabled = false;
        }
        #endregion

        #region Класс проверка
        public void Check()
        {
            var tempKeytext = keyTextBox.Text; //временное сохранение текста в textbox, чтоб потом их вернуть
            var temptext = TextBox.Text;

            var res = new Regex("[^А-Яа-яЁё ]");
            MatchCollection matched = res.Matches(keyTextBox.Text);
            string errorWord = "";
            for (int count = 0; count < matched.Count; count++)
            {
                errorWord += matched[count].Value;
            }
            if (errorWord != "")
            {
                MessageBox.Show("Ключевое слово может содержать только буквы русского алфавита (без Ё)");
                isOkay = false;
                /*DialogResult dialogResult = MessageBox.Show("Кажется, найдена ошибка(-и) в ключевом слове. Исправить? Ошибки: " + errorWord, "Ошибка", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var resultKeyWord = new Regex("[^А-Яа-яЁё ]").Replace(keyTextBox.Text, string.Empty).ToLower().Replace("ё", "е");
                    keyTextBox.Text = resultKeyWord.Replace(" ", ""); //очистка КЛЮЧЕВОГО СЛОВА от пробелов
                    isOkay = true;
                }
                else
                {
                    isOkay = false;
                }*/
            }
            else
                isOkay = true;

            //проверка пустоты слов
            if ((TextBox.Text == "Здесь нужно писать текст") || (TextBox.Text == "") || (keyTextBox.Text == "Здесь нужно писать ключевое слово") || (keyTextBox.Text == "")) //проверка вводимых слов
            {
                TextBox.Text = "Здесь нужно писать текст";
                keyTextBox.Text = "Здесь нужно писать ключевое слово";
                isOkay = false;
            }

            if (keyTextBox.Text.IndexOf(" ") > -1) //проверка на "пробелы" в ключевом слове
            {
                MessageBox.Show("Ключевое слово не должно содержать пробелов");
                isOkay = false;
            }

            if (keyTextBox.Text.IndexOf("ё") > -1) //замена ё на е
            {
                keyTextBox.Text = keyTextBox.Text.Replace("ё", "е");
            }

            var resultWord = new Regex("[^А-Яа-яЁё ]").Replace(TextBox.Text, string.Empty).ToLower().Replace("ё", "е");
            TextBox.Text = resultWord.Replace(" ", ""); //очистка СЛОВА
            metroProgressBar1.Maximum = TextBox.Text.Length;

            if (isOkay == true)
            {
                GetText = TextBox.Text;
                GetKey = keyTextBox.Text;
            }


            TextBox.Text = temptext;
            keyTextBox.Text = tempKeytext;
        }
        #endregion

        #region Кнопка выхода
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Кнопка "Взломать"
        private async void hackButton_Click(object sender, EventArgs e)
        {
            int maxLengthKey = 16; //максимальная длина ключа

            metroLabel1.Text = "Затраченное на взлом время: 0:00:0:00:0:00.0:000";

            var startTime = System.Diagnostics.Stopwatch.StartNew(); //включение таймера для подсчёта времени взлома
            foreach (Control control in Controls)
            {
                control.Enabled = false;
            } //отклчение всех элементов в форме

            IProgress<int> progress = new Progress<int>(v => metroProgressBar1.Value = v); //изменение прогресс бара
            IProgress<int> nowINT = new Progress<int>(now => nowINTLabel.Text = now.ToString() + "/11"); //изменение цифр около прогресс бара о текущем состоянии

            listBox1.Items.Clear(); //очистка листа в ключами
            metroProgressBar1.Value = 0; //установка значения прогресс бара в 0


            var temptext = TextBox.Text;
            var resultWord = new Regex("[^А-Яа-яЁё ]").Replace(TextBox.Text, string.Empty).ToLower().Replace("ё", "е"); //убираю пробелы, делаю символы маленькими, заменяю Ё на Е

            TextBox.Text = resultWord.Replace(" ", ""); //очистка пробелов
            metroProgressBar1.Maximum = TextBox.Text.Length;
            GetText = TextBox.Text;
            TextBox.Text = temptext;
            List<string> keysFinal = new List<string>();
            try
            {
                keysFinal = await Task.Run(() => HackClass.GetWord(GetText, progress, nowINT, maxLengthKey)); //запуск ВЗЛОМА в отдельном потоке
                //MessageBox.Show("Готово!"); //ниже просто чистка от хуеты всякой (повторяющихся слов и т.д.)
                foreach (var i in keysFinal)
                {
                    listBox1.Items.Add(i);
                }
                List<string> megaFinalList = new List<string>();
                if (keysFinal.Count > 1) //если в листе осталось несколько ключей
                {
                    foreach (var i in keysFinal) //берём 1 элемент
                    {
                        string temp = i.ToString() + i.ToString(); //делаем из этого элемента копию себя (например, АА превратиться в АААА)
                        for (int j = 0; j < 4; j++) //цикл для наращивания этого элемента в АААА, АААААА, АААААААА и т.д.
                        {
                            foreach (var q in keysFinal) //для каждого элемента массива ищем новый элемент и....
                            {
                                if (temp == q) //если этот элемент встречается, то....
                                {
                                    megaFinalList.Add(i.ToString());
                                    
                                }
                            }
                            temp += i;
                        }
                    }
                    //listBox1.Items.Clear();
                    //megaFinalList = megaFinalList.Distinct().ToList(); //удаляем дубликаты
                    listBox1.Items.Clear();
                    foreach (var i in megaFinalList)
                    {
                        listBox1.Items.Add(i);
                    }
                    //я ебал эту хуету
                    //если всё-таки ещё есть ключи, то дальше их 101% больше не будет
                    //а если будет, то я ебал эту хуету дважд
                    if (megaFinalList.Count > 1)
                    {
                        listBox1.Items.Clear();
                        foreach (var i in megaFinalList) //берём 1 элемент
                        {
                            string temp = ""; //делаем из этого элемента копию себя (например, АА превратиться в АААА)
                            for (int j = 0; j < 2; j++) //цикл для наращивания этого элемента в АААА, АААААА, АААААААА и т.д.
                            {
                                temp += i.ToString();
                                //MessageBox.Show(temp);
                                foreach (var q in megaFinalList) //для каждого элемента массива ищем новый элемент и....
                                {
                                    if (temp == q) //если этот элемент встречается, то....
                                    {
                                        listBox1.Items.Add(i);
                                    }
                                }
                            }
                        }
                    }
                }
                List<string> megaBigOverFinalList = new List<string>();
                foreach (string i in listBox1.Items)
                {
                    megaBigOverFinalList.Add(i);
                }
                var sukaebaniyKEY = megaBigOverFinalList.GroupBy(str => str)
                .OrderByDescending(g => g.Count())
                .Select(g => new { Brand = g.Key, Count = g.Count() })
                .First(); //находит самый повторяющийся элемент в ЛИСТЕ

                keyTextBox.Text = sukaebaniyKEY.Brand;
                listBox1.Items.Clear();
                listBox1.Items.Add(sukaebaniyKEY.Brand);

                //типо нажатие кнопки "расшифровать"
                Check();
                if (isOkay == true)
                {
                    string result = DecipherClass.GetReverseWord(GetText, GetKey);
                    resultTextBox.Text = result;
                }


                //MessageBox.Show($"Взломанный ключ: {sukaebaniyKEY.Brand} Count: {sukaebaniyKEY.Count}");
            }
            catch (Exception ex)
            {
                var notif = MessageBox.Show("Выполнить углублённый поиск ключа?", "Не найдено достаточное для взлома количество повторяющихся элементов", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //MessageBox.Show(ex.Message); если нужно будет узнать ошибку

                if (notif == DialogResult.Yes) //ЕСЛИ ЭТА ХУЕТА НИЧЕГО НЕ НАЙДЁТ, ТО ДАТЬ ПО ЕБАЛУ РАЗРАБУ...КХМ...ПЕРЕБОР ДЛЯ МАКСИМАЛЬНОГО КЛЮЧА = 50
                {
                    MessageBox.Show("Эта штука работает только с Божью помощью. О чём ты вообще?", "Ты серьёзно?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            foreach (Control control in Controls)
            {
                control.Enabled = true;
            } //включение всех элементов в форме


            //ВСЁ,ЧТО НИЖЕ - подсчёт времени
            startTime.Stop();
            var resultTime = startTime.Elapsed;

            // elapsedTime - строка, которая будет содержать значение затраченного времени
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);
            metroLabel1.Text = "Затраченное на взлом время: " + elapsedTime;
            TextBox.Enabled = false;
            keyTextBox.Enabled = false;
        }
        #endregion

        #region При выборе ВЗЛОМАННОГО ключевого слова из List
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                keyTextBox.Text = listBox1.SelectedItem.ToString();
                cryptButton.PerformClick();
            }
        }
        #endregion

        #region Кнопка "Очистить TextBox"
        private void clearButton_Click(object sender, EventArgs e)
        {
            TextBox.Text = "Здесь нужно писать текст";
            keyTextBox.Text = "Здесь нужно писать ключевое слово";
            resultTextBox.Text = "Результат";
            listBox1.Items.Clear();
            TextBox.Enabled = true;
            keyTextBox.Enabled = true;
        }
        #endregion

        #region Если изменяется textbox, то появляется/исчезает "ползунок"
        private void resultTextBox_TextChanged(object sender, EventArgs e)
        {
            if (resultTextBox.Text.Length > 2000)
                resultTextBox.ScrollBars = ScrollBars.Both;
            else
                resultTextBox.ScrollBars = ScrollBars.None;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (TextBox.Text.Length > 1250)
                TextBox.ScrollBars = ScrollBars.Both;
            else
                TextBox.ScrollBars = ScrollBars.None;
        }
        #endregion

        #region очистка текст.боксов при нажатии на них
        private void TextBox_Click(object sender, EventArgs e)
        {
            if (TextBox.Text == "Здесь нужно писать текст")
                TextBox.Clear();
        }

        private void keyTextBox_Click(object sender, EventArgs e)
        {
            if (keyTextBox.Text == "Здесь нужно писать ключевое слово")
                keyTextBox.Clear();
        }
        #endregion
    }
}