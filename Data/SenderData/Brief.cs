using DataTransfer.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Data.SenderData
{
    public class Brief : BaseModel
    {
        public string Link { get; set; }
        public DateTime PublishDate { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }

        public ICollection<BriefCountryMap> BriefCountryMaps { get; set; }

        public Brief()
        {
            BriefCountryMaps = new HashSet<BriefCountryMap>();
        }
    }


}
