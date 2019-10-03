using BenchBnB.Models;
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
        async public Task<List<Bench>> Get()
        {
            return await _repository.GetBenchList();
        }
    }
}
