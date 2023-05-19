using Taller.Code.Challenge.Interfaces;
using Taller.Code.Challenge.Models;

namespace Taller.Code.Challenge.Repositories
{
	public class CarRepository : Context, ICarRepository 
	{
		public IEnumerable<Car> GetAllCars()
		{
			return Cars;
		}

		public Car GetCar(int id)
		{
			return Cars.FirstOrDefault(c => c.Id == id);
		}

		public void CreateCar(Car car)
		{
			car.Id = Cars.Max(c => c.Id) + 1;
			Cars.Add(car);
		}

		public void SaveCar(Car car)
		{
			var carToEdit = GetCar(car.Id);
			carToEdit.Make = car.Make;
			carToEdit.Model = car.Model;
			carToEdit.Year = car.Year;
			carToEdit.Doors = car.Doors;
			carToEdit.Color = car.Color;
			carToEdit.Price = car.Price;
		}

		public void DeleteCar(int id)
		{
			Cars.Remove(GetCar(id));
		}

		public int RetriveCarPrice(int carId)
		{
			return GetCar(carId).Price;
		}
	}
}