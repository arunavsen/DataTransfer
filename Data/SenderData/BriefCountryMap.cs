using DataTransfer.Common;

namespace DataTransfer.Data.SenderData
{
    public class BriefCountryMap : BaseModel
    {

        public Boolean IsInterested { get; set; }
        public Brief Brief { get; set; }

        public ICollection<TaxBriefContent> TaxBriefContents { get; set; }
        public ICollection<TpaBriefContent> TpaBriefContents { get; set; }
        public ICollection<WtaBriefContent> WtaBriefContents { get; set; }
        public string CountryName { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public BriefCountryMap()
        {
            TaxBriefContents = new HashSet<TaxBriefContent>();
            WtaBriefContents = new HashSet<WtaBriefContent>();
            TpaBriefContents = new HashSet<TpaBriefContent>();
        }

    }


}
