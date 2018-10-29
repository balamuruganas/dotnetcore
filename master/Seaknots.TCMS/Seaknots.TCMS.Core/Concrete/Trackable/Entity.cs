using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackableEntities.Common.Core;

namespace Seaknots.TCMS.Core.Concrete.Trackable
{
  public abstract class Entity : ITrackable, IMergeable
  {
    [Key]
    public int ID { get; set; }
    [NotMapped]
    public TrackingState TrackingState { get; set; }
    [NotMapped]
    public ICollection<string> ModifiedProperties { get; set; }
    [NotMapped]
    public Guid EntityIdentifier { get; set; }
  }
}
