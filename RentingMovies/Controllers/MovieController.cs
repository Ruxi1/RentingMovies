using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentingMovies.Data;
using RentingMovies.Models.DBObjects;

namespace RentingMovies.Controllers
{
    public class MovieController : Controller
    {
        private Repository.MovieRepository _repository;
        public MovieController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.MovieRepository(dbContext);
        }
        // GET: MovieController
        [AllowAnonymous]
        public ActionResult Index()
        {
            var movies=_repository.GetAllMovies();
            return View("Index", movies);
        }

        [HttpGet]
        public ActionResult SearchMovie(string name)
        {
            var model = _repository.GetMovieByName(name);
            return View("SearchMovie", model);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(Guid id)
        {
            var model =_repository.GetMovieByID(id);
            return View("MovieDetails", model);
        }

        // GET: MovieController/Create
        [Authorize(Roles ="User, Admin")]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.DBObjects.MovieModel model = new Models.DBObjects.MovieModel();
                var task=TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _repository.InsertMovie(model);
                }
                return View("Create");
            }
            catch
            {
                return View("Create");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MovieController/Edit/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(Guid id)
        {
            var model=_repository.GetMovieByID(id);
            return View("EditMovie", model);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new MovieModel();
                var task= TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _repository.UpdateMovie(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", id);
                }
                
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }

        // GET: MovieController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetMovieByID(id);
            return View("DeleteMovie", model);
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                
                    _repository.DeleteMovie(id);
                    
                    return RedirectToAction("Index");
                
            }
            catch
            {
                return View("DeleteMovie", id);
            }
        }
    }
}
