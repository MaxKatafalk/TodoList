using System;
using System.Drawing;
using System.Windows.Forms;
using TodoList;
using static System.Net.Mime.MediaTypeNames;

public class EditTaskForm : Form
{
    public TodoTask ResultTask;
    private TextBox titleTextBox;
    private NumericUpDown priorityNumeric;
    private TextBox categoryTextBox;
    private DateTimePicker datePicker;
    private Button okButton;
    private Button cancelButton;

    public EditTaskForm()
    {
        this.BackColor = Color.FromArgb(60, 60, 60);
        this.ForeColor = Color.White;

        Text = "Добавить Задачу";
        ClientSize = new Size(350, 270);
        StartPosition = FormStartPosition.CenterScreen;

        GroupBox groupBox = new GroupBox();
        groupBox.Text = "Параметры задачи";
        groupBox.Location = new Point(10, 10);
        groupBox.Size = new Size(320, 200);

        Label titleLabel = new Label();
        titleLabel.Text = "Название задачи:";
        titleLabel.Location = new Point(10, 25);
        titleLabel.Width = 120;

        titleTextBox = new TextBox();
        titleTextBox.Location = new Point(130, 22);
        titleTextBox.Width = 170;
        titleTextBox.Text = "Введите название задачи";
        titleTextBox.ForeColor = Color.Gray;
        titleTextBox.Enter += TitleTextBox_Enter;
        titleTextBox.Leave += TitleTextBox_Leave;

        Label priorityLabel = new Label();
        priorityLabel.Text = "Приоритет (1-10):";
        priorityLabel.Location = new Point(10, 55);
        priorityLabel.Width = 120;

        priorityNumeric = new NumericUpDown();
        priorityNumeric.Location = new Point(130, 52);
        priorityNumeric.Width = 60;
        priorityNumeric.Minimum = 1;
        priorityNumeric.Maximum = 10;
        priorityNumeric.Value = 1;

        Label categoryLabel = new Label();
        categoryLabel.Text = "Категория:";
        categoryLabel.Location = new Point(10, 85);
        categoryLabel.Width = 120;

        categoryTextBox = new TextBox();
        categoryTextBox.Location = new Point(130, 82);
        categoryTextBox.Width = 170;
        categoryTextBox.Text = "Введите категорию";
        categoryTextBox.ForeColor = Color.Gray;
        categoryTextBox.Enter += CategoryTextBox_Enter;
        categoryTextBox.Leave += CategoryTextBox_Leave;

        Label dateLabel = new Label();
        dateLabel.Text = "Срок выполнения:";
        dateLabel.Location = new Point(10, 115);
        dateLabel.Width = 120;

        datePicker = new DateTimePicker();
        datePicker.Location = new Point(130, 112);
        datePicker.Width = 120;
        datePicker.Format = DateTimePickerFormat.Short;
        datePicker.Value = DateTime.Now.AddDays(7);

        okButton = new Button();
        okButton.Text = "OK";
        okButton.Location = new Point(150, 220);
        okButton.Size = new Size(80, 30);
        okButton.DialogResult = DialogResult.OK;
        okButton.Click += OkButton_Click;

        cancelButton = new Button();
        cancelButton.Text = "Отмена";
        cancelButton.Location = new Point(240, 220);
        cancelButton.Size = new Size(80, 30);
        cancelButton.DialogResult = DialogResult.Cancel;

        groupBox.Controls.Add(titleLabel);
        groupBox.Controls.Add(titleTextBox);
        groupBox.Controls.Add(priorityLabel);
        groupBox.Controls.Add(priorityNumeric);
        groupBox.Controls.Add(categoryLabel);
        groupBox.Controls.Add(categoryTextBox);
        groupBox.Controls.Add(dateLabel);
        groupBox.Controls.Add(datePicker);
        Controls.Add(okButton);
        Controls.Add(cancelButton);
        Controls.Add(groupBox);
    }
    public EditTaskForm(TodoTask existingTask) : this() 
    {
        titleTextBox.Text = existingTask.Title;
        priorityNumeric.Value = existingTask.Priority;
        categoryTextBox.Text = existingTask.Category;
        datePicker.Value = existingTask.DateTodo;

        titleTextBox.ForeColor = Color.Black;
        categoryTextBox.ForeColor = Color.Black;
    }
    public void TitleTextBox_Enter(object sender, EventArgs e)
    {
        if (titleTextBox.Text == "Введите название задачи")
        {
            titleTextBox.Text = "";
            titleTextBox.ForeColor = Color.Black;
        }
    }

    public void TitleTextBox_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(titleTextBox.Text))
        {
            titleTextBox.Text = "Введите название задачи";
            titleTextBox.ForeColor = Color.Gray;
        }
    }
    private void CategoryTextBox_Enter(object sender, EventArgs e)
    {
        if (categoryTextBox.Text == "Введите категорию")
        {
            categoryTextBox.Text = "";
            categoryTextBox.ForeColor = Color.Black;
        }
    }
    private void CategoryTextBox_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(categoryTextBox.Text))
        {
            categoryTextBox.Text = "Введите категорию";
            categoryTextBox.ForeColor = Color.Gray;
        }
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(titleTextBox.Text) ||
            titleTextBox.Text == "Введите название задачи")
        {
            MessageBox.Show("Введите название задачи");
            return;
        }

        if (string.IsNullOrWhiteSpace(categoryTextBox.Text) ||
            categoryTextBox.Text == "Введите категорию")
        {
            MessageBox.Show("Введите категорию");
            return;
        }

        ResultTask = new TodoTask(titleTextBox.Text.Trim())
        {
            Priority = (int)priorityNumeric.Value,
            Category = categoryTextBox.Text.Trim(),
            DateTodo = datePicker.Value
        };
    }
}