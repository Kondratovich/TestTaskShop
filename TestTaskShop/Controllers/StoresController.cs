using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TestTaskShop.Controllers
{
    public class StoresController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StoresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(_unitOfWork.Stores.GetAll());
        }
    }
}
