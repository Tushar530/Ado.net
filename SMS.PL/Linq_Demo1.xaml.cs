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

namespace SMS.PL
{
    /// <summary>
    /// Interaction logic for Linq_Demo1.xaml
    /// </summary>
    public partial class Linq_Demo1 : Window
    {
        public Linq_Demo1()
        {
            InitializeComponent();
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            string[] s_nos = txtNumbers1.Text.Split(',');
            int[] nos = new int[s_nos.Length];
          //  foreach(var item in s_nos)

            for(int i=0; i< s_nos.Length; i++)
            {
                nos[i] = int.Parse(s_nos[i]);
            }

            //var numQuery = from num in s_nos where () 
            var res = from n in nos
                      where n % 2 == 0
                      select n;

            string s_res = string.Empty;
            foreach (var item in res )
            {
               s_res += item + ",";
            }
            MessageBox.Show(s_res);
        }
    }
}
