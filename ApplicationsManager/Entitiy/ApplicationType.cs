using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationsManager.Entitiy
{
    public class ApplicationType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Key]
        public string AppEName { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

       public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public ICollection<ApplicationVersion> ApplicationVersions { get; set; } = new List<ApplicationVersion>();


    }
}
