using DataTransfer.Common;

namespace DataTransfer.Data.SenderData
{
    public class WtaBriefContent : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string RegFollowerLink { get; set; }

        public BriefCountryMap BriefCountryMap { get; set; }
    }


}
