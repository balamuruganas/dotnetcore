namespace Seaknots.TCMS.API
{
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Serialization;
  using Seaknots.TCMS.Core.Abstractions.EF;
  using Seaknots.TCMS.Core.Abstractions.Trackable;
  using Seaknots.TCMS.Core.Concrete.EF;
  using Seaknots.TCMS.Core.Concrete.Trackable;
  using Seaknots.TCMS.DataAccess;
  using Seaknots.TCMS.Entities;
  using Seaknots.TCMS.Repository;
  using Seaknots.TCMS.Service;
  using Swashbuckle.AspNetCore.Swagger;
  using Contact = TCMS.Entities.Contact;

  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddScoped<DbInitializer>();

      services.AddCors();
      services.AddDbContext<TCMSContext>(options => options.UseSqlServer(Configuration.GetConnectionString(nameof(TCMSContext))));
      services.AddScoped<DbContext, TCMSContext>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      services.AddScoped<ITrackableRepository<CorporateOffice>, TrackableRepository<CorporateOffice>>();
      services.AddScoped<ITrackableRepository<Customer>, TrackableRepository<Customer>>();
      services.AddScoped<ITrackableRepository<Location>, TrackableRepository<Location>>();
      services.AddScoped<ITrackableRepository<Product>, TrackableRepository<Product>>();
      services.AddScoped<ITrackableRepository<TankAgency>, TrackableRepository<TankAgency>>();
      services.AddScoped<ITrackableRepository<TankOperator>, TrackableRepository<TankOperator>>();
      services.AddScoped<ITrackableRepository<Tax>, TrackableRepository<Tax>>();
      services.AddScoped<ITrackableRepository<User>, TrackableRepository<User>>();
      services.AddScoped<ITrackableRepository<Vendor>, TrackableRepository<Vendor>>();
      services.AddScoped<ITrackableRepository<BankInfo>, TrackableRepository<BankInfo>>();
      services.AddScoped<ITrackableRepository<Contact>, TrackableRepository<Contact>>();

      services.AddScoped<IMasterRepository<CorporateOffice>, MasterRepository<CorporateOffice>>();
      services.AddScoped<IMasterRepository<Customer>, MasterRepository<Customer>>();
      services.AddScoped<IMasterRepository<Location>, MasterRepository<Location>>();
      services.AddScoped<IMasterRepository<Product>, MasterRepository<Product>>();
      services.AddScoped<IMasterRepository<TankAgency>, MasterRepository<TankAgency>>();
      services.AddScoped<IMasterRepository<TankOperator>, MasterRepository<TankOperator>>();
      services.AddScoped<IMasterRepository<Tax>, MasterRepository<Tax>>();
      services.AddScoped<IMasterRepository<User>, MasterRepository<User>>();
      services.AddScoped<IMasterRepository<Vendor>, MasterRepository<Vendor>>();
      services.AddScoped<IMasterRepository<BankInfo>, MasterRepository<BankInfo>>();
      services.AddScoped<IMasterRepository<Contact>, MasterRepository<Contact>>();

      services.AddScoped<ICorporateOfficeService, CorporateOfficeService>();
      services.AddScoped<ICustomerService, CustomerService>();
      services.AddScoped<ILocationService, LocationService>();
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<ITankAgencyService, TankAgencyService>();
      services.AddScoped<ITankOperatorService, TankOperatorService>();
      services.AddScoped<ITaxService, TaxService>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IVendorService, VendorService>();
      services.AddScoped<IBankInfoService, BankInfoService>();
      services.AddScoped<IContactService, ContactService>();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                      .AddJsonOptions(opt =>
                      {
                        opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                      });

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info
        {
          Version = "v1",
          Title = "TCMS API",
          Description = "Seaknots TCMS API",
          TermsOfService = "None",
          Contact = new Swashbuckle.AspNetCore.Swagger.Contact() { Name = "Seaknots", Email = "contact@seaknots.com", Url = "www.seaknots.com" }
        });
      });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseCors(builder =>
        {
          builder.AllowAnyOrigin();
          builder.AllowAnyHeader();
          builder.AllowAnyMethod();
          builder.AllowCredentials();
          builder.Build();
        });
      }
      else
      {
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TCMS API V1");
      });
    }
  }
}