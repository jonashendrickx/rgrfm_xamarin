using System.Collections.Generic;
using Newtonsoft.Json;

namespace RgrFm.Contracts.RgrFmWeb.Json
{
    public class PlaylistFeed
    {
        [JsonProperty(PropertyName = "playlist")]
        public List<PlaylistItem> Playlist { get; set; }
    }
}

