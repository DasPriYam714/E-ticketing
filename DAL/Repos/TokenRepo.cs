using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(string id)
        {
            return db.Tokens.Find(id);
        }

        public Token Create(Token obj)
        {

            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) ;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Get(id);
            db.Tokens.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Token Update(Token obj)
        {
            var token = Read(obj.TKey);
            db.Entry(token).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return token;
            return null;
        }

        public Token Read(string id)
        {
            var un = db.Tokens.FirstOrDefault(t => t.TKey.Equals(id));
            return un;
        }
    }
}
