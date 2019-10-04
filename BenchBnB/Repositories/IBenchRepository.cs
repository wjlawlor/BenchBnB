using System.Collections.Generic;
using System.Threading.Tasks;
using BenchBnB.Models;

namespace BenchBnB.Repositories
{
    public interface IBenchRepository
    {
        Bench GetBenchById(int id);
        List<Bench> GetBenches();
        Task<List<Bench>> GetBenchList();
        void Insert(Bench bench);
    }
}