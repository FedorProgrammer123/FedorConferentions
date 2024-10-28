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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace OrganisationConferention
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        private int failedAttempts = 0;
        public Autorization()
        {
            InitializeComponent();
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
             
             var Name = EnterNameBox.Text;
             var Password = EnterPasswordBox.Password;
            using (var model = new Context())
            {
                var ExsistsName = model.Users.Any(u => u.Email == Name && u.Password == Password);
                
                if (ExsistsName)
                {
                    var user = Context.GetContext().Users.Where(d => d.Email ==
                    EnterNameBox.Text &&
                    d.Password == EnterPasswordBox.Password).FirstOrDefault();
                    Manager.Users = user;
                    switch (user.Role) {
                        case 1:
                            MessageBox.Show("Добро пожаловать,Жюри");
                            break;
                        case 2:
                            MessageBox.Show("Добро пожаловать, модератор");
                            break;
                        case 3:
                            MessageBox.Show("Добро пожаловать, организатор");
                            break;
                        case 4:
                            MessageBox.Show("Добро пожаловать, участник");
                            break;
                    }
                }
                else
                {
                    
                    failedAttempts++;
                    string Error = $"Неверный логин или пароль! Кол-во неверных попыток:{failedAttempts}";
                    string caption = "Error";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage image = MessageBoxImage.Error;
                    MessageBoxResult result = MessageBox.Show(Error,caption,button,image);                
                    if (failedAttempts == 2)
                    {
                        ShowCaptchaFields();
                        GenerateCaptcha();
                    }             
                   
                }
            }
        }
        private void GenerateCaptcha()
        {
            string allowChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            string captcha = "";
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                captcha += allowChars[random.Next(allowChars.Length)];
            }

            CaptchaBox.Text = captcha;
        }
        private void ShowCaptchaFields()
        {
            LabelCaptcha.Visibility = Visibility.Visible;
            CaptchaBox.Visibility = Visibility.Visible;
            CaptchaWriteBox.Visibility = Visibility.Visible;
            EnterCaptchaButton.Visibility = Visibility.Visible;
        }

        private async void EnterCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CaptchaWriteBox.Text.Equals(CaptchaBox.Text, StringComparison.Ordinal))
            {
                MessageBox.Show("Неверная капча!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                CaptchaWriteBox.Text = "";
                AutButton.IsEnabled = false;
                await Task.Delay(10000);
                AutButton.IsEnabled = true;
                GenerateCaptcha();
                
                return;
            }
            else
            {
                MessageBox.Show("Капча введена верно. Попробуйте авторизоваться снова");
                LabelCaptcha.Visibility = Visibility.Collapsed;
                CaptchaBox.Visibility = Visibility.Collapsed;
                CaptchaWriteBox.Visibility = Visibility.Collapsed;
                EnterCaptchaButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}
