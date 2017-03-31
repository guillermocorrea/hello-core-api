using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public static class PointOfInterestMapper
    {
        //public static PointOfInterestDto Convert(PointOfInterestForCreationDto dto)
        //{
        //    if (dto == null)
        //    {
        //        throw new ArgumentNullException("dto");
        //    }

        //    return new PointOfInterestDto
        //    {
        //        Description = dto.Description,
        //        Name = dto.Name
        //    };
        //}

        //public static PointOfInterestForUpdateDto Convert(PointOfInterestDto dto)
        //{
        //    if (dto == null)
        //    {
        //        throw new ArgumentNullException("dto");
        //    }

        //    return new PointOfInterestForUpdateDto
        //    {
        //        Description = dto.Description,
        //        Name = dto.Name
        //    };
        //}

        public static void UpdateValues(PointOfInterestForUpdateDto source, PointOfInterestDto destiny)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (destiny == null)
                destiny = new PointOfInterestDto();
            destiny.Description = source.Description;
            destiny.Name = source.Name;
        }
    }
}
