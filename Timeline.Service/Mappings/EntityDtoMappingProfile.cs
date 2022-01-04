using AutoMapper;
using System.Linq;
using System.Reflection;
using Timeline.Entity.Models;
using TimeLine.Common;

namespace Timeline.Service.Mappings
{
    public class EntityDtoMappingProfile : Profile
    {
        public EntityDtoMappingProfile()
        {
            var allEntities = Assembly.GetAssembly(typeof(Entity.Entity))?.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Entity.Entity)));

            var allDtos = Assembly.GetAssembly(typeof(Dto))?.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Dto))).ToArray();

            const string dtoSuffix = "Dto";
            foreach (var entity in allEntities)
            {
                var dtoName = $"{entity.Name}{dtoSuffix}";
                var dto = allDtos.FirstOrDefault(o => o.Name == dtoName);
                if (dto != null)
                {
                    CreateMap(entity, dto).ReverseMap();
                }
            }
        }
    }
}
