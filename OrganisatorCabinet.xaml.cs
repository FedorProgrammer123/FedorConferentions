using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.IO;
namespace OrganisationConferention
{
    /// <summary>
    /// Логика взаимодействия для OrganisatorCabinet.xaml
    /// </summary>
    public partial class OrganisatorCabinet : Page
    {
        private Timer timer;
        public OrganisatorCabinet(Users users)
        {
            InitializeComponent();
            
            if (Manager.Users != null)
            {
                switch (Manager.Users.Gender)
                {
                    case 1:
                        FIOLabel.Text = "Ms - " + $"{Manager.Users.FIO}";
                        break;
                    case 2:
                        FIOLabel.Text = "Mrs - " + $"{Manager.Users.FIO}";
                        break;
                }
                
                if (users.UserPhoto != null && users.UserPhoto.Length > 0)
                {
                    var stream = new MemoryStream(users.UserPhoto);
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();

                    UserImage.Source = image; // UserImage - это элемент Image в вашем XAML
                }
                else
                {
                    // Отобразите сообщение или изображение по умолчанию
                    UserImage.Source = new BitmapImage(new Uri(@"E:\Лисавина\Организация_конференций_2023\OrganisationConferention\Resources\Lisavina.jpg"));
                }
            }
            timer = new Timer(1000);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                DateTime now = DateTime.Now;
                string timeOfDay = DetermineTimeOfDay(now.Hour);
                TimeDisplay.Text = $"{timeOfDay}";
            });
        }
        // Метод определяет время суток на основании текущего часа
        private string DetermineTimeOfDay(int hour)
        {
            if (hour >= 0 && hour < 6)
            {
                return "Доброй Ночи";
            }
            else if (hour >= 6 && hour < 12)
            {
                return "Доброе Утро";
            }
            else if (hour >= 12 && hour < 17)
            {
                return "Доброго дня";
            }
            else
            {
                return "Доброго вечера";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Autorization());
        }
    }
}
