using Newtonsoft.Json;

namespace RgrFm.Contracts.RgrFmWeb.Json
{
    public class PlaylistItem
    {
        [JsonProperty(PropertyName = "artist")]
        public string Artist { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }
    }
}
