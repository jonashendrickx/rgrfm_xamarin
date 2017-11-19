using RgrFm.Models;

namespace RgrFm.Droid.Background
{
    public interface IPlaylistUpdaterTaskListener
    {
        void OnTaskComplete(PlaylistFeed playlist);
    }
}