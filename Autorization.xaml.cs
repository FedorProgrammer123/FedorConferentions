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

namespace OrganisationConferention
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
    }
}
