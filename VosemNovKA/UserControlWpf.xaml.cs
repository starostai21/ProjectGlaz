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
using System.Data;

namespace VosemNovKA
{
    
    
    /// <summary>
    /// Логика взаимодействия для UserControlWpf.xaml
    /// </summary>
    public partial class UserControlWpf : UserControl
    {
        Connect con = new Connect();
        //private ListCollectionView view;
        
        public UserControlWpf()
        {
            InitializeComponent();
        }

        //Загрузка содержимого таблицы
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            string s = "SELECT * from products_k_import";
            grid.ItemsSource = con.ConDT(s).DefaultView;
            // или con.ConDT(s).AsDataView();//result1;
        }

        //Получаем данные из таблицы
        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
           // MyTable path = grid.SelectedItem as MyTable;
        }

        //Получаем данные из таблицы
        private void ContextMenu_insert(object sender, RoutedEventArgs e)
        {
            var item = grid.SelectedItem as DataRowView;
            MessageBox.Show(item.DataView[grid.SelectedIndex][0].ToString().Trim());
        }

        //Получаем данные из таблицы
        private void ContextMenu_updeit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Изменение записи");
        }

        //Получаем данные из таблицы
        private void ContextMenu_delit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Удаление записи");
        }
    }
}
