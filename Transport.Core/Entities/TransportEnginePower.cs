using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transport.Core.Configurations
{
    public class TransportEnginePowers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int TransportEnginePowerId { get; set; }
        public virtual string TransportEngine { get; set; }
    }
}
