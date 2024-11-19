using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Admin, int, bool> AdminData()
        {
            return new AdminRepo();
        }

        public static IRepo<Booking, int, bool> BookingData()
        {
            return new BookingRepo();
        }

        public static IRepo<Comment, int, bool> CommentData()
        {
            return new CommentRepo();
        }

        public static IRepo<Manager, int, bool> ManagerData()
        {
            return new ManagerRepo();
        }

        public static IRepo<Post, int, bool> PostData()
        {
            return new PostRepo();
        }

        public static IRepo<Ticket, int, bool> TicketData()
        {
            return new TicketRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }

        public static IRepo<Transaction, int, bool> TransactionData()
        {
            return new TransactionRepo();
        }

        public static IRepo<User, int, bool> UserData()
        {
            return new UserRepo();
        }

        public static IRepo<Report, int, bool> ReportData()
        {
            return new ReportRepo();
        }

        public static IAuth<bool> UserAuthData()
        {
            return new UserRepo();
        }

        public static IRepo<Rating, int, bool> RatingData()
        {
            return new RatingRepo();
        }

        public static IRepo<Accountant, int, bool> AccountantData()
        {
            return new AccountantRepo();
        }

        public static IRepo<Movie, int, bool> MovieData()
        {
            return new MovieRepo();
        }

        public static IRepo<UpcomingMovie, int, bool> UpcomingMovieData()
        {
            return new UpcomingMovieRepo();
        }
    }
}
