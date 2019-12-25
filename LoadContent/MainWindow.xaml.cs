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
using System.Windows.Shapes;

namespace LoadContent
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            u = new MyData2();
            this.DataContext = u;
        }

        private MyData2 u;
        private void bt_LoadText_Click(object sender, RoutedEventArgs e)
        {
            string path = "";
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "txt files(*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                //获得文件路径
                path = openFileDialog.FileName.ToString();
            }
            tb_path.Text = path;
            string content = u.ReadFile(path, u.Encodings[cbx_encode.SelectedIndex]);
            u.Content = content;
        }


        private void bt_Ok_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_content.Text))
            {
                MyData2.ContentwithLoad = tb_content.Text;
            }
            this.Close();
        }

        private void bt_Cancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
