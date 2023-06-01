using DataTransfer.Common;

namespace DataTransfer.Models.Receiver
{
    public class Story : BaseModel
    {
        public int BriefingId { get; set; }
        public string? Title { get; set; }
        public string? ShortStory { get; set; }
        public string? LongStory { get; set; }
        public string? RegFollowerLink { get; set; }

        public virtual Briefing Briefing { get; set; } = null!;
    }
}
