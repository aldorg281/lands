
namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;
    using Models; //carpeta models
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LandItemViewModel : Land
        //Hereda de la clase Land
    {
        #region Commands
        public ICommand SelectLandCommand
        {
            get 
            {
                return new RelayCommand(SelectLand);
            }
        }

        private async void SelectLand()
        {
            
            MainViewModel.GetInstance().Land = new LandViewModel(this);//envia toda la clase actual lands a land
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());//invoca pagina con pestañas (tabbed)
        }

        #endregion
    }
}
