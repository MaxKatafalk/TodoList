using System;
using System.Drawing;
using System.Windows.Forms;

public class SortDialogForm : Form
{
    public int SortType;

    public SortDialogForm()
    {
        Text = "Выберите сортировку";
        ClientSize = new Size(250, 180);
        StartPosition = FormStartPosition.CenterScreen;

        RadioButton titleRadio = new RadioButton();
        titleRadio.Text = "Названию задачи";
        titleRadio.Location = new Point(20, 20);
        titleRadio.Checked = true;

        RadioButton priorityRadio = new RadioButton();
        priorityRadio.Text = "Приоритету";
        priorityRadio.Location = new Point(20, 45);

        RadioButton categoryRadio = new RadioButton();
        categoryRadio.Text = "Категории";
        categoryRadio.Location = new Point(20, 70);

        RadioButton dateRadio = new RadioButton();
        dateRadio.Text = "Сроку выполнения";
        dateRadio.Location = new Point(20, 95);

        RadioButton statusRadio = new RadioButton();
        statusRadio.Text = "Статусу выполнения";
        statusRadio.Location = new Point(20, 120);

        Button okButton = new Button();
        okButton.Text = "Сортировать";
        okButton.Location = new Point(80, 150);
        okButton.Width = 100;
        okButton.Click += new EventHandler(OkButton_Click);

        void OkButton_Click(object sender, EventArgs e)
        {
            if (titleRadio.Checked) SortType = 0;
            else if (priorityRadio.Checked) SortType = 1;
            else if (categoryRadio.Checked) SortType = 2;
            else if (dateRadio.Checked) SortType = 3;
            else if (statusRadio.Checked) SortType = 4;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        Controls.Add(titleRadio);
        Controls.Add(priorityRadio);
        Controls.Add(categoryRadio);
        Controls.Add(dateRadio);
        Controls.Add(statusRadio);
        Controls.Add(okButton);
    }
}
