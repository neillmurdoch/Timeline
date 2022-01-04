using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timeline.Data;
using Timeline.Entity.Models;
using TimeLine.Common.Dtos;

namespace Timeline.Service.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly TimelineDbContext _timelineDbContext;
        private readonly IMapper _mapper;

        public SeriesService(TimelineDbContext timelineDbContext, IMapper mapper)
        {
            _timelineDbContext = timelineDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SeriesDto>> RetrieveAllAsync()
        {
            var seriesEntities = await _timelineDbContext.Series.Include(s => s.World).ToListAsync();
            var seriesDto = _mapper.Map<IEnumerable<SeriesDto>>(seriesEntities);

            return seriesDto;
        }

        public async Task<SeriesDto> RetrieveSeriesAsync(int id)
        {
            var seriesEntity = await _timelineDbContext.Series.Include(s => s.World).FirstOrDefaultAsync(s => s.Id == id);
            var seriesDto = _mapper.Map<SeriesDto>(seriesEntity);

            return seriesDto;
        }
        public async Task<SeriesDto> CreateAsync(SeriesDto seriesDto)
        {
            var seriesEntity = _mapper.Map<Series>(seriesDto);
            var savedSeries = _timelineDbContext.Series.Add(seriesEntity).Entity;

            await _timelineDbContext.SaveChangesAsync();

            var savedSeriesDto = _mapper.Map<SeriesDto>(savedSeries);

            return savedSeriesDto;
        }

        public async Task<SeriesDto> UpdateAsync(int id, SeriesDto seriesDto)
        {
            var seriesEntity = await _timelineDbContext.Series.FindAsync(id);
            if (seriesEntity == null)
            {
                return null;
            }

            _mapper.Map<SeriesDto, Series>(seriesDto, seriesEntity);
            await _timelineDbContext.SaveChangesAsync();

            var updatedSeriesDto = _mapper.Map<SeriesDto>(seriesEntity);

            return updatedSeriesDto;
        }
    }
}
