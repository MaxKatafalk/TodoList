using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace TodoList
{
    public partial class Form1 : Form
    {
        private TextBox textBox1;
        private Button button1;
        private ListBox listBox1;
        private Button FilterButton;

        private List<TodoTask> tasks = new List<TodoTask>();
        public Form1()
        {
            InitializeComponent();
            SetupControls(); 
        }

        private void SetupControls()
        {
            textBox1 = new TextBox();
            textBox1.Location = new Point(10, 10);
            textBox1.Width = 200;

            button1 = new Button();
            button1.Location = new Point(220, 10);
            button1.Text = "Добавить";
            button1.Click += Button1_Click;

            listBox1 = new ListBox();
            listBox1.Location = new Point(10, 40);
            listBox1.Width = 300;
            listBox1.Height = 200;
            listBox1.DoubleClick += ListBox1_DoubleClick;

            FilterButton = new Button();
            FilterButton.Location = new Point(320, 10);
            FilterButton.Width = 100;
            FilterButton.Text = "Сортировать ▲";
            FilterButton.Click += FilterButton_Click;

            Controls.Add(FilterButton);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            tasks.Sort(CompareTasks);

            listBox1.Items.Clear();
            foreach (var task in tasks)
            {
                listBox1.Items.Add(task);
            }
        }

        private int CompareTasks(TodoTask t1, TodoTask t2)
        {
            return string.Compare(t1.Title, t2.Title);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EditTaskForm editForm = new EditTaskForm();

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                if (editForm.ResultTask != null)
                {
                    tasks.Add(editForm.ResultTask);
                    listBox1.Items.Add(editForm.ResultTask);
                }
            }
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0)
            {
                tasks[index].IsCompleted = !tasks[index].IsCompleted;
                listBox1.Items[index] = tasks[index];
            }
        }

    }

    
}

