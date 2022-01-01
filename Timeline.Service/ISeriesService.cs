using System.Collections.Generic;
using System.Threading.Tasks;
using TimeLine.Common.Dtos;

namespace Timeline.Service
{
    public interface ISeriesService
    {
        Task<IEnumerable<SeriesDto>> GetAllAsync();
        Task<SeriesDto> GetSeriesAsync(int id);
    }
}
