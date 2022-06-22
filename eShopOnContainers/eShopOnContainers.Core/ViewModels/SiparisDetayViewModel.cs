using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Models.Siparisler;
using eShopOnContainers.Core.Services.Siparis;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class SiparisDetayViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly ISiparisService _siparisService;

        private Siparis _siparis;
        private bool _isSubmittedSiparis;
        private string _siparisStatusText;

        public SiparisDetayViewModel()
        {
            _settingsService = DependencyService.Get<ISettingsService>();
            _siparisService = DependencyService.Get<ISiparisService>();
        }

        public Siparis Siparis
        {
            get => _siparis;
            set
            {
                _siparis = value;
                RaisePropertyChanged(() => Siparis);
            }
        }

        public bool IsSubmittedSiparis
        {
            get => _isSubmittedSiparis;
            set
            {
                _isSubmittedSiparis = value;
                RaisePropertyChanged(() => IsSubmittedSiparis);
            }
        }

        public string SiparisStatusText
        {
            get => _siparisStatusText;
            set
            {
                _siparisStatusText = value;
                RaisePropertyChanged(() => SiparisStatusText);
            }
        }


        public ICommand ToggleCancelSiparisCommand => new Command(async () => await ToggleCancelSiparisAsync());

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            var siparisNumber = query.GetValueAsInt(nameof(Siparis.SiparisNumber));

            if (siparisNumber.ContainsKeyAndValue)
            {
                IsBusy = true;

                // Get order detail info
                var authToken = _settingsService.AuthAccessToken;
                Siparis = await _siparisService.GetSiparisAsync(siparisNumber.Value, authToken);
                IsSubmittedSiparis = Siparis.SiparisStatus == SiparisStatus.Submitted;
                SiparisStatusText = Siparis.SiparisStatus.ToString().ToUpper();

                IsBusy = false;
            }
        }

        private async Task ToggleCancelSiparisAsync()
        {
            var authToken = _settingsService.AuthAccessToken;

            var result = await _siparisService.CancelSiparisAsync(_siparis.SiparisNumber, authToken);

            if (result)
            {
                SiparisStatusText = SiparisStatus.Cancelled.ToString().ToUpper();
            }
            else
            {
                Siparis = await _siparisService.GetSiparisAsync(Siparis.SiparisNumber, authToken);
                SiparisStatusText = Siparis.SiparisStatus.ToString().ToUpper();
            }

            IsSubmittedSiparis = false;
        }
    }
}