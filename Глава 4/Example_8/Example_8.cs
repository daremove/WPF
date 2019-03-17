using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_8
{
    class EditSomeText : Window
    {
        //path.combine - объединяет строки в путь
        //environment.GetFolderPath(особая системная папка)
        //return путь к этой папке, else пустая строка
        //environment enum пути к особым системным папкам
        static string strFileName = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "./EditSomeText.txt");
        //текстовое поле
        TextBox txtbox;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new EditSomeText());
        }
        public EditSomeText()
        {
            Title = "Edit Some Text";

            txtbox = new TextBox();
            //в многострочном элементе управления создаем новую строку
            txtbox.AcceptsReturn = true;
            //указываем свойства переноса (т.е. разрешаем переносить)
            txtbox.TextWrapping = TextWrapping.Wrap;
            //отображается ли вертикальная полоса прокрутки
            txtbox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            //вешаем обработчик событий
            txtbox.KeyDown += TextBoxOnKeyDown;
            //выводим в контент
            Content = txtbox;

            try
            {
                //Открывает текстовый файл, считывает весь текст файла и затем закрывает файл.
                txtbox.Text = File.ReadAllText(strFileName);
            }
            catch
            {

            }

            //Получает или задает индекс позиции вставки для точки ввода.
            txtbox.CaretIndex = txtbox.Text.Length;
            txtbox.Focus();
        }
        //переопределяем метод закрытия
        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                //Создает все каталоги по указанному пути, если они еще не существуют, 
                //с применением заданных параметров безопасности Windows.
                Directory.CreateDirectory(
                    //Возвращает для указанной строки пути сведения о каталоге.
                    Path.GetDirectoryName(strFileName));
                //Создает новый файл, записывает в него указанную строку и затем закрывает файл. 
                //Если целевой файл уже существует, он будет переопределен.
                File.WriteAllText(strFileName, txtbox.Text);
            }
            catch (Exception exc)
            {
                MessageBoxResult result =
                    MessageBox.Show("File could not be saved: " +
                    exc.Message +
                    "\nClose program anyway?", Title,
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Exclamation);

                e.Cancel = (result == MessageBoxResult.No);
            }
        }
        void TextBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                //Получает или задает содержимое текущего выделения в текстовом поле.
                txtbox.SelectedText = DateTime.Now.ToString();
                //Получает или задает индекс символа, определяющий начало текущего выделенного фрагмента.
                txtbox.CaretIndex = txtbox.SelectionStart + txtbox.SelectionLength;
            }
        }
    }
}