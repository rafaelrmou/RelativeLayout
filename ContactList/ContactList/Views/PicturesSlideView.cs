using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ContactList.Views
{
    public class PicturesSlideView : ContentView
    {
        public PicturesSlideView(List<string> contactUrlImages)
        {
            HeightRequest = 200;

            var stackLayout = new StackLayout()
            {
                Padding = new Thickness(0, 0, 0, 10),
                Orientation = StackOrientation.Horizontal,
                Spacing = 10
            };

            foreach (string urlImage in contactUrlImages)
            {
                var image = new Image()
                {
                    Source = new FileImageSource() { File = urlImage }
                };
                stackLayout.Children.Add(image);
            }

            Content = new ScrollView()
            {
                Content = stackLayout,
                Orientation = ScrollOrientation.Horizontal
            };
        }
    }
}
