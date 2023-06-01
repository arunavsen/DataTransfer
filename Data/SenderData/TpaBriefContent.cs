using DataTransfer.Common;

namespace DataTransfer.Data.SenderData
{
    public class TpaBriefContent : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string RegFollowerLink { get; set; }

        public int CountryId { get; set; }
        public BriefCountryMap BriefCountryMap { get; set; }
    }


}
