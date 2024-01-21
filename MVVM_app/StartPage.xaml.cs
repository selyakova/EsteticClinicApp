using MVVM_app.Views;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() {
            new DBListPage(), new ListPage()
        };

        List<string> teksts = new List<string> {
            "Kliendid",
            "Teenused"
        };

        StackLayout st;

        public StartPage()
        {
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Gray,
            };

            Label titleLabel = new Label
            {
                Text = "Estetic Clinic",
                FontSize = 24,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20)
            };
            st.Children.Add(titleLabel);

            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = teksts[i],
                    TabIndex = i,
                    BackgroundColor = Color.Pink,
                    TextColor = Color.Gray,
                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            }

            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}
