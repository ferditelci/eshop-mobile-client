﻿using eShopOnContainers.Core.Services.AnaSayfa;
using eShopOnContainers.Core.Services.Basket;
using eShopOnContainers.Core.Services.Catalog;
using eShopOnContainers.Core.Services.Dependency;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Services.Identity;
using eShopOnContainers.Core.Services.Kullanici;
using eShopOnContainers.Core.Services.Location;
using eShopOnContainers.Core.Services.Marketing;
using eShopOnContainers.Core.Services.OpenUrl;
using eShopOnContainers.Core.Services.Order;
using eShopOnContainers.Core.Services.Pazarlama;
using eShopOnContainers.Core.Services.RequestProvider;
using eShopOnContainers.Core.Services.Sepetim;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.Services.Siparis;
using eShopOnContainers.Core.Services.UrunDetay;
using eShopOnContainers.Core.Services.User;
using eShopOnContainers.Core.Services.UyeGirisi;
using eShopOnContainers.Services;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels.Base
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        static ViewModelLocator()
        {
            // Services - by default, TinyIoC will register interface registrations as singletons.
            var settingsService = new SettingsService ();
            var requestProvider = new RequestProvider ();
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(settingsService);
            Xamarin.Forms.DependencyService.RegisterSingleton<INavigationService>(new NavigationService(settingsService));
            Xamarin.Forms.DependencyService.RegisterSingleton<IDialogService>(new DialogService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IOpenUrlService>(new OpenUrlService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IRequestProvider>(requestProvider);
            Xamarin.Forms.DependencyService.RegisterSingleton<IIdentityService>(new IdentityService(requestProvider));
            Xamarin.Forms.DependencyService.RegisterSingleton<IDependencyService>(new Services.Dependency.DependencyService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IFixUriService>(new FixUriService(settingsService));
            Xamarin.Forms.DependencyService.RegisterSingleton<ILocationService>(new LocationService(requestProvider));
            Xamarin.Forms.DependencyService.RegisterSingleton<ICatalogService>(new CatalogMockService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IBasketService>(new BasketMockService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IOrderService>(new OrderMockService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUserService>(new UserMockService());
            Xamarin.Forms.DependencyService.RegisterSingleton<ICampaignService>(new CampaignMockService());

            Xamarin.Forms.DependencyService.RegisterSingleton<IAnaSayfaService>(new AnaSayfaMockService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IHesapService>(new HesapService(requestProvider));
            Xamarin.Forms.DependencyService.RegisterSingleton<ISepetimService>(new SepetimMockService());
            Xamarin.Forms.DependencyService.RegisterSingleton<ISiparisService>(new SiparisMockService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IKullaniciService>(new KullaniciMockService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IKampanyaService>(new KampanyaMockService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUrunDetayService>(new UrunDetayMockService());

            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            Xamarin.Forms.DependencyService.Register<BasketViewModel> ();
            Xamarin.Forms.DependencyService.Register<CatalogViewModel> ();
            Xamarin.Forms.DependencyService.Register<CheckoutViewModel> ();
            Xamarin.Forms.DependencyService.Register<LoginViewModel> ();
            Xamarin.Forms.DependencyService.Register<MainViewModel> ();
            Xamarin.Forms.DependencyService.Register<OrderDetailViewModel> ();
            Xamarin.Forms.DependencyService.Register<ProfileViewModel> ();
            Xamarin.Forms.DependencyService.Register<SettingsViewModel> ();
            Xamarin.Forms.DependencyService.Register<CampaignViewModel> ();
            Xamarin.Forms.DependencyService.Register<CampaignDetailsViewModel> ();

            Xamarin.Forms.DependencyService.Register<AnaSayfaViewModel>();
            Xamarin.Forms.DependencyService.Register<AltGiyimViewModel>();
            Xamarin.Forms.DependencyService.Register<AraViewModel>();
            Xamarin.Forms.DependencyService.Register<AnaSayfaViewModel>();
            Xamarin.Forms.DependencyService.Register<DisGiyimViewModel>();
            Xamarin.Forms.DependencyService.Register<HesabimViewModel>();
            Xamarin.Forms.DependencyService.Register<KampanyaDetaylarViewModel>();
            Xamarin.Forms.DependencyService.Register<KampanyaViewModel>();
            Xamarin.Forms.DependencyService.Register<KayitOlViewModel>();
            Xamarin.Forms.DependencyService.Register<SepetimViewModel>();
            Xamarin.Forms.DependencyService.Register<SiparisDetayViewModel>();
            Xamarin.Forms.DependencyService.Register<TumUrunlerViewModel>();
            Xamarin.Forms.DependencyService.Register<UrunDetayViewModel>();
            Xamarin.Forms.DependencyService.Register<UrunlerViewModel>();
            Xamarin.Forms.DependencyService.Register<UstGiyimViewModel>();
            Xamarin.Forms.DependencyService.Register<UyeGirisiViewModel>(); 
        }

        public static void UpdateDependencies(bool useMockServices)
        {
            // Change injected dependencies
            if (useMockServices)
            {
                Xamarin.Forms.DependencyService.RegisterSingleton<ICatalogService>(new CatalogMockService());
                Xamarin.Forms.DependencyService.RegisterSingleton<IBasketService> (new BasketMockService());
                Xamarin.Forms.DependencyService.RegisterSingleton<IOrderService> (new OrderMockService());
                Xamarin.Forms.DependencyService.RegisterSingleton<IUserService> (new UserMockService());
                Xamarin.Forms.DependencyService.RegisterSingleton<ICampaignService> (new CampaignMockService());

                Xamarin.Forms.DependencyService.RegisterSingleton<IAnaSayfaService>(new AnaSayfaMockService());
                Xamarin.Forms.DependencyService.RegisterSingleton<ISepetimService>(new SepetimMockService());
                Xamarin.Forms.DependencyService.RegisterSingleton<ISiparisService>(new SiparisMockService());
                Xamarin.Forms.DependencyService.RegisterSingleton<IKullaniciService>(new KullaniciMockService());
                Xamarin.Forms.DependencyService.RegisterSingleton<IKampanyaService>(new KampanyaMockService());
                Xamarin.Forms.DependencyService.RegisterSingleton<IUrunDetayService>(new UrunDetayMockService());

                UseMockService = true;
            }
            else
            {
                var requestProvider = Xamarin.Forms.DependencyService.Get<IRequestProvider> ();
                var fixUriService = Xamarin.Forms.DependencyService.Get<IFixUriService> ();
                Xamarin.Forms.DependencyService.RegisterSingleton<IBasketService> (new BasketService(requestProvider, fixUriService));
                Xamarin.Forms.DependencyService.RegisterSingleton<ICampaignService> (new CampaignService(requestProvider, fixUriService));
                Xamarin.Forms.DependencyService.RegisterSingleton<ICatalogService> (new CatalogService(requestProvider, fixUriService));
                Xamarin.Forms.DependencyService.RegisterSingleton<IOrderService> (new OrderService(requestProvider));
                Xamarin.Forms.DependencyService.RegisterSingleton<IUserService> (new UserService(requestProvider));

                Xamarin.Forms.DependencyService.RegisterSingleton<IAnaSayfaService>(new AnaSayfaService(requestProvider, fixUriService));
                Xamarin.Forms.DependencyService.RegisterSingleton<ISepetimService>(new SepetimService(requestProvider, fixUriService));
                Xamarin.Forms.DependencyService.RegisterSingleton<ISiparisService>(new SiparisService(requestProvider));
                Xamarin.Forms.DependencyService.RegisterSingleton<IKullaniciService>(new KullaniciService(requestProvider));
                Xamarin.Forms.DependencyService.RegisterSingleton<IKampanyaService>(new KampanyaService(requestProvider, fixUriService));
                Xamarin.Forms.DependencyService.RegisterSingleton<IUrunDetayService>(new UrunDetayService(requestProvider, fixUriService));

                UseMockService = false;
            }
        }

        public static T Resolve<T>() where T : class
        {
            return Xamarin.Forms.DependencyService.Get<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }

            var viewModel = Activator.CreateInstance (viewModelType);

            view.BindingContext = viewModel;
        }
    }
}