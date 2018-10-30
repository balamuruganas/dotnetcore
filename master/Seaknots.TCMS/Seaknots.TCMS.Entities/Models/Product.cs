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

    public int GroupID { get; set; }
    public int CodeID { get; set; }
    public string ShippingName { get; set; }
    public string TechnicalName { get; set; }
    public string IMOClass { get; set; }
    public string UNCode { get; set; }
    public string PackingGroup { get; set; }
    public string SubClass { get; set; }
    public bool MarinePollutant { get; set; }
    public bool Restricted { get; set; }
    public int StatusID { get; set; }
    public string StepOne { get; set; }
    public string StepTwo { get; set; }
    public ICollection<Port> RestrictedPorts { get; set; }
    public ICollection<CleaningMethod> CleaningMethods { get; set; }
  }
}
