using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVM_app.Models;

namespace MVVM_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        ObservableCollection<Teenus> teenuss;
        //Button lisa, kustuta;
        ListView list;

        public ListPage()
        {
            teenuss = new ObservableCollection<Teenus>
            {
                new Teenus { Nimetus = "Ботокс", Kirjeldus = "Ботокс - это популярный препарат, который содержит инактивированный " +
                "нейротоксин ботулизма типа А. Действующее вещество – очищенный ботулотоксин – является природным протеином, " +
                "вырабатываемым бактериями Clostridium botulinum. Его главная цель – убирать мышечный спазм.", Hind = 90, Pilt="Botox.jpg" },
                new Teenus { Nimetus = "Пилинг", Kirjeldus = "Пилинг - удаление, отшелушивание верхнего ороговевшего слоя кожи, " +
                "один из этапов ухода за кожей, используемый как в кабинете косметолога, так и в домашнем уходе.", Hind = 50, Pilt="Piling.jpg" },
                new Teenus { Nimetus = "Криолиполиз", Kirjeldus = "Криолиполиз - неинвазивная методика коррекции фигуры.", Hind = 179, Pilt="krio.jpg" },
                new Teenus { Nimetus = "Endospheres", Kirjeldus = "Endospheres – всемирно признанная и уважаемая процедура для лица и тела, " +
                "использующая силу компрессивной микровибрации.", Hind = 70, Pilt="endo.jpg" },
                new Teenus { Nimetus = "Лазерная эпиляция", Kirjeldus = "Лазерная эпиляция – процедура, устраняющая волос с помощью лазерного импульса.", Hind = 30, Pilt="lazer.jpg" },
                //new Teenus { Nimetus = "", Kirjeldus = "", Hind = 50, Pilt="" },
                //new Teenus { Nimetus = "", Kirjeldus = "", Hind = 50, Pilt="" },
                //new Teenus { Nimetus = "", Kirjeldus = "", Hind = 50, Pilt="" }
            };

            
            //lisa = new Button { Text = "Lisa teenus" };
            //kustuta = new Button { Text = "Kustuta teenus" };

            list = new ListView
            {
                SeparatorColor = Color.Pink,
                Header = "Teenused",
                Footer = DateTime.Now.ToString("T"),             

                HasUnevenRows = true,
                ItemsSource = teenuss,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Gray, DetailColor = Color.DarkGray };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Kirjeldus", StringFormat = "Vali mind!" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");

                    return imageCell;
                }),
            };

            list.ItemTapped += List_ItemTapped;
            StackLayout stackLayout = new StackLayout
            {
                Children = { list }
            };

            this.Content = stackLayout;
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Teenus selectedTenus = e.Item as Teenus;
            if (selectedTenus != null)
                await DisplayAlert("Valitud teenus", $"{selectedTenus.Kirjeldus} - {selectedTenus.Hind} eur", "OK");
        }

        private void Lisa_Clicked(object sender, EventArgs e)
        {
            Teenus usluga = list.SelectedItem as Teenus;
            if (usluga != null)
            {
                teenuss.Remove(usluga);
                list.SelectedItem = null;
            }
        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            teenuss.Add(new Teenus { Nimetus = "Teenus", Kirjeldus = "Kirjeldus", Hind = 1 });
        }
    }
}
