using eShopOnContainers.Core.Models.AnaSayfa;
using eShopOnContainers.Core.Models.Basket;
using eShopOnContainers.Core.Models.Catalog;
using eShopOnContainers.Core.Services.AnaSayfa;
using eShopOnContainers.Core.Services.Basket;
using eShopOnContainers.Core.Services.Catalog;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.Services.User;
using eShopOnContainers.Core.ViewModels.Base;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class AnaSayfaViewModel : ViewModelBase
    {
        public class ConfigFirebase
        {
            public static string FirebaseClient = "https://cilek-butik-default-rtdb.firebaseio.com/";
            public static string FrebaseSecret = "vpb79ESa6zz6EYlS2XmH5mgRZxnoRnyIwjGc1wXd";
        }
        /// <summary>
        /// Setting up a Firebase Client with App Secrect Auth
        /// </summary>
        public FirebaseClient fc = new FirebaseClient(ConfigFirebase.FirebaseClient,
                                    new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(ConfigFirebase.FrebaseSecret) }); //The ConfigFirebase class containts the required values 

        public ICommand RefreshListCommand { get; set; }
        public ICommand PostCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        //count for only loading 5 items into listview
        public int listcount = 5;

        /// <summary>
        /// MainPage View Model initializiation
        /// </summary>


        /// <summary>
        /// Gets a list of ItemsModel
        /// </summary>
        private async void GetData()
        {

            Items = new ObservableCollection<AnaSayfaItem>();

            var GetItems = (await fc
              .Child("ItemTable")
              .OnceAsync<AnaSayfaItem>()).Select(item => new AnaSayfaItem
              {
                  Name = item.Object.Name,
                  Price = item.Object.Price,
                  Key = item.Key
              });

            int count = 0;
            foreach (var item in GetItems)
            {

                Items.Add(item);
                count++;
                if (count >= listcount)
                    break;
            }

        }

        /// <summary>
        /// Posts a new ItemsModel
        /// </summary>
        private async void Post()
        {

            if (!string.IsNullOrEmpty(InputDescription))
            {

                await fc.Child("ItemTable")
                 .PostAsync(new AnaSayfaItem() { Name = InputDescription, Price = InputPrice });

                GetData();

                InputDescription = null;
                

            }

        }

        /// <summary>
        /// Deletes one of the ItemsModel from the Items listview
        /// </summary>
        private async void Delete()
        {
            var selected = Items.Where(k => k.Key == SelectedKey.Key).FirstOrDefault();

            await fc.Child("ItemTable").Child(selected.Key).DeleteAsync();

            Items.Remove(selected);
        }

        /// <summary>
        /// Updates the Description of a specified ItemsModel in the Items listview
        /// </summary>
        private async void Update()
        {
            var selected = Items.Where(k => k.Key == SelectedKey.Key).FirstOrDefault();

            await fc.Child("ItemTable").Child(selected.Key).PutAsync(new AnaSayfaItem() { Name = selected.Name, Price = selected.Price });

        }


        /// <summary>
        /// Refreshes the listview
        /// </summary>
        private void PerformRefresh()
        {
            GetData();
        }

        private ObservableCollection<AnaSayfaItem> items;
        public ObservableCollection<AnaSayfaItem> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        private string inputdescription;
        
        public string InputDescription
        {
            get => inputdescription;
            set
            {
                inputdescription = value;
                OnPropertyChanged();
            }
        }

        private int inputprice;
        public int InputPrice
        {
            get => inputprice;
            set
            {
                inputprice = value;
                OnPropertyChanged();
            }
        }

        private AnaSayfaItem selectedkey;
        public AnaSayfaItem SelectedKey
        {
            get => selectedkey;
            set
            {

                selectedkey = value;
                OnPropertyChanged();
            }
        }

        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<CatalogItem> _products;
        private CatalogItem _selectedProduct;
        private ObservableCollection<CatalogBrand> _brands;
        private CatalogBrand _brand;
        private ObservableCollection<CatalogType> _types;
        private CatalogType _type;
        private int _badgeCount;
        private ICatalogService _catalogService;
        private IBasketService _basketService;
        private ISettingsService _settingsService;
        private IUserService _userService;
        private IAnaSayfaService _anasayfaService;

        private ObservableCollection<AnaSayfaItem> _urunler;
        private AnaSayfaItem _selectedUrun;

        public AnaSayfaViewModel()
        {
            this.MultipleInitialization = true;

            _catalogService = DependencyService.Get<ICatalogService> ();
            _basketService = DependencyService.Get<IBasketService> ();
            _settingsService = DependencyService.Get<ISettingsService> ();
            _userService = DependencyService.Get<IUserService> ();

            _anasayfaService = DependencyService.Get<IAnaSayfaService>();



            RefreshListCommand = new Command(PerformRefresh);
            PostCommand = new Command(Post);
            DeleteCommand = new Command(Delete);
            UpdateCommand = new Command(Update);

            GetData();
        }

        public ObservableCollection<CatalogItem> Products
        {
            get => _products;
            set
            {
                _products = value;
                RaisePropertyChanged(() => Products);
            }
        }

        public CatalogItem SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (value == null)
                    return;
                _selectedProduct = null;
                RaisePropertyChanged(() => SelectedProduct);
            }
        }

        public ObservableCollection<AnaSayfaItem> Urunler
        {
            get => _urunler;
            set
            {
                _urunler = value;
                RaisePropertyChanged(() => Urunler);
            }
        }

        public AnaSayfaItem SelectedUrun
        {
            get => _selectedUrun;
            set
            {
                if (value == null)
                    return;
                _selectedUrun = null;
                RaisePropertyChanged(() => SelectedUrun);
            }
        }

        public ObservableCollection<CatalogBrand> Brands
        {
            get => _brands;
            set
            {
                _brands = value;
                RaisePropertyChanged(() => Brands);
            }
        }

        public CatalogBrand Brand
        {
            get => _brand;
            set
            {
                _brand = value;
                RaisePropertyChanged(() => Brand);
                RaisePropertyChanged(() => IsFilter);
            }
        }

        public ObservableCollection<CatalogType> Types
        {
            get => _types;
            set
            {
                _types = value;
                RaisePropertyChanged(() => Types);
            }
        }

        public CatalogType Type
        {
            get => _type;
            set
            {
                _type = value;
                RaisePropertyChanged(() => Type);
                RaisePropertyChanged(() => IsFilter);
            }
        }

        public bool IsFilter { get { return Brand != null || Type != null; } }

        public int BadgeCount
        {
            get => _badgeCount;
            set
            {
                _badgeCount = value;
                RaisePropertyChanged(() => BadgeCount);
            }
        }

        public ICommand AddCatalogItemCommand => new Command<CatalogItem>(AddCatalogItem);

        public ICommand FilterCommand => new Command(async () => await FilterAsync());

		public ICommand ClearFilterCommand => new Command(async () => await ClearFilterAsync());

        public ICommand ViewBasketCommand => new Command (async () => await ViewBasket ());

        public ICommand AddAnaSayfaItemCOmmand => new Command<AnaSayfaItem>(AddAnaSayfaItem);

        public override async Task InitializeAsync (IDictionary<string, string> query)
        {
            IsBusy = true;

            // Get Catalog, Brands and Types
            Products = await _catalogService.GetCatalogAsync ();
            Brands = await _catalogService.GetCatalogBrandAsync ();
            Types = await _catalogService.GetCatalogTypeAsync ();
            //Urunler = await _anasayfaService.GetAnaSayfaAsync();

            var authToken = _settingsService.AuthAccessToken;
            var userInfo = await _userService.GetUserInfoAsync (authToken);

            var basket = await _basketService.GetBasketAsync (userInfo.UserId, authToken);

            BadgeCount = basket?.Items?.Count () ?? 0;

            IsBusy = false;
        }

        private async void AddCatalogItem(CatalogItem catalogItem)
        {
            var authToken = _settingsService.AuthAccessToken;
            var userInfo = await _userService.GetUserInfoAsync (authToken);
            var basket = await _basketService.GetBasketAsync (userInfo.UserId, authToken);
            if(basket != null)
            {
                basket.Items.Add (
                    new BasketItem
                    {
                        ProductId = catalogItem.Id,
                        ProductName = catalogItem.Name,
                        PictureUrl = catalogItem.PictureUri,
                        UnitPrice = catalogItem.Price,
                        Quantity = 1
                    });

                await _basketService.UpdateBasketAsync (basket, authToken);
                BadgeCount = basket.Items.Count ();
            }
        }

        private async void AddAnaSayfaItem(AnaSayfaItem anasayfaItem)
        {
            var authToken = _settingsService.AuthAccessToken;
            var userInfo = await _userService.GetUserInfoAsync(authToken);
            var basket = await _basketService.GetBasketAsync(userInfo.UserId, authToken);
            if (basket != null)
            {
                basket.Items.Add(
                    new BasketItem
                    {
                        ProductId = anasayfaItem.Id,
                        ProductName = anasayfaItem.Name,
                        PictureUrl = anasayfaItem.PictureUri,
                        UnitPrice = anasayfaItem.Price,
                        Quantity = 1
                    });

                await _basketService.UpdateBasketAsync(basket, authToken);
                BadgeCount = basket.Items.Count();
            }
        }

        private async Task FilterAsync()
        {
            try
            {    
                IsBusy = true;

                if (Brand != null && Type != null)
                {
                    Products = await _catalogService.FilterAsync(Brand.Id, Type.Id);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ClearFilterAsync()
        {
            IsBusy = true;

            Brand = null;
            Type = null;
            Products = await _catalogService.GetCatalogAsync();

            IsBusy = false;
        }

        private Task ViewBasket()
        {
            return NavigationService.NavigateToAsync ("Basket");
        }
    }
}