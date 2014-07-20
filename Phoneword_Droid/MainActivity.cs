using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Phoneword_Droid
{



	[Activity (Label = "Phoneword_Droid", MainLauncher = true, Icon = "@drawable/Icon")]
	public class MainActivity : Activity
	{

		EditText phoneNumberText;
		Button translateButton;
		Button callButton;
		Button callHistoryButton;

		TextView debugTextView;
		String debugTextViewDefaultText = "Debug msg: ";

		private String callButtonPrefix = "Call ";


		static readonly List<string> phoneNumbers = new List<string>();



		//int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);



			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it

			guiElementeZuordnen ();
		
			addTranslateListener ();
			addCallListener ();
			addCallHistoryListener ();

			callButton.Enabled = false;

			debugTextView = FindViewById<TextView> (Resource.Id.debugTextView);

		}


		private void guiElementeZuordnen ()
		{
			phoneNumberText = FindViewById<EditText> (Resource.Id.PhoneNumberText);
			translateButton = FindViewById<Button> (Resource.Id.TranslateButton);
			callButton = FindViewById<Button> (Resource.Id.CallButton);
			callHistoryButton = FindViewById<Button> (Resource.Id.CallHistoryButton);
		}




		private void addTranslateListener ()
		{

			string translatedNumber = string.Empty;

			translateButton.Click += (object sender, EventArgs e) => {
				translatedNumber = Core.PhoneTranslator.translate (phoneNumberText.Text);
				if (String.IsNullOrWhiteSpace (translatedNumber)) {
					callButton.Enabled = false;
					callButton.Text = "Call";
				} else {
					callButton.Enabled = true;
					callButton.Text = callButtonPrefix + translatedNumber;

				}
			};

		}


		private void addCallListener ()
		{

			callButton.Click += delegate {

				var calldialogConfirm = new AlertDialog.Builder (this);

				String number = callButton.Text.Substring (callButtonPrefix.Length);
				calldialogConfirm.SetMessage ("Realy call " + number + " ?");
				calldialogConfirm.SetNeutralButton ("JA, bitte ruf diese nummer an", delegate {

					/*Toast callDummy = new Toast(this);
					callDummy.SetText("normalerweise würde ich nun callen");
					callDummy.Show(); */


					//hier müsste die nummer in die liste geaddet werden oder? - japs, hatte recht
					phoneNumbers.Add(number);
					callHistoryButton.Enabled = true;



					debugTextView.Text = debugTextViewDefaultText + " würde normalerweise nun " + number + " anrufen";



					
				});
				calldialogConfirm.SetNegativeButton ("Cancel", delegate {
				});


				calldialogConfirm.Show ();

			};


		}


		private void addCallHistoryListener()
		{
			callHistoryButton.Click += (object sender, EventArgs e) => 
			{
				var intent = new Intent(this, typeof(CallHistoryActivity));
				intent.PutStringArrayListExtra("phone_numbers",phoneNumbers);
				StartActivity(intent);
			};
		}





	}
	
}


