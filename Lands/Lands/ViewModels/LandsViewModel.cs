
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
        //Lista paises
    {
        #region Services
        private ApiService apiService;
        #endregion


        #region Attributes
        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefreshing;
        private string filter;
        //private List<Land> landList;
        #endregion

        #region Properties
        public ObservableCollection<LandItemViewModel> Lands
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
                Search(); //ejecuta metodo cada vez que se digita letra en buscador
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
            //landList= (List<Land>)response.Result;
            MainViewModel.GetInstance().LandsList = (List<Land>)response.Result;
            Lands = new ObservableCollection<LandItemViewModel>(
                ToLandItemViewModel());
            IsRefreshing = false;
        }
        #endregion

        #region Methods
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            //return landList.Select(l => new LandItemViewModel
            return MainViewModel.GetInstance().LandsList.Select(l => new LandItemViewModel
            {
                //selecciona lista tipo lands todo los países y lo carga en LandItemViewModel
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings= l.AltSpellings,
                Area=l.Area,
                Borders=l.Borders,
                CallingCodes=l.CallingCodes,
                Capital=l.Capital,
                Cioc=l.Cioc,
                Currencies=l.Currencies,
                Demonym=l.Demonym,                
                Languages=l.Languages,
                Latlng=l.Latlng,
                Name=l.Name,
                NativeName=l.NativeName,
                NumericCode=l.NumericCode,
                Population=l.Population,
                Region=l.Region,
                RegionalBlocs=l.RegionalBlocs,
                Subregion=l.Subregion,
                Timezones=l.Timezones,
                TopLevelDomain=l.TopLevelDomain,
                Translations= l.Translations,
            });
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
            //comando para buscar
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            //metodo para buscar
            if (string.IsNullOrEmpty(Filter))
            {
                //si filtro esta vacío muestra toda la colección
                //Lands = new ObservableCollection<LandItemViewModel>(landsList);
                Lands = new ObservableCollection<LandItemViewModel>(
                ToLandItemViewModel());
            }
            else
            {
                //filtro correcto por name: 25 - 09 - 2023
                Lands = new ObservableCollection<LandItemViewModel>(
                    ToLandItemViewModel().Where(
                l => l.Name.ToLower().Contains(Filter.ToLower())));

                ////filtro correcto por name: 25 - 09 - 2023
                //Lands = new ObservableCollection<LandItemViewModel>(
                //    landsList.Where(
                //l => l.Name.ToLower().Contains(Filter.ToLower())));


                ////filtro correcto por Region: 25-09-2023
                //Lands = new ObservableCollection<Land>(
                //    landsList.Where(
                //l => l.Region.ToLower().Contains(Filter.ToLower())));

                ////filtro por capital falla: 25-09-2023
                //Lands = new ObservableCollection<Land>(
                //    landsList.Where(l => l.Capital.ToLower().Contains(Filter.ToLower())));

                //l = indicador l de lands
                //Contains=busca donde contenga texto

                //////filtro correcto por name o region: 25-09-2023
                //Lands = new ObservableCollection<Land>(
                //    landsList.Where(
                //l => l.Name.ToLower().Contains(Filter.ToLower()) ||
                //   l.Region.ToLower().Contains(Filter.ToLower())));
            }
        }

        #endregion
    }
}
