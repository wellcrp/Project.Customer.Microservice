using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Customer.Domain.Entities
{
    [Table("Cliente")]
    public class CustomerEntities : BaseEntity
    {
        [Column("cliente_nome")]
        public string CustomerName { get; private set; }

        [Column("cliente_idade")]
        public int CustomerAge { get; private set; }

        [Column("cliente_email")]
        public string? CustomerEmail { get; private set; }
    }
}
