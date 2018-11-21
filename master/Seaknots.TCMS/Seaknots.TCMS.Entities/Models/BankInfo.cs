using Seaknots.TCMS.Core.Concrete.Trackable;

namespace Seaknots.TCMS.Entities
{
  public partial class BankInfo : Entity
  {
    public string AccountNumber { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
    public string BranchIFSC { get; set; } = string.Empty;
  }
}
