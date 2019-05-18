using Android.Content;
using Android.Widget;
using RgrFm.Droid.Common;

namespace RgrFm.Droid.Services
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class MusicPlayerBroadCastReceiver : BroadcastReceiver
    {
        public MainActivity Activity;

        public MusicPlayerBroadCastReceiver()
        {
            
        }

        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action.Equals(MusicPlayerService.PlayerStop))
            {
                Activity.RunOnUiThread(() =>
                {
                    var button = Activity.FindViewById<ImageButton>(Resource.Id.playButton);
                    button.SetImageResource(Resource.Drawable.ic_play_circle_outline_dark_blue_48dp);
                });
            }
        }
    }
}