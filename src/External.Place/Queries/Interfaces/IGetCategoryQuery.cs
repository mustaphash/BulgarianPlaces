using Models.Place;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace External.Places.Queries.Interfaces
{
    public interface IGetCategoryQuery
    {
        Task<List<Place>> ExecuteAsync(string category);
    }
}
