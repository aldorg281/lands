using System;

namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Services;
    using Views;
    using Xamarin.Forms;

    class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiServices;
        #endregion


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
            apiServices = new ApiService();

            IsRemembered = true;
            IsRunning = false;
            IsEnabled = true;

            // Cuando se logea manualmente: 23-12-2023
            //email = "jzuluoga55@gmail.com";
            //password = "1234";

            ////https://restcountries.com/v3.1/all

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

            // Cuando se logea manualmente: 23-12-2023
            //if (Email!="jzuluoga55@gmail.com" || Password!="1234")
            //{
            //    IsRunning = false;
            //    IsEnabled = true;

            //    await Application.Current.MainPage.DisplayAlert(
            //        "Error",
            //        "Email or password incorrect",
            //        "Accept");
            //    Password = String.Empty;
            //    return;
            //}


            //Logo consumiendo servicio: 23-12-2023
            var connection = await apiServices.CheckConnection();
            if (!connection.IsSuccess) //validando si no hay conexión con API
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        connection.Message,
                        "Accept");
                return;
            }
            var token = await apiServices.GetToken(
                "https://landsapi1.azurewebsites.net", 
                Email, 
                Password);

            if (token == null)
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Something was wrong, please try later",
                        "Accept");
                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))//23-12-2023
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        token.ErrorDescription,
                        "Accept");
                Password = string.Empty;
                return;
            }

            var mainViewModel = MainViewModel.GetInstance(); //llama instancia varias veces: 23-12-2023
            mainViewModel.Token = token;
            mainViewModel.Lands = new LandsViewModel();            
            //llama instancia por unica vez
            //MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

            IsRunning = false;
            IsEnabled = true;


            Email = string.Empty;
            password = string.Empty;

            
        }
        #endregion
    }
}
