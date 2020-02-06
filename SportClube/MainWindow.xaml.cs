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
using System.Data.Entity;
using System.Data.SQLite;
namespace SportClube
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rdbPlayer.IsChecked = true;
            DgRefresh();
        }
        public void DgRefresh()
        {
            try
            {
                SportClubeEntities context = new SportClubeEntities();
                if(rdbPlayer.IsChecked==true)
                {
                    
                    //-----
                    var refresh = context.Player.ToList();
                    dgShow.ItemsSource = refresh;
                    dgShow.Columns[0].Header = "شماره";
                    dgShow.Columns[1].Header = "اشتراک";
                    dgShow.Columns[2].Header = "نام";
                    dgShow.Columns[3].Header = "تلفن همراه";
                    dgShow.Columns[4].Header = "تلفن ثابت";
                    dgShow.Columns[5].Header = "تاریخ ثبت";
                    dgShow.Columns[6].Header = "آدرس";
                    dgShow.Columns[7].Header = "تاریخ تولد";
                    dgShow.Columns[8].Header = "ایمیل";
                    dgShow.Columns[9].Header = "توضیحات";
                    dgShow.Columns[10].Header = "عکس";


                }
                //----------
                if (rdbCoach.IsChecked == true)
                {
                    var refresh = context.Coach.ToList();
                    dgShow.ItemsSource = refresh;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SportClubeEntities context = new SportClubeEntities();
                //--------baraye bazikon
                if(rdbPlayer.IsChecked==true)
                {
                    Player player = new Player();
                    player.Name = txtName.Text;
                    player.Phone = txtPhone.Text;
                    player.Tel = txtTel.Text;
                    player.Address = txtAddress.Text;
                    //dorsost kardane tarikh sabt baraye sabt too db
                    //---------
                    string mEnter = dateEnter.SelectedDate.Month.ToString();
                    if (mEnter.Length == 1)
                    {
                        mEnter = "0" + mEnter;
                    }
                    string dEnter = dateEnter.SelectedDate.Day.ToString();
                    if (dEnter.Length == 1)
                    {
                        dEnter = "0" + dEnter;
                    }
                    string date = dateEnter.SelectedDate.Year.ToString() + mEnter + dEnter;
                    //-----------
                    player.Date =int.Parse(date);
                    player.Email = txtEmail.Text;
                    //dorsost kardane tarikh sabt baraye sabt too db
                    //---------
                    string mBirthDay = dateBirhDay.SelectedDate.Month.ToString();
                    if (mBirthDay.Length == 1)
                    {
                        mBirthDay = "0" + mBirthDay;
                    }
                    string dBirthDay = dateBirhDay.SelectedDate.Day.ToString();
                    if (dBirthDay.Length == 1)
                    {
                        dBirthDay = "0" + dBirthDay;
                    }
                    string dateBrithDay = dateBirhDay.SelectedDate.Year.ToString() + mEnter + dEnter;
                    player.BirthDay = int.Parse(dateBrithDay);
                    player.PostalCode = txtPostalCode.Text;
                    player.Description = txtDescription.Text;
                    player.Eshterak = txtEshterak.Text;
                    context.Player.Add(player);
                    context.SaveChanges();
                    //------
                    MessageBox.Show("ثبت شد");
                    DgRefresh();
                }
                //------baraye morabi
                if (rdbCoach.IsChecked == true)
                {
                    Coach coach = new Coach();
                    coach.Name = txtName.Text;
                    coach.Phone = txtPhone.Text;
                    coach.Tel = txtTel.Text;
                    coach.Address = txtAddress.Text;
                    //dorsost kardane tarikh sabt baraye sabt too db
                    //---------
                    string mEnter = dateEnter.SelectedDate.Month.ToString();
                    if (mEnter.Length == 1)
                    {
                        mEnter = "0" + mEnter;
                    }
                    string dEnter = dateEnter.SelectedDate.Day.ToString();
                    if (dEnter.Length == 1)
                    {
                        dEnter = "0" + dEnter;
                    }
                    string date = dateEnter.SelectedDate.Year.ToString() + mEnter + dEnter;
                    //-----------
                    coach.Date = int.Parse(date);
                    coach.Email = txtEmail.Text;
                    //dorsost kardane tarikh sabt baraye sabt too db
                    //---------
                    string mBirthDay = dateBirhDay.SelectedDate.Month.ToString();
                    if (mBirthDay.Length == 1)
                    {
                        mBirthDay = "0" + mBirthDay;
                    }
                    string dBirthDay = dateBirhDay.SelectedDate.Day.ToString();
                    if (dBirthDay.Length == 1)
                    {
                        dBirthDay = "0" + dBirthDay;
                    }
                    string dateBrithDay = dateBirhDay.SelectedDate.Year.ToString() + mEnter + dEnter;
                    coach.BirthDay = int.Parse(dateBrithDay);
                    coach.PostalCode = txtPostalCode.Text;
                    coach.Description = txtDescription.Text;
                    coach.Eshterak = txtEshterak.Text;
                    context.Coach.Add(coach);
                    context.SaveChanges();
                    //------
                    MessageBox.Show("ثبت شد");
                    DgRefresh();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DgRefresh();
        }


    }
}
