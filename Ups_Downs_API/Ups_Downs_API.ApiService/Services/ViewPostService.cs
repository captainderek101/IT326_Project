using Library;

namespace Ups_Downs_API.ApiService.Services
{
    public class ViewPostService
    {
        public object GetPost(PostObject obj)
        {
            // TODO: DB connection here
            obj.Content = "test";


            var v = new
            {
                Content = obj.Content
            };

            return v;
        }
        public void PostReport(ReportRequest obj)
        {
            // TODO: DB connection here
        }
        public void PutVote(VoteRequest obj)
        {
            // TODO: DB connection here
        }
        public void PostComment(CommentObject obj)
        {
            // TODO: DB connection here
        }
        public void PostSubscribe(SubscriptionRequest obj)
        {
            // TODO: DB connection here
        }
    }
}
