using Microsoft.AspNetCore.Mvc;
using Taller.Code.Challenge.Interfaces;
using Taller.Code.Challenge.Models;

namespace Taller.Code.Challenge.Controllers
{
	public class CarsController : Controller
	{
		private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        public IActionResult Index()
		{
			return View(_carsService.GetAllCars());
		}

		public IActionResult GuessPrice()
		{
			return View(_carsService.GetAllCars());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult GuessCarPrice(int id, int inputPrice)
		{
			TempData["IsInRange"] = _carsService.IsPriceInRange(id, inputPrice);

			return RedirectToAction(nameof(GuessPrice));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult GuessPrice(int price)
		{
			return View();
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Car car)
		{
			try
			{
				_carsService.CreateCar(car);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				return View(ex.Message);
			}
		}

		public IActionResult Edit(int id)
		{
			return View(_carsService.GetCar(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Car car)
		{
			try
			{
				_carsService.EditCar(car);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				return View(ex.Message);
			}
		}

		public IActionResult Delete(int id)
		{
			return View(_carsService.GetCar(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Car car)
		{
			try
			{
				_carsService.DeleteCar(car.Id);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				return View(ex.Message);
			}
		}
	}
}