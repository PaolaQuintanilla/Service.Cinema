using cinema.Criteria;
using cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ILogger<CinemaController> _logger;

        public CinemaController(ILogger<CinemaController> logger)
        {
            _logger = logger;
        }
        #region Theater

        [HttpGet("GetTheaters")]
        public IEnumerable<Theater> GetTheaters()
        {
            var result = new List<Theater>();
            using (cinemadbContext db = new cinemadbContext())
            {
                result = db.Theater.Where(f => f.IsActive == 1).ToList();
            }

            return result;
        }

        [HttpPost("CreateTheater")]
        public async Task<ActionResult<Theater>> CreateTheater(TheaterCriteria item)
        {
            Theater result = new Theater();
            using (cinemadbContext db = new cinemadbContext())
            {
                result.Name = item.Name;
                result.Description = item.Description;
                result.CreatedBy = 1;
                result.IsActive = 1;
                result.CreatedAt = DateTime.Now;
                db.Add(result);
                db.SaveChanges();
            }
            return result;
        }
        #endregion

    }
}
