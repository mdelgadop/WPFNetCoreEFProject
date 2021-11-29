using MDP_WPFNetCoreProject.ViewModels;
using MDP_WPFNetCoreProject.ViewModels.Base;
using System;
using System.Windows;

namespace MDP_WPFNetCoreProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CountryViewModel myViewModel = new CountryViewModel();
            myViewModel.MessageBoxRequest += new EventHandler<MvvmMessageBoxEventArgs>(OpenMessageBoxRequest);

            this.DataContext = myViewModel;
        }

        private void OpenMessageBoxRequest(object sender, MvvmMessageBoxEventArgs e)
        {
            e.Show();
        }
    }
}
