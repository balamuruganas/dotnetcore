using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public partial class Product : Entity
  {
    public Product()
    {
      RestrictedPorts = new Collection<Port>();
      CleaningMethods = new Collection<CleaningMethod>();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProdID { get; set; }
    public int GroupID { get; set; } = -1;
    public int CodeID { get; set; } = -1;
    public string ShippingName { get; set; } = string.Empty;
    public string TechnicalName { get; set; } = string.Empty;
    public string IMOClass { get; set; } = string.Empty;
    public string UNCode { get; set; } = string.Empty;
    public string PackingGroup { get; set; } = string.Empty;
    public string SubClass { get; set; } = string.Empty;
    public bool MarinePollutant { get; set; } = false;
    public bool Restricted { get; set; } = false;
    public int StatusID { get; set; } = -1;
    public string StepOne { get; set; } = string.Empty;
    public string StepTwo { get; set; } = string.Empty;
    public ICollection<Port> RestrictedPorts { get; set; }
    public ICollection<CleaningMethod> CleaningMethods { get; set; }
  }
}
