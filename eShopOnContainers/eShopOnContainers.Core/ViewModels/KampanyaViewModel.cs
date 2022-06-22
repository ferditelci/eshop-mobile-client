using eShopOnContainers.Core.Models.Pazarlama;
using eShopOnContainers.Core.Services.Pazarlama;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class KampanyaViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IKampanyaService _kampanyaService;

        private ObservableCollection<KampanyaItem> _kampanyalar;

        public KampanyaViewModel()
        {
            _settingsService = DependencyService.Get<ISettingsService> ();
            _kampanyaService = DependencyService.Get<IKampanyaService> ();
        }

        public ObservableCollection<KampanyaItem> Kampanyalar
        {
            get => _kampanyalar;
            set
            {
                _kampanyalar = value;
                RaisePropertyChanged(() => Kampanyalar);
            }
        }

        public ICommand GetKampanyaDetaylarCommand => new Command<KampanyaItem>(async (item) => await GetKampanyaDetaylarAsync(item));

        public override async Task InitializeAsync (IDictionary<string, string> query)
        {
            IsBusy = true;
            // Get campaigns by user
            Kampanyalar = await _kampanyaService.GetAllKampanyalarAsync(_settingsService.AuthAccessToken);
            IsBusy = false;
        }

        private async Task GetKampanyaDetaylarAsync(KampanyaItem kampanya)
        {
            await NavigationService.NavigateToAsync(
                "KampanyaDetaylar",
                new Dictionary<string, string> { { nameof (Kampanya.Id), kampanya.Id.ToString () } });
        }
    }
}