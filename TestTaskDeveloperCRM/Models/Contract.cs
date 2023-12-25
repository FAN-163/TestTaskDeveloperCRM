using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskDeveloperCRM.Models
{
    /// <summary>
    /// Договор
    /// </summary>
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractId { get; set; }
        [ForeignKey("CompanyId")]
        public int Counterparty { get; set; }
        [ForeignKey("PersonId")]
        public int AuthorizedPerson { get; set; }
        public decimal ContractAmount { get; set; }
        public string Status { get; set; }
        public DateTime SigningDate { get; set; }
    }
}
