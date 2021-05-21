using cinema.Criteria;
using cinema.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema.Controllers
{
    [EnableCors("CorsApi")]
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

        #region Movie
        [HttpGet("GetMovies")]
        public IEnumerable<Movie> GetMovies()
        {
            var result = new List<Movie>();
            using (cinemadbContext db = new cinemadbContext())
            {
                result = db.Movie.Where(f => f.IsActive == 1).ToList();
            }

            return result;
        }

        [HttpPost("CreateMovie")]
        public async Task<ActionResult<Movie>> CreateMovie(MovieCriteria item)
        {
            Movie result = new Movie();
            using (cinemadbContext db = new cinemadbContext())
            {
                result.Name = item.Name;
                result.Description = item.Description;
                result.Duration = item.Duration;
                result.CreatedBy = 1;
                result.IsActive = 1;
                result.CreatedAt = DateTime.Now;
                db.Add(result);
                db.SaveChanges();
            }
            return result;
        }
        #endregion

        #region Hours
        [HttpGet("GetHours")]
        public IEnumerable<Projectionhour> GetHours()
        {
            var result = new List<Projectionhour>();
            using (cinemadbContext db = new cinemadbContext())
            {
                result = db.Projectionhour.Where(f => f.IsActive == 1).ToList();
            }

            return result;
        }

        [HttpPost("CreateHour")]
        public async Task<ActionResult<Projectionhour>> CreateHour(ProjectionhourCriteria item)
        {
            Projectionhour result = new Projectionhour();
            using (cinemadbContext db = new cinemadbContext())
            {
                result.Hour = item.Hour;
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
