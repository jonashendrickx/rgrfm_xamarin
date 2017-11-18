using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RgrFm.Droid.Common
{
    public class Connectivity
    {
        public static bool IsConnected(Context context)
        {
            var cm = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            return cm.ActiveNetworkInfo != null && cm.ActiveNetworkInfo.IsConnected;
        }
    }
}