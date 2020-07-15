using LoginAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<T> dbSet;

        protected BaseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            this.dbSet = contexto.Set<T>();
        }
    }
}
