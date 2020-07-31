using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;


namespace ICT638June2020Group03Android
{
    [Activity(MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        PhotoAlbum mPhotoAlbum;
        PhotoAdapter mAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);



            mPhotoAlbum = new PhotoAlbum();




            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);




            mLayoutManager = new LinearLayoutManager(this);



            mAdapter = new PhotoAdapter(mPhotoAlbum);
            mAdapter.ItemClick += MAdapter_ItemClick;



            mRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mRecycleView.SetAdapter(mAdapter);
        }
        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }



    }
}