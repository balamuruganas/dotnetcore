using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seaknots.TCMS.Entities
{
  public partial class NewProduct : Entity
  {
    public NewProduct()
    {
      RestrictedPorts = new Collection<Port>();
      ProductStatusList = new Collection<Status>();
      CleaningMethods = new Collection<string>();
      Groups = new Collection<string>();
      Codes = new Collection<Code>();
    }

    public string Group { get; set; }
    public Code Code { get; set; }
    public string ShippingName { get; set; }
    public string TechnicalName { get; set; }
    public string IMOClass { get; set; }
    public string UNCode { get; set; }
    public string PackingGroup { get; set; }
    public string SubClass { get; set; }
    public bool MarinePollutant { get; set; }
    public bool Restricted { get; set; }
    public Status ProductStatus { get; set; }
    public string StepOne { get; set; }
    public string StepTwo { get; set; }
    public ICollection<Port> RestrictedPorts { get; set; }
    public ICollection<Status> ProductStatusList { get; set; }
    public ICollection<string> CleaningMethods { get; set; }
    public ICollection<string> Groups { get; set; }
    public ICollection<Code> Codes { get; set; }
  }
}
