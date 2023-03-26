using Android.Content;
using Android.Views;
using Android.Widget;
using App1.Buisness;
using System;
using System.Collections.Generic;
using static Android.Widget.AdapterView;

namespace App1
{
	internal class OfferAdapter : BaseAdapter<string>
	{
		private readonly List<string> Offers;
		private readonly Context context;

		public OfferAdapter(List<string> offers, Context context)
		{
			Offers = offers;
			this.context = context;
		}

		public override int Count
		{
			get
			{
				return Offers.Count;
			}
		}

		public override string this[int position]
		{
			get
			{
				return Offers[position];
			}
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;

			if (view == null)
			{
				view = LayoutInflater.From(context).Inflate(Resource.Layout.OfferItem, null, false);

				TextView textView1 = view.FindViewById<TextView>(Resource.Id.textView1);
				textView1.Text = "Id: " + Offers[position];
			};
			return view;
		}

		public override long GetItemId(int position)
		{
			return position;
		}
	}
}