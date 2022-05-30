using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonDataDTO;
using ExcursionDTO;
using ExcursionBLL;

namespace ExcursionAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ExcursionController : ControllerBase
    {

        readonly ILogger<ExcursionController> _logger;
        readonly IExcursionBusinessLogic _bll;

        public ExcursionController(IExcursionBusinessLogic BusinessLogic, ILogger<ExcursionController> Logger)
        {
            _bll = BusinessLogic;
            _logger = Logger;
        }

        [HttpGet("GetAvailableMeetingPoint")]
        public MeetingPoint[] GetAvailableMeetingPoint()
        {
            return _bll.GetAvailableMeetingPoint();
        }

        [HttpGet("ExcursionAvailabilities/{MeetingPointId}")]
        public ExcursionAvailability[] GetExcursionAvailabilities(Guid MeetingPointId)
        {
            if (MeetingPointId != null)
            {
                MeetingPoint? cm = _bll.GetMeetingPoint(MeetingPointId);
                if (cm != null)
                {
                    return _bll.GetExcursionAvailabilities(cm);
                }
            }

            // Aucun résultat
            return new List<ExcursionAvailability>().ToArray();
        }

        [HttpGet("Excursion/{ExcursionId}")]
        public Excursion? GetExcursion(Guid ExcursionId)
        {
            var Excursion = _bll.GetExcursion(ExcursionId);
            return Excursion;
        }

        [HttpPost("Book")]
        public ExcursionBooking Book(Guid ExcursionId, DateTime From, Person rentedTo)
        {
            return _bll.Book(ExcursionId, From, rentedTo);
        }
    }
}
