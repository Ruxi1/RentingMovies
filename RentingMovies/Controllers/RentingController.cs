using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentingMovies.Data;
using RentingMovies.Models.DBObjects;
using RentingMovies.Repository;
namespace RentingMovies.Controllers
{
    [Authorize(Roles="User, Admin")]
    public class RentingController : Controller
    {
        private Repository.RentingRepository _repository;

        public RentingController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.RentingRepository(dbContext);
        }

        // GET: RentingController
        public ActionResult Index()
        {
            var rentings=_repository.GetAllRentings();
            return View("Index",rentings);
        }

        public ActionResult RentingsByClient(Guid idClient)
        {
            var rentings=_repository.GetRentingsByClientID(idClient);
            return View("RentingsByClient",rentings);
        }

        public ActionResult RentingsByMovie(Guid idMovie)
        {
            var rentings = _repository.GetRentingsByMovieID(idMovie);
            return View("RentingsByMovie",rentings);
        }

        public ActionResult RentingsUnfinished()
        {
            var rentings = _repository.GetRentingsWithoutEndDate();
            return View("RentingsUnfinished",rentings);
        }

        // GET: RentingController/Details/5
        public ActionResult Details(Guid id)
        {
            var model=_repository.GetRentingByID(id);
            return View("RentingDetails", model);
        }

        // GET: RentingController/Create
        public ActionResult Create()
        {
            return View("CreateRenting");
        }

        // POST: RentingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.DBObjects.RentingModel model = new Models.DBObjects.RentingModel();
                var task=TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _repository.InsertRenting(model);
                }
                return View("CreateRenting");
            }
            catch
            {
                return View("CreateRenting");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: RentingController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetRentingByID(id);
            return View("EditRenting", model);
        }

        // POST: RentingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new RentingModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateRenting(model);
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

        // GET: RentingController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model=_repository.GetRentingByID(id);
            return View("DeleteRenting", model);
        }

        // POST: RentingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteRenting(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteRenting", id);
            }
        }
    }
}
