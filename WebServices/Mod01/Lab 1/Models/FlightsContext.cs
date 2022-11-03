using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlueYonder.Flights.Models
{
    public class FlightsContext : DbContext
    {
        public FlightsContext(DbContextOptions<FlightsContext> options) : base(options) { }

        public DbSet<Flight> Flights { get; set; }
    }
}