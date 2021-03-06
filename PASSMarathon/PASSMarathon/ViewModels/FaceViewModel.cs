﻿using Xamarin.Forms;
using PASSMarathon.Models;
using PASSMarathon.Services;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace PASSMarathon.ViewModels
{
    public class FaceViewModel : BaseViewModel
    {
        public Command PickPhotoCommand { get; set; }
        public Command TakePhotoCommand { get; set; }
        public Command AnalyzePhotoCommand { get; set; }

        private MediaFile photo;

        public MediaFile Photo
        {
            get { return photo; }
            set { photo = value; OnPropertyChanged(); OnPropertyChanged("PhotoStream"); }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public ImageSource PhotoStream
        {
            get => this.photo != null ? ImageSource.FromStream(photo.GetStreamWithImageRotatedForExternalStorage) : null;
        }

        private FaceInfo faceInfo;

        public FaceInfo FaceInfo
        {
            get { return faceInfo; }
            set { faceInfo = value; OnPropertyChanged(); }
        }

        public FaceViewModel()
        {
            PickPhotoCommand = new Command(async () => await PickPhoto());
            TakePhotoCommand = new Command(async () => await TakePhoto());
            AnalyzePhotoCommand = new Command(async () => await AnalyzePhotoAPI());
        }

        private async Task PickPhoto() => await GetPhoto(false);

        private async Task TakePhoto() => await GetPhoto(true);

        private async Task GetPhoto(bool useCamera)
        {
            FaceInfo = new FaceInfo();
            Photo = await ImageService.TakePhoto(useCamera);
        }

        private async Task AnalyzePhotoAPI()
        {
            if (Photo != null)
            {
                IsBusy = true;
                FaceInfo = await FaceService.AnalyzePhoto(photo);
                IsBusy = false;
            }
        }
    }
}
