using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public class Tax : Entity
  {
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double Percentage { get; set; } = 0;
  }
}
