using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Buisness
{
	internal interface IGetOffersCommand
	{
		Task<List<Offer>> ExecuteAsync();
	}
}