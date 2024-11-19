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
    public class PostService
    {
        public static List<PostDTO> Get()
        {

            var data = DataAccessFactory.PostData().Get();
            return Convert(data);

        }

        public static PostDTO Get(int id)
        {
            return Convert(DataAccessFactory.PostData().Get(id));
        }
        public static bool Create(PostDTO post)
        {
            var data = Convert(post);
            var res = DataAccessFactory.PostData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(PostDTO post)
        {
            var data = Convert(post);
            var res = DataAccessFactory.PostData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.PostData().Delete(id);
        }

        static List<PostDTO> Convert(List<Post> posts)
        {
            var data = new List<PostDTO>();
            foreach (var post in posts)
            {
                data.Add(Convert(post));
            }
            return data;

        }
        static Post Convert(PostDTO post)
        {
            return new Post()
            {
                Post_Id = post.Post_Id,
                Post_Title = post.Post_Title,
                Post_Description = post.Post_Description,
                Posted_By = post.Posted_By,
                Post_Date = post.Post_Date
            };
        }
        static PostDTO Convert(Post post)
        {
            return new PostDTO()
            {
                Post_Id = post.Post_Id,
                Post_Title = post.Post_Title,
                Post_Description = post.Post_Description,
                Posted_By = post.Posted_By,
                Post_Date = post.Post_Date
            };
        }
    }
}
