using System;
using Newtonsoft.Json;

namespace Spotify.Common.Models
{
    public class Track
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("disc_number")]
        public int DiscNumber { get; internal set; }

        [JsonProperty("track_number")]
        public int TrackNumber { get; internal set; }

        [JsonProperty("duration_ms")]
        internal int DurationRaw { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("explicit")]
        public bool IsExplicit { get; internal set; }

        public TimeSpan Duration
        {
            get { return TimeSpan.FromMilliseconds(DurationRaw); }
        }

        public string DurationDisplay
        {
            get
            {
                var hourString = Duration.Hours.ToString().PadLeft(2, '0');
                var minsString = Duration.Minutes.ToString().PadLeft(2, '0');
                var secsString = Duration.Seconds.ToString().PadLeft(2, '0');

                if (Duration.TotalHours > 0)
                    return $"{hourString}:{minsString}:{secsString}";

                return $"{minsString}:{secsString}";
            }
        }
    }
}
