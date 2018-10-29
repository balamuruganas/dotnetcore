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
      ProductStatusList = new Collection<Status>();
      CleaningMethods = new Collection<CleaningMethod>();
      Groups = new Collection<ProductGroup>();
      Names = new Collection<Code>();
    }

    [Key]
    public int ID { get; set; }
    public ProductGroup Group { get; set; }
    public Code Name { get; set; }
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
    [NotMapped]
    public ICollection<Status> ProductStatusList { get; set; }
    public ICollection<CleaningMethod> CleaningMethods { get; set; }
    [NotMapped]
    public ICollection<ProductGroup> Groups { get; set; }
    [NotMapped]
    public ICollection<Code> Names { get; set; }
  }
}
