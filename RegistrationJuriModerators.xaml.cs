using Microsoft.Win32;
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
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Security;
using System.Text.RegularExpressions;
namespace OrganisationConferention
{
    /// <summary>
    /// Логика взаимодействия для RegistrationJuriModerators.xaml
    /// </summary>
    public partial class RegistrationJuriModerators : Page
    {
        private readonly Random _random = new Random();
        // Шаблоны для различных требований к паролю
        private static readonly Regex upperCaseRegex = new Regex("[A-Z]");
        private static readonly Regex lowerCaseRegex = new Regex("[a-z]");
        private static readonly Regex digitRegex = new Regex(@"\d");
        private static readonly Regex specialCharRegex = new Regex(@"[^a-zA-Z0-9]");
        public RegistrationJuriModerators()
        {
            InitializeComponent();
            DataContext = this;
            int randomId = _random.Next(64, Int32.MaxValue); // Генерация случайного числа начиная с 64 до максимального значения типа int
            EnterIDBox.Text = randomId.ToString(); // Отображение случайного ID в текстовом поле
            EnterGenderBox.ItemsSource =  Context.GetContext().Gendre.ToList();
            EnterRoleBox.ItemsSource = Context.GetContext().Roles.ToList();
            EnterEventsBox.ItemsSource = Context.GetContext().UserEvents.ToList();
            EnterDirectionBox.ItemsSource = Context.GetContext().Directions.ToList();

            //Переменные
            
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Multiselect = false,
                CheckFileExists = true
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Загружаем изображение
                    var bitmap = new Bitmap(filePath);
                    MemoryStream memory = new MemoryStream();
                    bitmap.Save(memory, ImageFormat.Png); // Преобразуем в PNG для совместимости с WPF
                    memory.Position = 0;

                    // Создаем объект BitmapImage и загружаем данные из потока
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = memory;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();

                    LoadJuryImage.Source = image; // Меняем источник изображения
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                }
            }
        }

        private void VisiblePassword_Click(object sender, RoutedEventArgs e)
        {
            if (VisiblePassword.IsChecked == true)
            {
                PasswordEnter.Visibility = Visibility.Visible;
                passwordEnterTextBox.Visibility = Visibility.Collapsed;
                // Копирование текста из TextBox в PasswordBox
                PasswordEnter.Text = passwordEnterTextBox.Password;

                PasswordConfirmEnterTextBox.Visibility = Visibility.Visible;
                PasswordConfirmEnter.Visibility = Visibility.Collapsed;

                PasswordConfirmEnterTextBox.Text = passwordEnterTextBox.Password;
            }
            else
            {
                PasswordEnter.Visibility = Visibility.Collapsed;
                passwordEnterTextBox.Visibility = Visibility.Visible;

                PasswordConfirmEnterTextBox.Visibility = Visibility.Collapsed;
                PasswordConfirmEnter.Visibility = Visibility.Visible;
                // Копирование пароля из PasswordBox в TextBox
                passwordEnterTextBox.Password = PasswordEnter.Text;
                PasswordConfirmEnter.Password = PasswordConfirmEnterTextBox.Text;
            }
        }

        private void RegJuryButton_Click(object sender, RoutedEventArgs e)
        {
            string FIO = EnterFIOBox.Text;
            string EnterGender = EnterGenderBox.Text;
            string RoleBox =  EnterRoleBox.Text;
            string Email = EnterEmailBox.Text;
            string phone = EnterPhoneBox.Text;
            string direction = EnterDirectionBox.Text;
            string events = EnterEventsBox.Text;
            string password = passwordEnterTextBox.Password;
            string confirm_password = PasswordConfirmEnter.Password;
            if (!Regex.IsMatch(FIO, @"^[а-яА-Я a-zA-Z]+(?:\s+[А-ЯЁ][а-яё]+)*$") || FIO == "" || FIO == " ")
            {
                // Отменяем ввод, если это не буква
                e.Handled = true;

                // Показываем сообщение об ошибке
                MessageBox.Show("Допускаются только буквы!", "Ошибка ввода");
            }
            else if (EnterGender.ToString() == "" || EnterGender.ToString() == " ")
            {
                MessageBox.Show("Поле не может быть пустым");
            }
            else if (RoleBox.ToString() == "" || RoleBox.ToString() == " ")
            {
                MessageBox.Show("Поле не может быть пустым");
            }
            else if (!Regex.IsMatch(Email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@[\w\-]+(\.[\w\-]+)+$") || Email == "" || Email == " ")
            {
                MessageBox.Show("Неверный формат Email");
            }
            else if (!Regex.IsMatch(phone, @"^\+?7\s?\((\d{3})\)\s?(\d{3})-?(\d{2})-?(\d{2})$"))
            {
                MessageBox.Show("Неверный формат телефона");
            }
            else if (direction.ToString() == "" || direction.ToString() == " ")
            {
                MessageBox.Show("Поле не может быть пустым");
            }
            else if (events.ToString() == "" || events.ToString() == " ")
            {
                MessageBox.Show("Поле не может быть пустым");
            }

            else if (password.Length < 6 || !Regex.IsMatch(password, @"^[A-Z][a-z]") && !Regex.IsMatch(password,@"\d") && !Regex.IsMatch(password, @"[^a-zA-Z0-9]"))
            {
                MessageBox.Show("Неверный формат пароля");
            }
            else if (confirm_password.Length < 6 || !Regex.IsMatch(confirm_password, @"^[A-Z][a-z]") && !Regex.IsMatch(confirm_password, @"\d") && !Regex.IsMatch(confirm_password, @"[^a-zA-Z0-9]"))
            {
                MessageBox.Show("Неверный формат пароля");
            }
            else
            {
                using (var model = new Context())
                {
                    var genderId = Context.GetContext().Gendre.FirstOrDefault(u => u.Gendre == EnterGender)?.ID_Gendre ?? -1;
                    var directionId = Context.GetContext().Directions.FirstOrDefault(u => u.Direction == direction)?.ID_Direction ?? -1;
                    var eventsId = Context.GetContext().UserEvents.FirstOrDefault(u => u.Events == events)?.ID_Events ?? -1;
                    var roleId = Context.GetContext().Roles.FirstOrDefault(u => u.Roles == RoleBox)?.ID_Role ?? -1;
                    if (genderId != -1 && directionId != -1 && eventsId != -1)
                    {
                        var user = new Users()
                        {
                            FIO = FIO,
                            Gender = genderId,
                            Email = Email,
                            Phone = phone,
                            Direction = directionId,
                            Events = eventsId,
                            Password = password,
                            Role = roleId
                        };
                        Context.GetContext().Users.Add(user);
                        Context.GetContext().SaveChanges();
                        MessageBox.Show("Успешная регистрация");
                    }
                    else
                    {
                        MessageBox.Show("Не все данные введены");
                    }
                }               
            }
        }
    }
}
