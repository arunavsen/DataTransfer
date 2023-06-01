using DataTransfer.Common;

namespace DataTransfer.Data.SenderData
{
    public class Region : BaseModel
    {
        public Region()
        {
            Countries = new HashSet<Country>();
        }

        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }


}
