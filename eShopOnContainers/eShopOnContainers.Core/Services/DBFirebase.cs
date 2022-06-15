using eShopOnContainers.Core.Models;
using eShopOnContainers.Core.Services;
using Firebase.Database.Query;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eShopOnContainers.Core.Models.AnaSayfa;
using eShopOnContainers.Core.Services.RequestProvider;
using eShopOnContainers.Core.Extensions;
using System.Collections.Generic;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Helpers;
using Firebase.Database;

namespace eShopOnContainers.Core.Services.Firebase
{
    public class DBFirebase
    {
        //FirebaseClient client;
        //public DBFirebase()
        //{
        //    client = new FirebaseClient("https://cilek-butik-default-rtdb.firebaseio.com/");
        //}
        //public ObservableCollection<AnaSayfa> getAnaSayfa()
        //{
        //    var anasayfaData = client
        //        .Child("AnaSayfa")
        //        .AsObservable<AnaSayfa>()
        //        .AsObservableCollection();
        //    return anasayfaData;
        //}

        //public async Task AddAnaSayfa(string name, string image, int price)
        //{
        //    AnaSayfa a = new AnaSayfa() { Name = name, image = image, Price = price };
        //    await client
        //        .Child("AnaSayfa")
        //        .PostAsync(a);
        //}
    }
}