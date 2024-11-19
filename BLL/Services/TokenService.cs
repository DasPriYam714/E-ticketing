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
    public class TokenService
    {
        public static List<TokenDTO> Get()
        {

            var data = DataAccessFactory.TokenData().Get();
            return Convert(data);

        }

        public static TokenDTO Get(string id)
        {
            return Convert(DataAccessFactory.TokenData().Get(id));
        }
        public static bool Create(TokenDTO token)
        {
            var data = Convert(token);
            var res = DataAccessFactory.TokenData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(TokenDTO token)
        {
            var data = Convert(token);
            var res = DataAccessFactory.TokenData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(string id)
        {
            return DataAccessFactory.TokenData().Delete(id);
        }

        static List<TokenDTO> Convert(List<Token> tokens)
        {
            var data = new List<TokenDTO>();
            foreach (var token in tokens)
            {
                data.Add(Convert(token));
            }
            return data;

        }
        static Token Convert(TokenDTO token)
        {
            return new Token()
            {
                Id = token.Id,
                TKey = token.TKey,
                CreatedAt = token.CreatedAt,
                DeletedAt = token.DeletedAt,
                UserId = token.UserId
            };
        }
        static TokenDTO Convert(Token token)
        {
            return new TokenDTO()
            {
                Id = token.Id,
                TKey = token.TKey,
                CreatedAt = token.CreatedAt,
                DeletedAt = (DateTime)token.DeletedAt,
                UserId = token.UserId
            };
        }
    }
}
