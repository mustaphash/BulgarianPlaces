using Models.Place;
using System.Threading.Tasks;

namespace External.Places.Queries.Interfaces
{
    public interface IGetTownQuery
    {
        Task<Place> ExecuteAsync();
    }
}
