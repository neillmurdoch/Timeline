using System.Collections.Generic;
using System.Threading.Tasks;
using TimeLine.Common.Dtos;

namespace Timeline.Service
{
    public interface ISeriesService
    {
        Task<IEnumerable<SeriesDto>> RetrieveAllAsync();
        Task<SeriesDto> RetrieveSeriesAsync(int id);
        Task<SeriesDto> CreateAsync(SeriesDto seriesDto);
        Task<SeriesDto> UpdateAsync(int id, SeriesDto seriesDto);
    }
}
