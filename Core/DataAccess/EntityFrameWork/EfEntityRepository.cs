using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.EntityFrameWork
{
    public class EfEntityRepository<TEnitity, TContext> : IEntityRepository<TEnitity>
        where TEnitity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Delete(TEnitity entity)
        {
            using (var context = new TContext())
            {
                try
                {
                    var deleteEntity = context.Entry(entity);
                    deleteEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }
            }
        }
        public void FakeDataInsert(IList<TEnitity> entities)
        {
            try
            {
                using (var context = new TContext())
                {
                    foreach (TEnitity item in entities)
                    {
                        context.Add(item);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
           
        }
        public TEnitity Get(Expression<Func<TEnitity, bool>> filter)
        {
            try
            {
                using (var context = new TContext())
                {
                    return context.Set<TEnitity>().SingleOrDefault(filter);
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return null;
        }
        public IList<TEnitity> GetList(Expression<Func<TEnitity, bool>>? filter = null)
        {
            try
            {
                using (var context = new TContext())
                {
                    return filter == null ? context.Set<TEnitity>().ToList() :
                        context.Set<TEnitity>().Where(filter).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return Array.Empty<TEnitity>();
        }
        public void Insert(TEnitity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
          
        }
        public void Update(TEnitity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var updateEntity = context.Entry(entity);
                    updateEntity.State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            
        }
    }
}
