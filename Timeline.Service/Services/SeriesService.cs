using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timeline.Data;
using TimeLine.Common.Dtos;

namespace Timeline.Service.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly TimelineDbContext _timelineDbContext;

        public SeriesService(TimelineDbContext timelineDbContext)
        {
            _timelineDbContext = timelineDbContext;
        }

        public async Task<IEnumerable<SeriesDto>> GetAllAsync()
        {
            var seriesEntities = await _timelineDbContext.Series.Include(s => s.World).ToListAsync();

            var seriesDtos = new List<SeriesDto>();
            foreach (var seriesEntity in seriesEntities)
            {
                var seriesDto = new SeriesDto
                {
                    Id = seriesEntity.Id,
                    Name = seriesEntity.Name,
                    Description = seriesEntity.Description,
                    World = new WorldDto
                    {
                        Id = seriesEntity.World.Id,
                        Name = seriesEntity.World.Name,
                        Description = seriesEntity.World.Description
                    }
                };
                seriesDtos.Add(seriesDto);
            }

            return seriesDtos;
        }

        public async Task<SeriesDto> GetSeriesAsync(int id)
        {
            var seriesEntity = await _timelineDbContext.Series.Include(s => s.World).FirstOrDefaultAsync(s => s.Id == id);

            var seriesDto = new SeriesDto
            {
                Id = seriesEntity.Id,
                Name = seriesEntity.Name,
                Description = seriesEntity.Description,
                World = new WorldDto
                {
                    Id = seriesEntity.World.Id,
                    Name = seriesEntity.World.Name,
                    Description = seriesEntity.World.Description
                }
            };

            return seriesDto;
        }
    }
}
