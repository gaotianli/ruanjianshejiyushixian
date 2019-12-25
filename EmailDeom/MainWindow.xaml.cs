using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using LoadContent;

namespace EmailDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyData myData;
        public MainWindow()
        {
            InitializeComponent();
            myData = new MyData();
            this.DataContext = myData; 
        }

        private void bt_loadContent_Click(object sender, RoutedEventArgs e)
        {
            LoadContent.MainWindow w = new LoadContent.MainWindow();
            w.ShowDialog();
            if(MyData2.ContentwithLoad!=string.Empty)
                myData.Content = MyData2.ContentwithLoad;

        }

        public string FileDialog(string filter)
        {
            //文件全路径
            string localFilePath = "";
            try
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = filter;// "txt files(*.txt)|*.txt";
                openFileDialog.RestoreDirectory = true;
                bool? result = openFileDialog.ShowDialog();

                if (result == true)
                {
                    //获得文件路径
                    return localFilePath = openFileDialog.FileName.ToString();
                }
                return localFilePath;

            }
            catch (Exception ex)
            {
                MessageBox.Show("所选上传文件不正确，请重新选！");
                return localFilePath;
            }
        }

        private void bt_LoadPic_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog("jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|jepg files(*.jepg)|*.jepg");
            myData.PictureFileName = path;
        }

        private void bt_OK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnOK_executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("成功！");
        }

        private void OnOK_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            //分别是email地址不空，email地址符合正确的表达式,内容不空,图片地址不空
            e.CanExecute = !string.IsNullOrEmpty(tb_email.Text) && 
                CheckEmail(tb_email.Text) && 
                !string.IsNullOrEmpty(tb_Content.Text) && 
                !string.IsNullOrEmpty(tb_PicPath.Text);
        }

        private bool CheckEmail(string address)
        {
            string pattern = "^[_a-z0-9-]+(/.[_a-z0-9-]+)*@[a-z0-9-]+(/.[a-z0-9-]+)*$";
            Regex r = new Regex(pattern);
            Match m = r.Match(address);
            if (m.Success)
            {
                return true;
            }
            return false;
        }
    }
}
