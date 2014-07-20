using System;




using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ActivityLifecycle
{
	[Activity (Label = "ActivityLifecycle", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int _counter = 0;

		protected override void OnCreate (Bundle bundle)
		{
			Log.Debug(GetType().FullName, "Activity A - OnCreate");
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			FindViewById<Button>(Resource.Id.myButton).Click += (object sender, EventArgs e) => 
			{
				var intent = new Intent(this, typeof(SecondActivity));
				StartActivity(intent);
			};

			if (bundle != null) {
				_counter = bundle.GetInt ("click_count", 0);
				Log.Debug (GetType ().FullName, "Recovered instance state");
			}

			var clickbutton = FindViewById<Button> (Resource.Id.clickButton);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
		}


		protected override void OnSaveInstanceState(Bundle outState)
		{
			outState.PutInt ("click_count", _counter);
			Log.Debug (GetType ().FullName, "Saving instance state");

			base.OnSaveInstanceState (outState);
		}
	}
}


