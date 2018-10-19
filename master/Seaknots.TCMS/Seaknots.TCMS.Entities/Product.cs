using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  using Seaknots.TCMS.Core.Concrete.Trackable;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.ComponentModel.DataAnnotations;

  public partial class Product : Entity
  {
    public Product()
    {
      Products = new Collection<Product>();
    }

    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public decimal? Price { get; set; }
    public string Category { get; set; }
    public virtual ICollection<Product> Products { get; set; }
  }
}
