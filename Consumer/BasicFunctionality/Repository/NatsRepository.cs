namespace BasicFunctionality.Repository
{
    using BasicFunctionality.DataBase;
    using BasicFunctionality.DataBase.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NatsRepository
    {
        private bool _disposed = false;
        private readonly ApplicationDbContext _context;

        public NatsRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IQueryable<RecipientNats> GetAll()
        {
            return _context.Set<RecipientNats>();
        }

        public RecipientNats Get(long id)
        {
            return _context.Set<RecipientNats>().Find(id); ;
        }

        public void Create(RecipientNats item)
        {
            _context.Set<RecipientNats>().Add(item);
            Save();
        }

        public void Create(IList<RecipientNats> items)
        {
            foreach (var item in items)
            {
                _context.Set<RecipientNats>().Add(item);
            }
           
            Save();
        }

        public void Update(RecipientNats item)
        {
            _context.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(long id)
        {
            _context.Set<RecipientNats>().Remove(Get(id));
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }        

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
