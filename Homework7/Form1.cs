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
        /// ������� �� ������ ���������� � ���� ��������������
        /// </summary>
        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //�������� ��������� �� ��������� ��������� ������
            string message_copy = "������� ����������� �� �����������, ��������� �����";
            //����� � ��������� ����
            textBox1.Text = message_copy;
        }

        /// <summary>
        /// ������� �� ������ �������� � ���� ��������������
        /// </summary>
        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //�������� ��������� �� ��������� ��������� ������
            string message_insert = "������� ������� ����� �� �����������, �� �� ���������";
            //����� � ��������� ����
            textBox1.Text = message_insert;
        }

        /// <summary>
        /// ������� �� ������ ������ � ���� ��������������
        /// </summary>
        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //�������� ��������� ��� �����������
            string message_quit = "�� ����� ������ ����� �� ���������?";
            //�������� ��������� ��� �����������
            string caption = "�����";
            //�������� ������ ��� �����������
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //���������� ��� �������� ����������� ������ ������������
            DialogResult result;
            //����� ����������� ������������
            result = MessageBox.Show(message_quit, caption, buttons);

            //� ������ ������ "��" - ���������� �����������
            if (result == DialogResult.Yes)
            {
                //��������� ���������
                Close();
            }
        }

        /// <summary>
        /// ������ ���������� � �������� ������� ��� ������ 9
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // ���������� ������ ���������� � ����
            if (!(sender is Button button))
            {
                // �� ��������������� �� ����?
                return;
            }

            // ������� ���������� ��� ���� ������ ���� Button
            // Button button = (Button)sender;

            //����������� ����� � ������ � ������� ��������
            int number_1 = Convert.ToInt32(button.Text);
            //���� ������ ������ - ���������� �������
            if (number_1 < 9)
            {
                //���������� ������� � �������� ��������
                number_1++;
            }
            //���� ������ ������ - ���������� �� �������
            else
            {
                number_1 = 1;
            }
            //���������� ������� ������� �������� � ������
            string Number_1 = Convert.ToString(number_1);
            //������� ������������ ��������� �������� �� ������
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

            textBox1.Text = $"��������� {N} �� {matrix.GetLength(0)} ��������";
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}