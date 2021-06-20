using Models.Place;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace External.Places.Queries.Interfaces
{
    public interface IGetLngAndLatQuery
    {
        Task<List<Place>> ExecuteAsync(double longitude, double latitude);
    }
}
