using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationsManager.Entitiy
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
            
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
