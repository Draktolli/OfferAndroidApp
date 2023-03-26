using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using App1.Buisness;
using App1.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using static Android.Widget.AdapterView;

namespace App1
{
	[Activity(Label = "@string/offer_app", Theme = "@style/AppTheme", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
		ListView listView1;
		List<Offer> list;

		protected async override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_main);

			AppServiceProvider.SetUpServices();

			var command = AppServiceProvider.ServiceProvider.GetService<IGetOffersCommand>();
			list = await command.ExecuteAsync();
			List<string> offerIds = list.Select(x => x.Id.ToString()).ToList();
			listView1 = FindViewById<ListView>(Resource.Id.listView1);

			OfferAdapter adapter = new OfferAdapter(offerIds, this);
			listView1.Adapter = adapter;
			listView1.ItemClick += OnItemClick;
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		void OnItemClick(object sender, ItemClickEventArgs e)
		{
			Intent intent = new Intent(this, typeof(OfferDataActivity));

			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
				Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
			};

			string offer = JsonSerializer.Serialize(list.Where(x => x.Id == list[e.Position].Id).First(), options);
			intent.PutExtra("Id", offer);

			StartActivity(intent);
		}
	}
}