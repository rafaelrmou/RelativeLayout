using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace ContactList.Views
{
    public class ContactDetails : ContentPage
    {
        public ContactDetails(Contato contact)
        {
            BackgroundColor = Color.White;

            var backgroundImage = new Image()
            {
                Source = new FileImageSource() { File = contact.ListUrlImages.First() },
                Aspect = Aspect.AspectFill,
                IsOpaque = true,
                Opacity = 0.8
            };

            var boxView = new BoxView()
            {
                Color = Color.Black.MultiplyAlpha(.5)
            };

            var profileImage = new Image()
            {
                Aspect = Aspect.AspectFill,
                Source = new FileImageSource() { File = contact.ProfileUrlImage }
            };

            var details = new DetailsView(contact.Name, contact.Phone, contact.Email, contact.History);
            var picturesSlide = new PicturesSlideView(contact.ListUrlImages);

            RelativeLayout rl = new RelativeLayout()
            {
                HeightRequest = 100
            };


            rl.Children.Add(
                backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * .5;
                })
                );

            rl.Children.Add(
                boxView,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * .5;
                })
                );

            rl.Children.Add(
                profileImage,
                Constraint.RelativeToParent((parent) =>
                {
                    return (parent.Width / 2) - (profileImage.Width / 2);
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * .25;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .5;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * .5;
                })
                );

            rl.Children.Add(
                details,
                Constraint.Constant(0),
                Constraint.RelativeToView(profileImage, (parent, view) =>
                {
                    return view.Y + view.Height;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.Constant(120)
                );

            rl.Children.Add(
                picturesSlide,
                Constraint.Constant(0),
                Constraint.RelativeToView(details, (parent, view) =>
                {
                    return view.Y + view.Height;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.RelativeToView(details, (parent, view) =>
                {
                    var detailsBottomY = view.Y + view.Height;
                    return parent.Height - detailsBottomY;
                })
                );

            this.Content = rl;
        }
    }
}
