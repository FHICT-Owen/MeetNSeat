using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MeatNSeat.Dal.Interfaces;

namespace MeatNSeat.Dal.DbContext
{
    public class DbContext : IdentityDbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {

        }

        public DbSet<UserDto> Users { get; }
        public DbSet<ReservationDto> Reservations { get;  }
        public DbSet<RoomDto> Rooms { get;  set; }
    }
}
