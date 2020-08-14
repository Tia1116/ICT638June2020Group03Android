using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace ICT638June2020Group03Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class Navigation : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private TextView textMessage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Navigation);

            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        [System.Obsolete]
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            TestFragment testFragment = new TestFragment();

            FrameLayout fragCon = FindViewById<FrameLayout>(Resource.Id.fragContainer);
            FragmentTransaction transaction;
            switch (item.ItemId)
            {
                case Resource.Id.navigation_House:
                    textMessage.SetText(Resource.String.title_House);
                    fragCon.RemoveAllViewsInLayout();
                    fragCon.RemoveViews(0, fragCon.ChildCount);
                    transaction = FragmentManager.BeginTransaction();
                    transaction.Replace(Resource.Id.fragContainer, testFragment, "House");
                    transaction.AddToBackStack("House");
                    transaction.Commit();

                    return true;
                case Resource.Id.navigation_Agent:
                    textMessage.SetText(Resource.String.title_Agent);
                    transaction = FragmentManager.BeginTransaction();
                    transaction.Replace(Resource.Id.fragContainer, testFragment, "Agent");
                    transaction.AddToBackStack("Agent");
                    transaction.Commit();
                    return true;
                case Resource.Id.navigation_User:
                    textMessage.SetText(Resource.String.title_User);
                    transaction = FragmentManager.BeginTransaction();
                    transaction.Replace(Resource.Id.fragContainer, testFragment, "User");
                    transaction.AddToBackStack("User");
                    transaction.Commit();
                    return true;
            }
            return false;
        }
    }
}