using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_9
{
    public class EditSomeRichText : Window
    {
        //Предоставляет элемент управления полем форматированного текста Windows.
        RichTextBox txtbox;
        string strFilter =
            "Document Files(*.xaml)|*.xaml|All files (*.*)|*.*";

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new EditSomeRichText());
        }
        public EditSomeRichText()
        {
            Title = "Edit Some Rich Text";
            txtbox = new RichTextBox();
            txtbox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Content = txtbox;
            txtbox.Focus();
        }
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (e.ControlText.Length > 0 && e.ControlText[0] == '\x0F')
            {
                //Представляет общее диалоговое окно, 
                //позволяющее пользователю задать имя файла для одного или 
                //нескольких открываемых файлов.
                OpenFileDialog dlg = new OpenFileDialog();
                //Получает или задает значение, указывающее, 
                //отображает ли диалоговое окно открытия или 
                //сохранения файла предупреждение, если пользователь указал несуществующее имя файла.
                dlg.CheckFileExists = true;
                //Возвращает или задает строку фильтра, определяющую, 
                //какие типы файлов отображаются в диалоговом окне OpenFileDialog или SaveFileDialog.
                dlg.Filter = strFilter;

                if ((bool)dlg.ShowDialog(this))
                {
                    FlowDocument flow = txtbox.Document;
                    //Представляет выделение содержимого между двумя позициями TextPointer.
                    TextRange range = new TextRange(flow.ContentStart, flow.ContentEnd);

                    //Предоставляет универсальное представление последовательности байтов
                    Stream strm = null;

                    try
                    {
                        //Предоставляет Stream в файле, поддерживая синхронные и 
                        //асинхронные операции чтения и записи.
                        strm = new FileStream(dlg.FileName, FileMode.Open);
                        range.Load(strm, DataFormats.Xaml);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, Title);
                    }
                    finally
                    {
                        if (strm != null)
                            strm.Close();
                    }
                }

                e.Handled = true;
            }

            if (e.ControlText.Length > 0 && e.ControlText[0] == '\x13')
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = strFilter;

                if ((bool)dlg.ShowDialog(this))
                {
                    FlowDocument flow = txtbox.Document;
                    TextRange range = new TextRange(flow.ContentStart, flow.ContentEnd);

                    Stream strm = null;

                    try
                    {
                        strm = new FileStream(dlg.FileName, FileMode.Create);
                        range.Save(strm, DataFormats.Xaml);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, Title);
                    }
                    finally
                    {
                        if (strm != null)
                            strm.Close();
                    }
                }

                //говорим, что событие уже обработано и нажатие клавиш не нужно перевадать richtextbox
                e.Handled = true;
                base.OnPreviewTextInput(e);
            }
        }
    }
}