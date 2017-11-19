using System.Collections.Generic;
using Newtonsoft.Json;

namespace RgrFm.Models
{
    public class PlaylistFeed
    {
        [JsonProperty(PropertyName = "playlist")]
        public List<PlaylistItem> Playlist { get; set; }
    }
}

