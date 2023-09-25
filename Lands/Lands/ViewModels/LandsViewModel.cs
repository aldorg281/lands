
namespace Lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    
    using Models;
    using Services;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion


        #region Attributes
        private ObservableCollection<Land> lands;
        private bool isRefreshing;
        private string filter;
        private List<Land> landsList;
        #endregion

        #region Properties
        public ObservableCollection<Land> Lands
        {
            get { return lands; }
            set { SetValue(ref lands, value); }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }
        public string Filter
        {
            get { return filter; }
            set 
            { 
                SetValue(ref filter, value);
                Search();
            }
        }

        #endregion

        #region Constructors
        public LandsViewModel()
        {
           apiService = new ApiService();
           Loadlans();
        }
        #endregion

        #region Methods
        private async void Loadlans()
        {
            IsRefreshing = true;
            var connection = await apiService.CheckConnection();

            if(!connection.IsSuccess )
            {
                IsRefreshing = false ;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            
            var response = await this.apiService.GetList<Land>(
                "http://restcountries.com",
                "/v2",
                "/all");
            //api de paises
            //https://restcountries.com/v2/all

            if (!response.IsSuccess)
            {
                IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            //variable local
            //var list = (List<Land>)response.Result;
            //Lands = new ObservableCollection<Land>(list);

            //variable publica
            landsList = (List<Land>)response.Result;
            Lands = new ObservableCollection<Land>(landsList);
            IsRefreshing = false;
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(Loadlans);
            }

        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(Filter))
            {
                Lands = new ObservableCollection<Land>(landsList);
            }
            else
            {
                Lands = new ObservableCollection<Land>(
                    landsList.Where(
                        l =>l.Name.ToLower().Contains(Filter.ToLower())));
                        //l =>l.Kapital.ToLower().Contains(Filter.ToLower())));
                        
                        

                //l => l.Name.ToLower().Contains(Filter.ToLower()) ||
                //   l.Capital.ToLower().Contains(Filter.ToLower())));
            }
        }

        #endregion
    }
}
