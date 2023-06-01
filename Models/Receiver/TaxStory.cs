using DataTransfer.Common;

namespace DataTransfer.Models.Receiver
{
    public class TaxStory : BaseModel
    {
        public int StoryId { get; set; }
        public string? CountryCode { get; set; }

        public virtual Story Story { get; set; } = null!;
    }
}
