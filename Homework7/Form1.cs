namespace Homework7
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Нажатие на кнопку копировать в меню инструментария
        /// </summary>
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //создание сообщения об нерабочем состоянии кнопки
            string message_copy = "Функция копирования не реализована, приходите позже";
            //Вывод в текстовое поле
            textBox1.Text = message_copy;
        }

        /// <summary>
        /// Нажатие на кнопку вставить в меню инструментария
        /// </summary>
        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //создание сообщения об нерабочем состоянии кнопки
            string message_insert = "Функция вставки также не реализована, но мы стараемся";
            //Вывод в текстовое поле
            textBox1.Text = message_insert;
        }

        /// <summary>
        /// Нажатие на кнопку выхода в меню инструментария
        /// </summary>
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Создание сообщения для уведомления
            string message_quit = "Вы точно хотите выйти из программы?";
            //Создание заголовка для уведомления
            string caption = "Выход";
            //Создание кнопок для уведомления
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //Переменная для хранения результатов ответа пользователя
            DialogResult result;
            //Показ уведомления пользователю
            result = MessageBox.Show(message_quit, caption, buttons);

            //В случае выбора "Да" - приложение закрывается
            if (result == DialogResult.Yes)
            {
                //Закрываем программу
                Close();
            }
        }

        /// <summary>
        /// Логика увеличения и возврата единицы при больше 9
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // Безопасный способ приведения к типу
            if (!(sender is Button button))
            {
                // не отформатировать ли диск?
                return;
            }

            // Создаем обработчик для всех кнопок типа Button
            // Button button = (Button)sender;

            //конвертация числа с кнопки в интовое значение
            int number_1 = Convert.ToInt32(button.Text);
            //если меньше девяти - прибавляем единицу
            if (number_1 < 9)
            {
                //Прибавляем единицу к интовому значению
                number_1++;
            }
            //если больше девяти - сбрасываем до единицы
            else
            {
                number_1 = 1;
            }
            //Возвращаем обратно интовое значение в строку
            string Number_1 = Convert.ToString(number_1);
            //выводим получившееся строковое значение на кнопку
            button.Text = Number_1;

            int N = 0;

            Dictionary<int, int> numbers = new();

            for (int i = 1; i <= 9; i++)
            {
                numbers.Add(i, Convert.ToInt32(Controls[$"button{i}"].Text));
            }
            Dictionary<int, int> sums = new();

            int[,] matrix = new int[,]
                {
                    { 1,2,3 },
                    { 4,5,6 },
                    { 7,8,9 },
                    { 1,5,9 },
                    { 1,4,7 },
                    { 2,5,8 },
                    { 3,6,9 },
                    { 3,5,7 }
                };

            for (int i = 1; i <= matrix.GetLength(0); i++)
            {
                sums.Add(i, 0);
                for (int ii = 0; ii < 3; ii++)
                {
                    sums[i] += numbers[matrix[i - 1, ii]];
                }
                CheckBox cb = (CheckBox)Controls[$"checkBox{i}"];
                cb.Checked = sums[i] == 15;
            }

            foreach (Control control in Controls)
            {
                if (control is CheckBox cb)
                {
                    // CheckBox cb = (CheckBox)control;
                    N += cb.Checked ? 1 : 0;
                }
            }

            textBox1.Text = $"Выполнено {N} из {matrix.GetLength(0)} значений";
        }

        private void сброситьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}