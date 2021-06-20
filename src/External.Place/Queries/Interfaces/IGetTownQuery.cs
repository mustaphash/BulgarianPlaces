using Models.Place;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace External.Places.Queries.Interfaces
{
    public interface IGetTownQuery
    {
        Task<List<Place>> ExecuteAsync(string townName);
    }
}
