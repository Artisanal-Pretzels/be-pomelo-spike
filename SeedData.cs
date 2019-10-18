using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using be_pomelo_spike.Models;
using System;
using System.Linq;

namespace be_pomelo_spike
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new LocationItemContext(
          serviceProvider.GetRequiredService<
              DbContextOptions<LocationItemContext>>()))
      {
        context.Database.EnsureCreated();

        var todoItem = new LocationItem
        {
          Latitude = 99,
          Longitude = 100,
          Name = "Pomelo connection?",
        };
        context.LocationItem.Add(todoItem);

        context.SaveChanges();

      }
    }
  }
}