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
        public string Title;
        public bool IsCompleted;
        public DateTime Date;
        public int Priority;
        public string Category;
        public DateTime DateTodo;

        public TodoTask(string title)
        {
            Title = title;
            IsCompleted = false;
            Date = DateTime.Now;
            Priority = 1;
            Category = "Общая";
            DateTodo = DateTime.Now;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "[✔] " : "[   ] ";
            string date = Date.ToString("dd.MM.yyyy");
            string dateTodo = DateTodo.ToString("dd.MM.yyyy");

            string text = status + Title + " (" + date + ") - Приоритет " + Priority + " - " + Category + "- до" + DateTodo;

            return text;
        }
    }

}
