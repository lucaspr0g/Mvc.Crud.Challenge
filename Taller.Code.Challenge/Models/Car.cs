using Microsoft.AspNetCore.Mvc;

namespace Taller.Code.Challenge.Models
{
    public class Car
    {
        [HiddenInput]
        public int Id { get; set; }

        public string Make { get; set; } = default!;

        public string Model { get; set; } = default!;

        public int Year { get; set; }

        public int Doors { get; set; }

        public string Color { get; set; } = default!;

        public int Price { get; set; } 

    }
}