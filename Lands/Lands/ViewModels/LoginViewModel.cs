using System;

namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    class LoginViewModel : BaseViewModel
    {

        #region Attibutes        
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get{ return password;}
            set{ SetValue(ref password, value);}            
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
        #endregion


        #region Constructors
        public LoginViewModel()
        {
            IsRemembered = true;
            IsRunning = false;
            IsEnabled = true;

            email = "jzuluoga55@gmail.com";
            password = "1234";

            //https://restcountries.com/v3.1/all

        }


        #endregion
        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }           
        }

        

        private async void Login()
        {
         if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    "You must enter an email", 
                    "Accept");
                return;                    
            }
            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password",
                    "Accept");
                return;
            }
            
            IsRunning = true;
            IsEnabled = false;

            if (Email!="jzuluoga55@gmail.com" || Password!="1234")
            {
                IsRunning = false;
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect",
                    "Accept");
                Password = String.Empty;
                return;
            }

            IsRunning = false;
            IsEnabled = true;

            Email = string.Empty;
            password = string.Empty;

            //llama instancia por unica vez
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion
    }
}
