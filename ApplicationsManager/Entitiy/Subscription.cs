using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationsManager.Entitiy
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
        [ForeignKey("ApplicationTypeId")]
        public ApplicationType ApplicationType { get; set; }
        public long ApplicationTypeId { get; set; }
        [ForeignKey("planId")]
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public long planId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<SubscriptionActivity> SubscriptionActivities { get; set; } = new List<SubscriptionActivity>();

    }
}
