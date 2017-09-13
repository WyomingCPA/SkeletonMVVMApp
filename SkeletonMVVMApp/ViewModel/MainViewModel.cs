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