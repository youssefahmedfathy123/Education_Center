using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Interfaces.Education
{
    public interface IEducation_crud<T> where T : class
    {
        // CRUD
        Task<string> Create<Dto>(Dto dto) where Dto : class;
        Task<List<Dto>> Read<Dto>() where Dto : class;

        //Task<string> Update<Dto>(Dto dto) where Dto : class;
        //Task<string> Delete<Dto>(Dto dto) where Dto : class;

    }
}



