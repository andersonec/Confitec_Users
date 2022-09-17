using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users.Infra.Data.DbConfig;
using users.Infra.Data.Repository.IRepositories;
using users.Infra.Entities;

namespace users.Infra.Data.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context Context)
        {
            _context = Context;
        }

        public virtual User Add(User obj)
        {
            try
            {
                var entity = _context.Set<User>().Add(obj);
                _context.SaveChanges();

                if (entity != null)
                    return entity.Entity;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual User GetById(int id)
        {
            try
            {
                var entity = _context.Set<User>().Find(id);

                if (entity == null)
                    return null;
                else
                    return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<User> GetAll()
        {
            try
            {
                var list = _context.Set<User>().ToList();

                if (list == null)
                    return null;
                else
                    return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int Update(User obj)
        {
            try
            {
                _context.ChangeTracker.Clear();
                _context.Entry(obj).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int Remove(User obj)
        {
            try
            {
                _context.Set<User>().Remove(obj);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
