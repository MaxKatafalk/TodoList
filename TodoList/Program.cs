using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class TodoTask
    {
        private string title;
        private bool isCompleted;
        private DateTime date;
        private int priority;
        private string category;
        private DateTime dateTodo;

        public TodoTask(string title)
        {
            this.Title = title;
            this.IsCompleted = false;
            this.Date = DateTime.Now;
            this.Priority = 1;
            this.Category = "";
            this.DateTodo = DateTime.Now;
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public DateTime DateTodo
        {
            get { return dateTodo; }
            set { dateTodo = value; }
        }

        public override string ToString()
        {
            string status = IsCompleted ? "[✔] " : "[   ] ";
            string date = Date.ToString("dd.MM.yyyy");
            string dateTodo = DateTodo.ToString("dd.MM.yyyy");

            string text = status + Title + " (" + date + ") - Приоритет " + Priority + " - " + Category + "- до " + DateTodo;

            return text;
        }
    }

}
