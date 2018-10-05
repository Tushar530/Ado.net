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
using SMS_BLL;
using SMS_Entities;
using SMS_Exceptions;

namespace WPF.PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student_BLL bll = null;

        public MainWindow()
        {
            InitializeComponent();
            bll = new Student_BLL();
        }

        public void populateUI()
        {
            try
            {
                List<Student> stud = bll.GetAll();
                dgStudents.ItemsSource = stud;
                cmbStudName.ItemsSource = stud;
                cmbStudName.DisplayMemberPath = "StudName";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }



        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            populateUI();

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            dgStudents.ItemsSource = bll.GetAll();
        }



        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            /* Student s = new Student();
             s.StudName = "Tushar";
             s.Gender = "Male";
             s.DOB = DateTime.Now.AddYears(-21);
             s.FeesPaid = 25000;
             s.MobileNO = "9999998877";
             s.Email = "fdfa@gm.com";

             bll.Add(s);*/

            try
            {
                if (btnInsert.Content.ToString() == "Insert")
                {
                    Student s = new Student();
                    s.StudName = cmbStudName.Text;
                    s.DOB = (DateTime)dpDob.SelectedDate;
                    s.MobileNO = txtMobile.Text;
                    s.Email = txtEmail.Text;
                    s.FeesPaid = double.Parse(txtFeesPaid.Text);
                    string g = string.Empty;
                    if ((bool)rbMale.IsChecked)
                    {
                        g = rbMale.Content.ToString();
                    }
                    else if ((bool)rbFeMale.IsChecked)
                    {
                        g = rbFeMale.Content.ToString();
                    }
                    s.Gender = g;
                    bll.Add(s);
                    MessageBox.Show("Inserted!");
                    dgStudents.ItemsSource = bll.GetAll();

                    btnInsert.Content = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            /* Student s = new Student();
             s.Rollno = 26;
             s.StudName = "Soni";
             s.Gender = "Female";
             s.DOB = DateTime.Now.AddYears(-28);
             s.FeesPaid = 50000;
             s.MobileNO = "878745877";
             s.Email = "dsa@gm.com";

             bll.Edit(s);
             */
            try
            {
                Student s = (Student)cmbStudName.SelectedItem;
                s.StudName = cmbStudName.Text;
                s.DOB = (DateTime)dpDob.SelectedDate;
                s.MobileNO = txtMobile.Text;
                s.Email = txtEmail.Text;
                s.FeesPaid = int.Parse(txtFeesPaid.Text);

                string g = string.Empty;
                if ((bool)rbMale.IsChecked)
                {
                    g = rbMale.Content.ToString();
                }
                else if ((bool)rbFeMale.IsChecked)
                {
                    g = rbFeMale.Content.ToString();
                }
                s.Gender = g;
                bll.Edit(s);
                MessageBox.Show("Updated!");
                dgStudents.ItemsSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student sobj = (Student)cmbStudName.SelectedItem;
                sobj.StudName = cmbStudName.Text;
                bll.Remove(sobj.StudName);
                MessageBox.Show("Deleted Successfully!!!");
                dgStudents.ItemsSource = bll.GetAll();
            }
            catch (StudentExcpetion ex)
            {
                throw ex;
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
        }
    }


}
