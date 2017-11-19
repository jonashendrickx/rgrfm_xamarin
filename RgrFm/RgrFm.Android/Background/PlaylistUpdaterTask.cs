using System.Threading.Tasks;
using Android.OS;
using RgrFm.Droid.Services;
using RgrFm.Models;

namespace RgrFm.Droid.Background
{
    public class PlaylistUpdaterTask : AsyncTask<object, object, Task<PlaylistFeed>>
    {
        protected override async Task<PlaylistFeed> RunInBackground(params object[] @params)
        {
            return await RgrFmWebService.GetPlaylistAsync();
        }
    }
}