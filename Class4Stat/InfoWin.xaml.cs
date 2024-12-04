using Class4Stat.Model;
using System.Windows;
using Spire.Doc;
using System.Diagnostics;


namespace Class4Stat
{
    /// <summary>
    /// Логика взаимодействия для InfoWin.xaml
    /// </summary>
    public partial class InfoWin : Window
    {
        public Student SelectedStudent { get; set; }
        public InfoWin(Student student)
        {
            InitializeComponent();
            DataContext = this;
            SelectedStudent = student;
        }

        private void SaveStudentToPDFButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {

                Document document = new Document();
                var section = document.AddSection();
                section.PageSetup.PageSize = new System.Drawing.SizeF(300, 300);

                var p = document.Sections[0].AddParagraph();
                p.AppendText($"Номер студента: {SelectedStudent.Id}");

                p = document.Sections[0].AddParagraph();
                p.AppendText($"Фамилия: {SelectedStudent.Lastname}");

                p = document.Sections[0].AddParagraph();
                p.AppendText($"Инициалы: {SelectedStudent.Initials}");

                p = document.Sections[0].AddParagraph();
                p.AppendText($"Часы: {SelectedStudent.Hours}");

                p = document.Sections[0].AddParagraph();
                p.AppendText($"Вопросы: {SelectedStudent.Questions}");

                p = document.Sections[0].AddParagraph();
                p.AppendText($"Сделанные задания: {SelectedStudent.DoneTasks}");

                p = document.Sections[0].AddParagraph();
                p.AppendText($"Ситуации: ");
                if (SelectedStudent.Situations != null)
                {
                    foreach (var s in SelectedStudent.Situations)
                    {
                        p = document.Sections[0].AddParagraph();
                        p.AppendText($"{s.Description} - {s.Date}");
                    }
                }

                document.SaveToFile($"student{SelectedStudent.Id}.pdf", FileFormat.PDF);
                var info = new ProcessStartInfo("explorer.exe");
                info.Arguments = Environment.CurrentDirectory + $"\\student{SelectedStudent.Id}.pdf";
                Process.Start(info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {

        }
    }
}
