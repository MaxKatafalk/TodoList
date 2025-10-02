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
        private Button button1;
        private ListBox listBox1;

        private List<TodoTask> tasks = new List<TodoTask>();
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            SetupControls(); 
        }

        private void SetupControls()
        {
            button1 = new Button();
            button1.Location = new Point(20, 10);
            button1.Width = 290;
            button1.Text = "Добавить задачу";
            button1.BackColor = Color.FromArgb(100, 100, 100);
            button1.ForeColor = Color.White;
            button1.Click += Button1_Click;

            Label Label1 = new Label();
            Label1.Text = "Дважды нажмите на задачу чтобы отметить выполненной";
            Label1.Location = new Point(10, 250);  
            Label1.Width = 400;
            Label1.ForeColor = Color.LightGray;   

            listBox1 = new ListBox();
            listBox1.Location = new Point(10, 40);
            listBox1.Width = 400;
            listBox1.Height = 200;
            listBox1.BackColor = Color.FromArgb(37, 37, 38);
            listBox1.ForeColor = Color.White;
            listBox1.DoubleClick += ListBox1_DoubleClick;

            Button editButton = new Button();
            editButton.Text = "Редактировать";
            editButton.Location = new Point(420, 70);
            editButton.Width = 90;
            editButton.BackColor = Color.FromArgb(100, 100, 100);
            editButton.ForeColor = Color.White;
            editButton.Click += EditButton_Click;

            Button deleteButton = new Button();
            deleteButton.Text = "Удалить";
            deleteButton.Location = new Point(420, 100);
            deleteButton.Width = 90;
            deleteButton.BackColor = Color.FromArgb(150, 50, 50); 
            deleteButton.ForeColor = Color.White;
            deleteButton.Click += DeleteButton_Click;

            Button sortButton = new Button();
            sortButton.Text = "Сортировать";
            sortButton.Location = new Point(320, 10);
            sortButton.Width = 100;
            sortButton.BackColor = Color.FromArgb(100, 100, 100);
            sortButton.ForeColor = Color.White;
            sortButton.Click += SortButton_Click;

            Controls.Add(sortButton);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(editButton);
            Controls.Add(deleteButton);
            Controls.Add(Label1);

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0)
            {
                TodoTask selectedTask = tasks[index];

                EditTaskForm editForm = new EditTaskForm(selectedTask);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    tasks[index] = editForm.ResultTask;

                    listBox1.Items[index] = editForm.ResultTask;
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для редактирования");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0)
            {
                tasks.RemoveAt(index);
                listBox1.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления");
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            SortDialogForm dialog = new SortDialogForm();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.SortType == 0)
                {
                    tasks.Sort(SortByTitleDescending);
                }
                else if (dialog.SortType == 1)
                {
                    tasks.Sort(SortByPriorityDescending);
                }
                else if (dialog.SortType == 2)
                {
                    tasks.Sort(SortByCategoryDescending);
                }
                else if (dialog.SortType == 3)
                {
                    tasks.Sort(SortByDateDescending);
                }
                else if (dialog.SortType == 4)
                {
                    tasks.Sort(SortByStatusDescending);
                }

                listBox1.Items.Clear();
                foreach (TodoTask task in tasks)
                {
                    listBox1.Items.Add(task);
                }
            }
        }

        private int SortByTitleDescending(TodoTask t1, TodoTask t2)
        {
            return string.Compare(t2.Title, t1.Title);
        }

        private int SortByPriorityDescending(TodoTask t1, TodoTask t2)
        {
            return t2.Priority.CompareTo(t1.Priority);
        }

        private int SortByCategoryDescending(TodoTask t1, TodoTask t2)
        {
            return string.Compare(t2.Category, t1.Category);
        }

        private int SortByDateDescending(TodoTask t1, TodoTask t2)
        {
            return t1.DateTodo.CompareTo(t2.DateTodo);
        }

        private int SortByStatusDescending(TodoTask t1, TodoTask t2)
        {
            return t2.IsCompleted.CompareTo(t1.IsCompleted);
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