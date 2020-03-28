using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TourAgency.Api.ViewModels;
using TourAgency.Api.ViewModels.Tour;
using TourAgency.BLL.Dtos;
using TourAgency.BLL.Services;

namespace TourAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IEntityService<TourDto> _tourService;

        public TourController(ILoggerFactory logger, IMapper mapper, IEntityService<TourDto> tourService)
        {
            _logger = logger.CreateLogger(nameof(TourController));
            _mapper = mapper;
            _tourService = tourService;
        }

        [HttpGet]
        public ActionResult<TourListViewModel> Get(int pageNumber = 1, string propertyName = "Id", string search = null)
        {
            _logger.LogInformation("Get tours");
            (var toursDto, int totalItems) = _tourService.Find(pageNumber, PagingInfo.PageSize, propertyName, search);
            if (toursDto == null)
            {
                _logger.LogInformation("Tours not found");
                return NotFound();
            }
            var toursViewModel = _mapper.Map<IEnumerable<TourViewModel>>(toursDto);
            var tourListViewModel = new TourListViewModel
            {
                TourViewModels = toursViewModel,
                Paginginfo = new PagingInfo
                {
                    Totalitems = totalItems,
                    CurrentPage = pageNumber,
                    ItemsPerPage = PagingInfo.PageSize
                }
            };
            return tourListViewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<TourViewModel> Get(int id)
        {
            _logger.LogInformation($"Get tour by id {id}");
            var tourDto = _tourService.GetById(id);
            if (tourDto == null)
            {
                _logger.LogWarning($"Tour not found {id}");
                return NotFound();
            }
            var tourViewModel = _mapper.Map<TourViewModel>(tourDto);
            return tourViewModel;
        }

        [Authorize]
        [HttpPost]
        public ActionResult<TourViewModel> Post(TourViewModel tourViewModel)
        {
            _logger.LogInformation($"Creating new tour");
            if (tourViewModel == null)
            {
                _logger.LogWarning($"Null tour argument {nameof(tourViewModel)}");
                return BadRequest();
            }

            var tourDto = _mapper.Map<TourDto>(tourViewModel);
            _tourService.Add(tourDto);
            return Ok(tourViewModel);
        }

        [Authorize]
        [HttpPut]
        public ActionResult<TourViewModel> Put(TourViewModel tourViewModel)
        {
            _logger.LogInformation($"Update tour");
            if (tourViewModel == null)
            {
                _logger.LogWarning($"Null tour argument {nameof(tourViewModel)}");
                return BadRequest();
            }
            var tour = _mapper.Map<TourDto>(tourViewModel);
            _tourService.Update(tour);
            return Ok(tourViewModel);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<TourViewModel> Delete(int id)
        {
            _logger.LogInformation($"Delete tour {id}");
            var tour = _tourService.GetById(id);
            _tourService.Delete(id);
            return Ok(tour);
        }
    }
}