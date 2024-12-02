using Class4Stat.Model;
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
        private List<Student> _students;

        public List<Student> Students
        {
            get =>_students; 
            set 
            {
                _students = value;
                OnPropertyChanged();
            }
        }


        public Student SelectedStudent {  get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Lastname="Кто то",
                    Initials="К. К.",
                    Hours=100,
                    Questions=10,
                    DoneTasks=25,
                },
                new Student()
                {
                    Id = 2,
                    Lastname="Ещё кто то",
                    Initials="Е. К.",
                    Hours=50,
                    Questions=5,
                    DoneTasks=1,
                },

                new Student()
                {
                    Id = 3,
                    Lastname="Иванов",
                    Initials="И.И.",
                    Hours=90,
                    Questions=0,
                    DoneTasks=20,
                }

            };

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
            int id = Students.Last().Id+1;

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