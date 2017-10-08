using System;
using Newtonsoft.Json;

// Classes to deseralize JSON object
namespace emotionAPI.Models
{
    public class FaceRectangle
    {
        private int left { get; set; }
        private int top { get; set; }
        private int width { get; set; }
        private int height { get; set; }
    }

    public class Scores
    {
        public double anger { get; set; }
        public double contempt { get; set; }
        public double disgust { get; set; }
        public double fear { get; set; }
        public double happiness { get; set; }
        public double neutral { get; set; }
        public double sadness { get; set; }
        public double surprise { get; set; }

        // Replace this function with the Max() function from the TopEmotion code snippet
        public string Max()
        {
            return null;
        }
    }

    [JsonObject]
    public class EmotionSet
    {
        [JsonProperty(PropertyName = "faceRectangle")]
        public FaceRectangle faceRectangle { get; set; }
        [JsonProperty(PropertyName = "scores")]
        public Scores scores { get; set; }

        public String getTopScore()
        {
            return scores.Max();
        }
    }
}