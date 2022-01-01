using System.Collections.Generic;
using TimeLine.Common.Dtos;

namespace Timeline.Service
{
    public interface ISeriesService
    {
        IEnumerable<SeriesDto> GetAll();
        SeriesDto GetSeries(int id);
    }
}
