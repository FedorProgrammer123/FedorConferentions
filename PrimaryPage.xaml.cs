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
using System.Windows.Markup;
using System.Data.Entity.Infrastructure;
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
            Manager.GetImageData();
            init();
        }
        public void init()
        {
            LViewEvents.ItemsSource = Context.GetContext().PlanEvent.ToList();
            var ProduceList = Context.GetContext().PlanEvent.ToList();
            ProduceList.Insert(0, new PlanEvent { Event = "Все события"});
            ComboType.ItemsSource = ProduceList;
            ComboType.SelectedIndex = 0;
            TBoxSearch.Text = string.Empty;
        }
        public List<PlanEvent> _currentProducts = Context.GetContext().PlanEvent.ToList();
        public void Update()
        {
            try
            {
                _currentProducts = Context.GetContext().PlanEvent.ToList();
                _currentProducts = (from item in Context.GetContext().PlanEvent
                                    where item.Event.ToLower().Contains(TBoxSearch.Text) ||
                                    item.ImageName.ToLower().Contains(TBoxSearch.Text) 
                                    select item).ToList();
                var selected = ComboType.SelectedItem as PlanEvent;
                if (selected != null && selected.Event != "Все события")
                {
                    _currentProducts = _currentProducts.Where(d => d.ID_Event == selected.ID_Event).ToList();
                }
                LViewEvents.ItemsSource = _currentProducts;
            }
            catch (Exception ex)
            {

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Autorization());
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
