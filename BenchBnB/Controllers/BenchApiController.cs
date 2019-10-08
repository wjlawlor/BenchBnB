using BenchBnB.Models;
using BenchBnB.Models.DTOs;
using BenchBnB.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BenchBnB.Controllers
{
    [RoutePrefix("api/benches")]
    public class BenchApiController : ApiController
    {
        private IBenchRepository _repository;

        public BenchApiController(IBenchRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        async public Task<List<BenchDTO>> Get()
        {
            List<Bench> fullBenches = await _repository.GetBenchList();
            List<BenchDTO> data = new List<BenchDTO>();

            foreach(var bench in fullBenches)
            {
                var benchDTO = new BenchDTO();
                benchDTO.Id = bench.Id;
                benchDTO.Name = bench.Name;
                benchDTO.Seats = bench.Seats;
                benchDTO.Description = bench.Description;
                benchDTO.User = bench.User;
                benchDTO.AverageRating = bench.Rating;
                benchDTO.Latitude = bench.Latitude;
                benchDTO.Longitude = bench.Longitude;
                benchDTO.DateDiscovered = bench.DateDiscovered;
                data.Add(benchDTO);
            }

            return data;
        }
    }
}
