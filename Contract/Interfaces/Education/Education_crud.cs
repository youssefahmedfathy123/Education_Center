using AutoMapper;
using Education_Center_DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Interfaces.Education
{
    public class Education_crud<T> : IEducation_crud<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapping;
        public Education_crud(ApplicationDbContext db, IMapper mapping)
        {
            _db = db;
            _mapping = mapping;
        }

        public async Task<string> Create<Dto>(Dto dto) where Dto : class
        {
            var res = _mapping.Map<Dto, T>(dto);

             _db.Set<T>().Add(res);
           await _db.SaveChangesAsync();

            return "Created";
        }

        public async Task<List<Dto>> Read<Dto>() where Dto : class
        {

            var table = await _db.Set<T>().ToListAsync();

            var result = _mapping.Map<List<T>,List<Dto>>(table);

            return result;

        }


        //public async Task<string> Update<Dto>(Dto dto) where Dto : class
        //{
        //    return "ok";

        //}
        //public async Task<string> Delete<Dto>(Dto dto) where Dto : class
        //{
        //    return "ok";
        //}

    }
}

