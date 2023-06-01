using DataTransfer.Common;

namespace DataTransfer.Data.SenderData
{
    public class TaxBriefContent : BaseModel
    {

        public string Content { get; set; }

        public BriefCountryMap BriefCountryMap { get; set; }
        public string CountryName { get; set; }
        public int? CountryId { get; set; }
        public virtual Country PartnerCountry { get; set; }
    }


}
