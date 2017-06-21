using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using SkeletonMVVMApp.Model;
using SkeletonMVVMApp.Models;


namespace SkeletonMVVMApp.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public static CollectionViewSource view = new CollectionViewSource();

        int currentPageIndex = 0;
        int itemPerPage = 50;
        int totalPage = 0;

        public ObservableCollection<Accounts> AccountsList { get; set; }

        /// <summary>
        /// Gets or sets the main window model.
        /// </summary>
        public MainWindowModel Model
        {
            get; set;
        }

        public RelayCommand NavigateHomeCommand { get; set; }
        public RelayCommand NavigateAccountsManageCommand { get; set; }
        public RelayCommand NavigateLogCommand { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="FacadeViewModel">The facade view model.</param>
        /// <returns></returns>
        public MainViewModel(FacadeViewModel FacadeViewModel)
            : base(FacadeViewModel)
        {
            // Add this VM to the facade.
            FacadeViewModel.MainViewModel = this;
            

            // New model.
            this.Model = MainWindowModel.GetModel();

            // Wire relay commands.
            this.NavigateHomeCommand = new RelayCommand(NavigateHome);
            this.NavigateAccountsManageCommand = new RelayCommand(NavigateAccountsManagePage);
            this.NavigateLogCommand = new RelayCommand(NavigateLogPage);


            List<Accounts> test = new List<Accounts>();
            test.Add(new Accounts("test", "test", "test", "FireFoxProfile"));
            test.Add(new Accounts("test", "test", "test", "FireFoxProfile"));
            test.Add(new Accounts("test", "test", "test", "FireFoxProfile"));
            test.Add(new Accounts("test", "test", "test", "FireFoxProfile"));
            test.Add(new Accounts("test", "test", "test", "FireFoxProfile"));



            AccountsList = new ObservableCollection<Accounts>(test.Select(b => new Accounts(b.Email, "83448344f", b.Country, b.FireFoxProfile)));
            view.Source = AccountsList;
            view.Filter += new FilterEventHandler(view_Filter);

        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = AccountsList.IndexOf((Accounts)e.Item);

            if (index >= itemPerPage * currentPageIndex && index < itemPerPage * (currentPageIndex + 1))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }




        #region Navigation

        /// <summary>
        /// Navigates the home.
        /// </summary>
        private void NavigateHome()
        {
            Model._HomePage = new Uri("/SkeletonMVVMApp;component/Views/_HomePage.xaml", UriKind.Relative);
        }

        /// <summary>
        /// Navigates the get gadgets.
        /// </summary>
        private void NavigateAccountsManagePage()
        {
            Model._HomePage = new Uri("/SkeletonMVVMApp;component/Views/_AccountsManagePage.xaml", UriKind.Relative);
        }

        private void NavigateLogPage()
        {
            Model._HomePage = new Uri("/SkeletonMVVMApp;component/Views/_NavigateLogPage.xaml", UriKind.Relative);
        }

        #endregion Navigation
    }
}