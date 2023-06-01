using DataTransfer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Models.Receiver
{
    public class Briefing : BaseModel
    {
        public DateTime PublishDate { get; set; }
        public int Year { get; set; }
        public string? Month { get; set; }
        public string? BriefingType { get; set; }
    }
}
