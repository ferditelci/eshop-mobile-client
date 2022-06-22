using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Models.Pazarlama;
using eShopOnContainers.Core.Services.Pazarlama;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class KampanyaDetaylarViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IKampanyaService _kampanyaService;

        private KampanyaItem _kampanya;
        private bool _isDetailsSite;

        public ICommand EnableDetailsSiteCommand => new Command(EnableDetailsSite);

        public KampanyaDetaylarViewModel()
        {
            _settingsService = DependencyService.Get<ISettingsService> ();
            _kampanyaService = DependencyService.Get<IKampanyaService> ();
        }

        public KampanyaItem Kampanya
        {
            get => _kampanya;
            set
            {
                _kampanya = value;
                RaisePropertyChanged(() => Kampanya);
            }
        }

        public bool IsDetailsSite
        {
            get => _isDetailsSite;
            set
            {
                _isDetailsSite = value;
                RaisePropertyChanged(() => IsDetailsSite);
            }
        }

        public override async Task InitializeAsync (IDictionary<string, string> query)
        {
            var kampanyaId = query.GetValueAsInt (nameof (Kampanya.Id));

            if (kampanyaId.ContainsKeyAndValue)
            {
                IsBusy = true;
                // Get campaign by id
                Kampanya = await _kampanyaService.GetKampanyaByIdAsync(kampanyaId.Value, _settingsService.AuthAccessToken);
                IsBusy = false;
            }
        }

        private void EnableDetailsSite()
        {
            IsDetailsSite = true;
        }
    }
}