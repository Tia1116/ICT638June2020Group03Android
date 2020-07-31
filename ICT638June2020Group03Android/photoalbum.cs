using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace ICT638June2020Group03Android
{
    public class photo
    {
        public int mphotoid { get; set; }
        public string mcaption { get; set; }


    }
    public class PhotoAlbum
    {
        static photo[] listPhoto =
           {
            new photo() {mphotoid = Resource.Drawable.p1, mcaption = "Rent house 1"},
            new photo() {mphotoid = Resource.Drawable.p2, mcaption = "Rent house 2"},
            new photo() {mphotoid = Resource.Drawable.p3, mcaption = "Rent house 3"},
            new photo() {mphotoid = Resource.Drawable.p4, mcaption = "Rent house 4"},
        };
        private photo[] photos;
        public PhotoAlbum()
        {
            this.photos = listPhoto;
        }
        public int numPhoto
        {
            get
            {
                return photos.Length;
            }
        }
        public photo this[int i]
        {
            get { return photos[i]; }
        }
    }
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public PhotoViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemview.FindViewById<TextView>(Resource.Id.textView);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}