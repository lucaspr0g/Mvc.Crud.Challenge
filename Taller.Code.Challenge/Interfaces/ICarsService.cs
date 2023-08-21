using Mvc.Crud.Challenge.Models;

namespace Mvc.Crud.Challenge.Interfaces
{
	public interface ICarsService
	{
		IEnumerable<Car> GetAllCars();
		Car GetCar(int id);
		void CreateCar(Car car);
		void DeleteCar(int id);
		void EditCar(Car car);

		bool IsPriceInRange(int carId, int inputPrice);
	}
}