using Microsoft.EntityFrameworkCore;
using SkillSwap.API.Data;
using SkillSwap.API.Models;
using SkillSwap.API.Services.Interfaces;
using SkillSwap.API.Repositories.Interfaces;
namespace SkillSwap.API.Services.Implementations
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly AppDbContext _context;
        public RequestService(IRequestRepository requestRepository, AppDbContext context)
        {
            _requestRepository = requestRepository;
            _context = context;
        }
        public async Task<Request> SendRequest(int senderId, int receiverId)
        {
            if (senderId == receiverId)
            {
                throw new ArgumentException("Sender and Receiver cannot be the same user.");
            }
            var receiverExists = await _context.Users.AnyAsync(u => u.Id == receiverId);
            if (!receiverExists)
            {
                throw new ArgumentException("Receiver does not exist.");
            }
            var requestExists = await _requestRepository.ExistsBetweenUsers(senderId, receiverId);
            if (requestExists)
            {
                throw new InvalidOperationException("Request already exists between these users.");
            }
            var request = new Request
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Status = Request.RequestStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };
            return await _requestRepository.AddRequest(request);
        }
        public async Task<IEnumerable<Request>> GetReceivedRequests(int userId)
        {
            return await _requestRepository.GetReceivedRequests(userId);
        }
        public async Task<IEnumerable<Request>> GetSentRequests(int userId)
        {
            return await _requestRepository.GetSentRequests(userId);
        }
        public async Task<Request> AcceptRequest(int requestId,int currentUserId)
        {
            var request = await _requestRepository.GetById(requestId);
            if (request == null)
            {
                throw new ArgumentException("Request not found.");
            }
            if(request.ReceiverId!=currentUserId)
            {
                throw new InvalidOperationException("Only the receiver can accept the request.");
            }
            if (request.Status != Request.RequestStatus.Pending)
            {
                throw new InvalidOperationException("Only pending requests can be accepted.");
            }
            request.Status = Request.RequestStatus.Accepted;
            await _requestRepository.Update(request);
            return request;
        }
        public async Task<Request> RejectRequest(int requestId,int currentUserId)
        {
            var request = await _requestRepository.GetById(requestId);
            if (request == null)
            {
                throw new ArgumentException("Request not found.");
            }
            if(request.ReceiverId!=currentUserId)
            {
                throw new InvalidOperationException("Only the receiver can reject the request.");
            }
            if (request.Status != Request.RequestStatus.Pending)
            {
                throw new InvalidOperationException("Only pending requests can be rejected.");
            }
            request.Status = Request.RequestStatus.Rejected;
            await _requestRepository.Update(request);
            return request;
        }
    }
}
