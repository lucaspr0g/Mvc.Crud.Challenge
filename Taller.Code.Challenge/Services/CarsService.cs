using Mvc.Crud.Challenge.Interfaces;
using Mvc.Crud.Challenge.Models;

namespace Mvc.Crud.Challenge.Services
{
	public class CarsService : ICarsService
	{
		private const int PriceRange = 5000;
		private const int MinimumCarId = 1;

		private readonly ICarRepository _carRepository;

        public CarsService(ICarRepository carRepository)
        {
			_carRepository = carRepository;
        }

        public IEnumerable<Car> GetAllCars()
		{
			return _carRepository.GetAllCars();
		}

		public Car GetCar(int id)
		{
			if (id < 1)
				throw new ArgumentException(nameof(id));

			return _carRepository.GetCar(id);
		}

		public void CreateCar(Car car)
		{
			CheckIfCarIsNull(car);

			_carRepository.CreateCar(car);
		}

		public void DeleteCar(int id)
		{
			CheckIfCardIdIsValid(id);

			_carRepository.DeleteCar(id);
		}

		public void EditCar(Car car)
		{
			CheckIfCarIsNull(car);

			_carRepository.SaveCar(car);
		}

		public bool IsPriceInRange(int carId, int inputPrice)
		{
			CheckIfCardIdIsValid(carId);

			var price = _carRepository.RetriveCarPrice(carId);

			var lowerRange = price - PriceRange;
			var higgestRange = price + PriceRange;

			return inputPrice >= lowerRange && inputPrice <= higgestRange;
		}

		private void CheckIfCardIdIsValid(int id)
		{
			if (id < MinimumCarId)
				throw new ArgumentException(nameof(id));
		}

		private void CheckIfCarIsNull(Car car)
		{
			if (car is null)
				throw new NullReferenceException(nameof(car));
		}
	}
}