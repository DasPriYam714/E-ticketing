using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService
    {
        public static List<CommentDTO> Get()
        {

            var data = DataAccessFactory.CommentData().Get();
            return Convert(data);

        }

        public static CommentDTO Get(int id)
        {
            return Convert(DataAccessFactory.CommentData().Get(id));
        }
        public static bool Create(CommentDTO comment)
        {
            var data = Convert(comment);
            var res = DataAccessFactory.CommentData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(CommentDTO comment)
        {
            var data = Convert(comment);
            var res = DataAccessFactory.CommentData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CommentData().Delete(id);
        }

        static List<CommentDTO> Convert(List<Comment> comments)
        {
            var data = new List<CommentDTO>();
            foreach (var comment in comments)
            {
                data.Add(Convert(comment));
            }
            return data;

        }
        static Comment Convert(CommentDTO comment)
        {
            return new Comment()
            {
                Comment_Id = comment.Comment_Id,
                Comment_Text = comment.Comment_Text,
                Comment_Time = comment.Comment_Time,
                Comment_By = comment.Comment_By,
                Post_Id =comment.Post_Id
            };
        }
        static CommentDTO Convert(Comment comment)
        {
            return new CommentDTO()
            {
                Comment_Id = comment.Comment_Id,
                Comment_Text = comment.Comment_Text,
                Comment_Time = comment.Comment_Time,
                Comment_By = comment.Comment_By,
                Post_Id = comment.Post_Id
            };
        }
    }
}
