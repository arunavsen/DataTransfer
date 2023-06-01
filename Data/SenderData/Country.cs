using DataTransfer.Common;

namespace DataTransfer.Data.SenderData
{
    public class Country : BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public bool? IsDisplay { get; set; }
        public string? Currency { get; set; }
        public bool? IsLowTax { get; set; }

        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }

        public BriefCountryMap BriefCountryMap { get; set; }
        public TaxBriefContent TaxBriefContent { get; set; }

    }


}
