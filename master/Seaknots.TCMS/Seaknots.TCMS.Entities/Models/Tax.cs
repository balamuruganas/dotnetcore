using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public class Tax : Entity
  {
	  [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TaxID { get; set; }
    public string Code { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Percentage { get; set; } = 0;
  }
}
