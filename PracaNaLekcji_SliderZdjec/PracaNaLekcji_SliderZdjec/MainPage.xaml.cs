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
        public MainPage()
        {
            InitializeComponent();
        }
        private void LoadImg()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Images");
            List<Image> images = new List<Image>();

            if(Directory.Exists(path))
            {
                string[] imgFiles = Directory.GetFiles(path);

                foreach(var imgFile in imgFiles)
                {
                    images.Add(new Image { Source = FileImageSource.FromFile(imgFile), Name = imgFile });
                }
            }
            else
            {
                Console.WriteLine("Ścieżka do folderu nie istnieje");
            }
            imgCarousel.ItemsSource = images;
        }

        private void DelImg(object sender, EventArgs e)
        {

        }

        private async void GoToGallery(object sender, EventArgs e)
        {
            
        }
    }
}
