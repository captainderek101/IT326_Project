using Library;

namespace Ups_Downs_API.ApiService.Services
{
    public class CreatingPostService
    {
        public CreatingPostObject ProcessCreatingPost(CreatingPostObject obj)
        {
            obj.PostId = 123;
            obj.PostDayType = "good";
            obj.PostTimestamp = "01/01/0000 21:20:30";
            obj.UserId = 321;
            obj.Content = "I just can't believe that 'it's not butter' is actually not butter, I thought it was actually butter " +
                "but its some butter alternative?! Who let this happen? I understand it isn't actually butter but it should " +
                "actually be butter and now I don't know what's real. Is it butter or is it not butter? Is it some butter and not butter " +
                "what has this world come to";
        
            // TODO: adjust PostTimestamp to only send the time, not the entire date
            // TODO: DB connection here - after adjsuting the post time stamp, send to DB.
            return obj;
        }
    }
}
