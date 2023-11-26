using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentingMovies.Data;
using RentingMovies.Models.DBObjects;
using RentingMovies.Repository;
namespace RentingMovies.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class ClientController : Controller
    {
        private Repository.ClientRepository _repository;

        public ClientController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.ClientRepository(dbContext);
        }

        // GET: ClientController
        [HttpGet]
        public ActionResult SearchClient(string email)
        {
            var model=_repository.GetClientByEmail(email);
            return View("SearchClient",model);
        }
        public ActionResult Index()
        {
            var clients=_repository.GetAllClients();
            return View("Index", clients);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetClientByID(id);
            return View("ClientDetails", model);
        }

        // GET: ClientController/Create
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            return View("CreateClient");
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.DBObjects.ClientModel model=new Models.DBObjects.ClientModel();
                var task=TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _repository.InsertClient(model);
                }
                return View("CreateClient");
            }
            catch
            {
                return View("CreateClient");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ClientController/Edit/5
        
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetClientByID(id);
            return View("EditClient", model);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ClientModel();
                var task =TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _repository.UpdateClient(model);
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

        // GET: ClientController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model=_repository.GetClientByID(id);
            return View("DeleteClient", model);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteCient(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteClient", id);
            }
        }
    }
}
