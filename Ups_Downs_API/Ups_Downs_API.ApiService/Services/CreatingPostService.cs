using Library;

namespace Ups_Downs_API.ApiService.Services
{
    public class CreatingPostService
    {
        public CreatingPostObject ProcessCreatingPost(CreatingPostObject obj)
        {
            // TODO: adjust PostTimestamp to only send the time, not the entire date
            // TODO: DB connection here - after adjsuting the post time stamp, send to DB.

            // Format sentiment score to filterable words: happy, neutral, upset
            double score = Math.Round(obj.SentimentScore, 3);
            if (score > 0.25)
            {
                obj.SentimentWord = "Happy";
            }

            else if(score <= 0.25 && score >= -0.25)
            {
                obj.SentimentWord = "Neutral";
            }

            else
            {
                obj.SentimentWord = "Upset";
            }

            return obj;
        }
    }
}
