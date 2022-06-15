using eShopOnContainers.Core.ViewModels;
using eShopOnContainers.Core.ViewModels.Base;
using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Firebase.Database;

namespace eShopOnContainers.Core.Views
{
    public partial class AnaSayfaView : ContentPageBase
    {
        private FiltersView _filterView = new FiltersView();

        //FirebaseClient firebaseClient = new FirebaseClient("");

        public AnaSayfaView()
        {
            InitializeComponent();
            BindingContext = new AnaSayfaViewModel();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            _filterView.BindingContext = BindingContext;
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            Navigation.ShowPopup (_filterView);
        }

        //private void Button_clicked(System.Object sender, System.EventArgs e)
        //{
        //    firebaseClient.Child("Records").PostAsync(new MyDatabaseRecord
        //    {
        //        MyProperty = recordData.txt
        //    });

        //    recordData.txt = "";
        //}
    }
}