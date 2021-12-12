using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Customer.Domain
{
    public class BaseEntity
    {
        //public BaseEntity(DateTime modifiedDate)
        //{
        //    ModifiedDate = DateTime.Now;
        //}     

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cliente_id")]
        public int CustomerId { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; private set; }
        public DateTime? ModifiedDate { get; private set; }
    }
}
