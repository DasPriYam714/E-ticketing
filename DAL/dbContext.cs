using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Token> Tokens { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Accountant> Accountants { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<UpcomingMovie> UpcomingMovies { get; set; }

    }
}
