using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationsManager.Entitiy
{
    public class ApplicationVersion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("ApplicationTypeId")]
        public ApplicationType? ApplicationType { get; set; }
        public long? ApplicationTypeId { get; set; }
        public String? name { get; set; }
        public int code { get; set; }
        public Boolean IsCritical { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
