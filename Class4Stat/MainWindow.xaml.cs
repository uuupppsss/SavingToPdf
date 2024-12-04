using Class4Stat.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Class4Stat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public ObservableCollection<Student> Students { get; set; }
      


        public Student SelectedStudent {  get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            Students = new ObservableCollection<Student>();

        }

        protected virtual void OnPropertyChanged([CallerMemberName]  string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void InfoButtonClick(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Выберите студента");
                return;
            }

            InfoWin win = new InfoWin(SelectedStudent);
            win.ShowDialog();
        }

        private void RemoveStudentButtonClick(object sender, RoutedEventArgs e)
        {
            var responce = MessageBox.Show("Удалить?", "Точно?", MessageBoxButton.YesNo);
            if (responce == MessageBoxResult.Yes)
            {
                if (SelectedStudent == null)
                {
                    MessageBox.Show("Выберите студента");
                    return;
                }

                Students.Remove(SelectedStudent);
            }
            else return;
        }

        private void AddNewStudentButtonClick(object sender, RoutedEventArgs e)
        {
            int id = Students.Count > 0 ? Students.Last().Id + 1 : 1;


            Student student = new Student()
            {
                Id=id
            };
            Students.Add(student);

            InfoWin win= new InfoWin(student);
            win.ShowDialog();
        }
    }
}