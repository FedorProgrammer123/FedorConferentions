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

namespace OrganisationConferention
{
    /// <summary>
    /// Логика взаимодействия для PrimaryPage.xaml
    /// </summary>
    public partial class PrimaryPage : Page
    {
        public PrimaryPage()
        {
            InitializeComponent();
            var currentTasks = Context.GetContext().ShortInformation.ToList();
            LViewEvents.ItemsSource = currentTasks;
            var allTypes = Context.GetContext().PlanEvent.ToList();
            allTypes.Insert(0, new PlanEvent { Event = "Все типы" });
            ComboType.ItemsSource = allTypes;
            ComboType.SelectedIndex = 0;
        }
    }
}
