using Android.Content;
using Android.Widget;

namespace RgrFm.Droid.Services
{
    [BroadcastReceiver]
    public class MusicPlayerBroadCastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            MainActivity activity = (MainActivity) context;
            if (intent.Action.Equals(MusicPlayerService.PlayerError))
            {
                var button = activity.FindViewById<ImageButton>(Resource.Id.playButton);
                button.SetImageResource(Resource.Drawable.ic_play_circle_outline_white_48dp);
            }
        }
    }
}