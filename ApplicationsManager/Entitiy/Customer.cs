using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationsManager.Entitiy
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }= Guid.NewGuid();
        public string OwnerName { get; set; }
        public string? Mobile { get; set; }
        public string MarketName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string BarnchName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
