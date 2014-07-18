using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Phoneword_Droid
{



	[Activity (Label = "Phoneword_Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
		Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);



		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it

		}
	}
}


