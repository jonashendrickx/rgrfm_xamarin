using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using RgrFm.Models;

namespace RgrFm.Droid.Services
{
    public class RgrFmWebService
    {
        public static async Task<PlaylistFeed> GetPlaylistAsync()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri("http://www.rgrfm.be/rgrsite/maxradio/android_json.php"));
                request.ContentType = "application/json";
                request.Method = "GET";

                using (var response = await request.GetResponseAsync())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        string jsonString;
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            jsonString = reader.ReadToEnd();
                        }
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<PlaylistFeed>(jsonString);
                        return result;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}