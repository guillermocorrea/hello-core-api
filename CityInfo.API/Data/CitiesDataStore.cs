using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Data
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public IList<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>();
            //Cities = new List<CityDto>()
            //{
            //    new CityDto()
            //    {
            //        Id = 1,
            //        Name = "New York City",
            //        Description = "The one with the big park.",
            //        PointsOfInterest = new List<PointOfInterestDto>()
            //        {
            //            new PointOfInterestDto()
            //            {
            //                Id = 1,
            //                Name = "Central Park",
            //                Description = "Lorem ipsum."
            //            },
            //            new PointOfInterestDto()
            //            {
            //                Id = 2,
            //                Name = "5th avenue",
            //                Description = "Lorem ipsum."
            //            }
            //        }
            //    },
            //    new CityDto()
            //    {
            //        Id = 2,
            //        Name = "Antwerp",
            //        Description = "The one with the cathedral that was never really finished.",
            //        PointsOfInterest = new List<PointOfInterestDto>()
            //        {
            //            new PointOfInterestDto()
            //            {
            //                Id = 3,
            //                Name = "The cathedral",
            //                Description = "Lorem ipsum."
            //            }
            //        }
            //    },
            //    new CityDto()
            //    {
            //        Id = 3,
            //        Name = "Paris",
            //        Description = "The one with that big tower.",
            //        PointsOfInterest = new List<PointOfInterestDto>()
            //        {
            //            new PointOfInterestDto()
            //            {
            //                Id = 4,
            //                Name = "Eiffel Tower",
            //                Description = "Lorem ipsum."
            //            },
            //            new PointOfInterestDto()
            //            {
            //                Id = 5,
            //                Name = "Louvre museum",
            //                Description = "Lorem ipsum."
            //            }
            //        }
            //    }
            //};
        }
    }
}
