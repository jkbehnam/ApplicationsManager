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
        public Customer? Customer { get; set; }
        public Guid? CustomerId { get; set; }
        [ForeignKey("AppEName")]
        public ApplicationType? applicationType { get; set; }

        public string? AppEName { get; set; }

        [ForeignKey("PlanId")]

        public SubscriptionPlan? SubscriptionPlan { get; set; }
        public long? PlanId { get; set; }

        public string? DeviceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Boolean? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

    }
}
