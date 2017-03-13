using System;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Mappers
{
    public class Mapper<T, D> : IMapper<T, D>
        where T:ApiElement
        where D:Entity
    {
        public D Map(T apiElement)
        {
            D instance = null;
            var constructorInfo = typeof(D).GetConstructor(new Type[] {});
            if (constructorInfo != null)
            {
                instance = (D)constructorInfo.Invoke(new object[] {});
                var apiElementProperties = apiElement.GetType().GetProperties();
                foreach (var property in apiElementProperties)
                {
                    var propertyName = property.Name;
                    var propertyValue = property.GetValue(null);
                    instance.GetType().GetProperty(propertyName).SetValue(propertyValue);
                }
            }
            return instance;
        }
    }
}
