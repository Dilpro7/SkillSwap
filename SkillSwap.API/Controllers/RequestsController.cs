using Microsoft.AspNetCore.Mvc;
using SkillSwap.API.DTOs.Request;
using SkillSwap.API.Services.Interfaces;
using SkillSwap.API.Models;
namespace SkillSwap.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestsController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendRequest([FromQuery] int senderId, [FromQuery] int receiverId)
        {
            try
            {
                var request = await _requestService.SendRequest(senderId, receiverId);
                return Ok(new RequestResponseDTO
                {
                    Id = request.Id,
                    SenderId = request.SenderId,
                    ReceiverId = request.ReceiverId,
                    Status = (int)request.Status,
                    CreatedAt = request.CreatedAt
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("sent/{userId}")]
        public async Task<IActionResult> GetSentRequests(int userId)
        {
            var requests = await _requestService.GetSentRequests(userId);
            return Ok(requests.Select(r => new RequestResponseDTO
            {
                Id = r.Id,
                SenderId = r.SenderId,
                ReceiverId = r.ReceiverId,
                Status = (int)r.Status,
                CreatedAt = r.CreatedAt
            }));
        }

        [HttpGet("received/{userId}")]
        public async Task<IActionResult> GetReceivedRequests(int userId)
        {
            var requests = await _requestService.GetReceivedRequests(userId);
            return Ok(requests.Select(r => new RequestResponseDTO
            {
                Id = r.Id,
                SenderId = r.SenderId,
                ReceiverId = r.ReceiverId,
                Status = (int)r.Status,
                CreatedAt = r.CreatedAt
            }));
        }

        [HttpPut("accept/{requestId}")]
        public async Task<IActionResult> AcceptRequest(int requestId, [FromQuery] int currentUserId)
        {
            try
            {
                var request = await _requestService.AcceptRequest(requestId, currentUserId);
                return Ok(new RequestResponseDTO
                {
                    Id = request.Id,
                    SenderId = request.SenderId,
                    ReceiverId = request.ReceiverId,
                    Status = (int)request.Status,
                    CreatedAt = request.CreatedAt
                });
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("reject/{requestId}")]
        public async Task<IActionResult> RejectRequest(int requestId, [FromQuery] int currentUserId)
        {
            try
            {
                var request = await _requestService.RejectRequest(requestId, currentUserId);
                return Ok(new RequestResponseDTO
                {
                    Id = request.Id,
                    SenderId = request.SenderId,
                    ReceiverId = request.ReceiverId,
                    Status = (int)request.Status,
                    CreatedAt = request.CreatedAt
                });
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}