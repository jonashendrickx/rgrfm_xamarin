using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using RgrFm.Models;
using RgrFm.Services;

namespace RgrFm.Droid.Services
{
    public class RgrFmWebService
    {
        public static async Task<PlaylistFeed> GetPlaylistAsync()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri("https://www.rgrfm.be/rgr_dance/apps/playlist.php"));
                request.ContentType = "application/xhtml+xml";
                request.Method = "GET";

                using (var response = await request.GetResponseAsync())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        string content;
                        using (var reader = new StreamReader(stream))
                        {
                            content = reader.ReadToEnd();
                        }

                        var result = XmlSerializerService.Deserialize(content);
                        return PlaylistFeed.FromXmlContract(result);
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