using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PracaNaLekcji_SliderZdjec
{
    public partial class MainPage : ContentPage
    {
        List<Image> _image;
        private bool _isAutoSliding = true;
        private bool _timerRunning = false;
        public MainPage()
        {
            InitializeComponent();
            _image = new List<Image>();

            var img = new Image()
            {
                Name = "Auto",
                Source = "Red.jpg"
            };

            _image.Add(img);

            ChangeImage();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadImg();
        }
        private void LoadImg()
        {
            imgCarousel.ItemsSource = null;
            imgCarousel.ItemsSource = _image;
        }
        private void ChangeImage()
        {
            if(!_timerRunning)
            {
                Device.StartTimer(TimeSpan.FromSeconds(), () =>
                {
                    if(!_isAutoSliding)
                    {
                        _timerRunning = false;
                        return false;
                    }

                    imgCarousel.Position = (imgCarousel.Position + 1) % _image.Count;
                    _timerRunning = true;
                    return true;
                });
            }
        }
        private void AddImage(object sender, EventArgs e)
        {
            string imageName = ImageNameEntry.Text;
            string imageSource = ImageSourceEntry.Text;

            if (String.IsNullOrEmpty(imageName) || String.IsNullOrEmpty(imageSource))
            {
                DisplayAlert("Info", "Proszę wprowadzić dane", "OK");
            }
            else
            {
                var img = new Image()
                {
                    Name = imageName,
                    Source = imageSource
                };

                _image.Add(img);
                LoadImg();

                ImageNameEntry.Text = string.Empty;
                ImageSourceEntry.Text = string.Empty;
            }
        }

        private void ToggleSlide(object sender, EventArgs e)
        {

        }
    }
}
