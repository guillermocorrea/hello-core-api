using CityInfo.API.Data;
using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var pointsOfInterest = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (pointsOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointsOfInterest.PointsOfInterest);
        }

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var pointsOfInterest = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (pointsOfInterest == null)
            {
                return NotFound();
            }

            var pointOfInterest = pointsOfInterest.PointsOfInterest.FirstOrDefault(x => x.Id == id);
            if (pointsOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = PointOfInterestMapper.Convert(pointOfInterest);
            finalPointOfInterest.Id = maxPointOfInterestId + 1;

            city.PointsOfInterest.Add(finalPointOfInterest);
            return CreatedAtRoute("GetPointOfInterest", new { cityId = city.Id, id = finalPointOfInterest.Id }, finalPointOfInterest);
        }

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id, [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFound = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterestFound == null)
            {
                return NotFound();
            }

            PointOfInterestMapper.UpdateValues(pointOfInterest, pointOfInterestFound);
            return NoContent();
        }

        [HttpPatch("{cityId}/pointsofinterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id, [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFound = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterestFound == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = PointOfInterestMapper.Convert(pointOfInterestFound);
            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pointOfInterestToPatch.Description == pointOfInterestToPatch.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from name.");
            }

            TryValidateModel(pointOfInterestToPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PointOfInterestMapper.UpdateValues(pointOfInterestToPatch, pointOfInterestFound);
            return NoContent();
        }

        [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFound = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterestFound == null)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestFound);
            return NoContent();
        }
    }
}
