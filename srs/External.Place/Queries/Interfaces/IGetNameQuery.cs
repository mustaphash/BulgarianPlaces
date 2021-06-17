using Models.Place;
using System.Threading.Tasks;

namespace External.Places.Queries.Interfaces
{
    public interface IGetNameQuery
    {
        Task<Place> ExecuteAsync();
    }
}
