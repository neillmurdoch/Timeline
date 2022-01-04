To create a mapping profile:

  namespace TimeLine.Service.Mappings
  {
      public class EntityDtoMappingProfile : Profile
      {
          public EntityDtoMappingProfile()
          {
              var entities = Assembly.GetAssembly(typeof(Series))
                  ?.GetTypes()
                  .Where(myType =>
                      myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(<Something here>Entity)));

              var dtos = Assembly.GetAssembly(typeof(Dto))
                  ?.GetTypes()
                  .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Dto))).ToArray();

              //var mapperConfigurationExpression = new MapperConfigurationExpression();

              const string dtoSuffix = "Dto";
              foreach (var entity in entities)
              {
                  var dtoName = $"{entity.Name}{dtoSuffix}";
                  var dto = dtos.FirstOrDefault(o => o.Name.Equals(dtoName));
                  if (dto != null)
                  {
                      CreateMap(entity, dto).ReverseMap();
                      //mapperConfigurationExpression.CreateMap(entity, dto).ReverseMap();
                  }
              }
              //var configuration = new MapperConfiguration(mapperConfigurationExpression);
          }

      }
  }
  
To use the mapping profile in Program.cs, when configuring AutoMapper

  // Auto Mapper Configurations
  var mapperConfig = new MapperConfiguration(mc =>
  {
      mc.AddProfile(new EntityDtoMappingProfile());
  });
  IMapper mapper = mapperConfig.CreateMapper();
  builder.Services.AddSingleton(mapper);
  
To use the mapper when converting an entity to a dto
  
  var entity = await _dbContext.FindAsync(id);
  if (entity == null)
      return null;

  return Mapper.Map<SeriesDto>(entity);

To use the mapper when converting a list of entities to a list of dtos

  var entities = await _dbContext.GetAllAsync();
  or
  var entities = await _dbContext.Queryable().ToListAsync();
  return Mapper.Map<IEnumerable<SeriesDto>>(entities);
