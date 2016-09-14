using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Android.Provider;
using Android.Graphics;
using RaysHotDogs.Utility;

namespace RaysHotDogs
{
    [Activity(Label = "Take A Picture")]
    public class TakePictureActivity : Activity
    {
        private ImageView pictureImageView;
        private Button takePictureButton;
        private File imageDirectory;
        private File imageFile;
        private Bitmap imageBitmap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TakePictureView);

            FindViews();

            HandleEvents();

            imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                Android.OS.Environment.DirectoryPictures), "RaysHotDogs");
            //if folder does not exit create it
            if (!imageDirectory.Exists())
            {
                imageDirectory.Mkdirs();
            }

        }

        private void FindViews()
        {
            pictureImageView = FindViewById<ImageView>(Resource.Id.TakePictureImageView);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            //allow user to take picture with camera app then return to our app 
            var intent = new Intent(MediaStore.ActionImageCapture);
            imageFile = new File(imageDirectory, String.Format("PhotoWithHotDogs_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));

            //expecting result back in application when picture is done
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            int height = pictureImageView.Height;
            int width = pictureImageView.Width;

            imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, height);

            if (imageBitmap != null)
            {
                pictureImageView.SetImageBitmap(imageBitmap);
                imageBitmap = null;
            }

            //required to avoid MEM LEAKS
            GC.Collect();
        }
    }
}