using System;
using System.IO;
using MeetNSeat.Dal.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MeetNSeat.Dal.DbContext
{
    public class DbContext : IdentityDbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {

        }

        public DbSet<UserDto> Users { get; }
        public DbSet<ReservationDto> Reservations { get;  }
        public DbSet<RoomDto> Rooms { get; }
    }
}
