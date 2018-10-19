﻿using Seaknots.TCMS.Core.Concrete.Trackable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seaknots.TCMS.Entities
{
  public partial class TankAgency : Entity
  {
    public TankAgency()
    {
      Countries = new Collection<Country>();
      Locations = new Collection<Location>();
      CompanyTypes = new Collection<CompanyType>();
      Contacts = new Collection<Contact>();
      Operators = new Collection<TankOperator>();
    }

    public string ShortName { get; set; }
    public string CompanyName { get; set; }
    public CompanyType CompanyType { get; set; }
    public Currency Currency { get; set; }
    public Country Country { get; set; }
    public Location Location { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public double ExportCommission { get; set; }
    public double ImportCommission { get; set; }
    public double MinimumCommission { get; set; }
    public BankInfo AcountDetail { get; set; }
    public ICollection<Country> Countries { get; set; }
    public ICollection<Location> Locations { get; set; }
    public ICollection<CompanyType> CompanyTypes { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<TankOperator> Operators { get; set; }
    public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
  }
}
