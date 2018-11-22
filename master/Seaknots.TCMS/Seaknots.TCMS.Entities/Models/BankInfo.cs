using Seaknots.TCMS.Core.Concrete.Trackable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public partial class BankInfo : Entity
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BankID { get; set; }
    public string AccountNumber { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
    public string BranchIFSC { get; set; } = string.Empty;
  }
}
