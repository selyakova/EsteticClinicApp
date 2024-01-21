using MVVM_app.Models;
using Plugin.Messaging;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBFriendPage : ContentPage
    {
        public DBFriendPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked_Salvesta(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                App.Database.SaveItem(friend);
            }
            this.Navigation.PopAsync();
        }

        private void Button_Clicked_Kustuta(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            App.Database.DeleteItem(friend.Id);
            this.Navigation.PopAsync();
        }

        private void Button_Clicked_Loobu(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void Sms_Clicked(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            var smsMessenger = CrossMessaging.Current.SmsMessenger;

            if (smsMessenger.CanSendSms && !String.IsNullOrEmpty(friend.Phone))
                smsMessenger.SendSms(friend.Phone, "Ootame Teid klinikus!");
        }
    }
}
