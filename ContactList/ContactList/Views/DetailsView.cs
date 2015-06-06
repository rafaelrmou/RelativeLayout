using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ContactList.Views
{
    public class DetailsView : ContentView
    {
        public DetailsView(string contactName, string contactPhone, string contactMail, string contactHistory)
        {
            var name = new Label()
            {
                Text = contactName,
                FontSize = 20,
                FontFamily = Device.OnPlatform("HelveticaNeue-Bold", "sans-serif-black", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.Black
            };

            var mail_phone = new Label()
            {
                Text = contactMail + Environment.NewLine + contactPhone,
                FontSize = 12,
                FontFamily = Device.OnPlatform("HelveticaNeue-Bold", "sans-serif-black", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.FromHex("#666")
            };

            var history = new Label()
            {
                Text = contactHistory,
                FontSize = 14,
                FontFamily = Device.OnPlatform("HelveticaNeue-Bold", "sans-serif-black", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.Black
            };

            var stacklayout = new StackLayout()
            {
                Padding = new Thickness(20, 10),
                Children = {
                    name,
                    mail_phone,
                    history
                }
            };

            Content = stacklayout;
        }
    }
}
