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
    public partial class MainPage : TabbedPage
    {
        List<Image> images;
        private bool isAutoSliding = true;
        private bool isTimerRunning = false;
        public MainPage()
        {
            InitializeComponent();
            images = new List<Image>();
            
            Image image = new Image()
            {
                Source = "test1.jpg",
                Name = "Test 1"
            };
            images.Add(image);
            ChangeImg();  
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadImg();
        }
        private void LoadImg()
        {
            imgCarousel.ItemsSource = null;
            imgCarousel.ItemsSource = images;
        }
        private void ChangeImg()
        {
            if (!isTimerRunning && images.Count != 0)
            {
                Device.StartTimer(TimeSpan.FromSeconds(3), () =>
                {
                    if (!isAutoSliding)
                    {
                        isTimerRunning = false;
                        return false;
                    }
                    imgCarousel.Position = (imgCarousel.Position + 1) % images.Count;
                    isTimerRunning = false;
                    return true;
                });
            }
        }

        private void DelImg(object sender, EventArgs e)
        {
            var btn = sender as Button;
            Image image = (Image)btn.BindingContext;

            if (image != null)
            {
                images.Remove(image);
                LoadImg();
            }
        }
        private void ToggleAutoSlide(object sender, EventArgs e)
        {
            isAutoSliding = !isAutoSliding;

            if (isAutoSliding)
            {
                autoSlide.Text = "Auto slide ON";
                ChangeImg();
            }
            else
            {
                autoSlide.Text = "Auto slide OFF";
                isTimerRunning = false;
            }
        }

        private void AddImg(object sender, EventArgs e)
        {
            string ImgName = nameEntry.Text;
            string ImgSource = sourceEntry.Text;

            if (string.IsNullOrEmpty(ImgName) || string.IsNullOrEmpty(ImgSource))
            {
                DisplayAlert("Błąd", "Podaj dane", "OK");
            }
            else
            {
                Image image = new Image()
                {
                    Name = ImgName,
                    Source = ImgSource,
                };
                images.Add(image);
                LoadImg();
                nameEntry.Text = String.Empty;
                sourceEntry.Text = String.Empty;
            }

        }
    }
}
