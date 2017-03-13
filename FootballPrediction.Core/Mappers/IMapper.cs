using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Mappers
{
    public interface IMapper<T,D> 
        where D : Entity 
        where T : ApiElement
    {
        D Map(T apiElement);
    }
}
