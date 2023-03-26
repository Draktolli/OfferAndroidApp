using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace App1
{
	[Activity(Label = "OfferDataActivity")]
	public class OfferDataActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.OfferData);

			TextView offerData = FindViewById<TextView>(Resource.Id.textView2);
			offerData.Text = Intent.GetStringExtra("Id");

			Button button = FindViewById<Button>(Resource.Id.button1);
			button.Click += OnClick;
		}

		void OnClick (object sender, EventArgs e)
		{
			Finish();
		}
	}
}