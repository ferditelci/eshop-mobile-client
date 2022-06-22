using eShopOnContainers.Core.Models.Basket;
using eShopOnContainers.Core.Models.UrunDetay;
using eShopOnContainers.Core.Services.Basket;
using eShopOnContainers.Core.Services.UrunDetay;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.Services.User;
using eShopOnContainers.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class UrunDetayViewModel : ViewModelBase
    {
        private ObservableCollection<UrunMarkasi> _markalar;
        private UrunMarkasi _marka;
        private ObservableCollection<UrunTuru> _turler;
        private UrunTuru _tur;
        private int _badgeCount;
        private IUrunDetayService _urunDetayService;
        private IBasketService _basketService;
        private ISettingsService _settingsService;
        private IUserService _userService;

        public UrunDetayViewModel()
        {
            this.MultipleInitialization = true;

            _urunDetayService = DependencyService.Get<IUrunDetayService>();
            _basketService = DependencyService.Get<IBasketService>();
            _settingsService = DependencyService.Get<ISettingsService>();
            _userService = DependencyService.Get<IUserService>();
        }

        public ObservableCollection<UrunMarkasi> Markalar
        {
            get => _markalar;
            set
            {
                _markalar = value;
                RaisePropertyChanged(() => Markalar);
            }
        }

        public UrunMarkasi Marka
        {
            get => _marka;
            set
            {
                _marka = value;
                RaisePropertyChanged(() => Marka);
                RaisePropertyChanged(() => IsFilter);
            }
        }

        public ObservableCollection<UrunTuru> Turler
        {
            get => _turler;
            set
            {
                _turler = value;
                RaisePropertyChanged(() => Turler);
            }
        }

        public UrunTuru Tur
        {
            get => _tur;
            set
            {
                _tur = value;
                RaisePropertyChanged(() => Tur);
                RaisePropertyChanged(() => IsFilter);
            }
        }

        public bool IsFilter { get { return Marka != null || Tur != null; } }


        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            // Get Catalog, Brands and Types
            Markalar = await _urunDetayService.GetUrunMarkasiAsync();
            Turler = await _urunDetayService.GetUrunTuruAsync();

            IsBusy = false;
        }

    }
}