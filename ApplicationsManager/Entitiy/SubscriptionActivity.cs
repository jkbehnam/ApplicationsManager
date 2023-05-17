using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationsManager.Entitiy
{
    public class SubscriptionActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("SubscriptionId")]
        public Subscription Subscription { get; set; }
        public long SubscriptionId { get; set; }
        public string VersionCode { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceModel { get; set; }
        public DateTime LastUseTime { get; set; } = DateTime.Now;




    }
}
