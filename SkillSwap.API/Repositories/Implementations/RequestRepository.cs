using SkillSwap.API.Repositories.Interfaces;
using SkillSwap.API.Data;
using SkillSwap.API.Models;
using Microsoft.EntityFrameworkCore;

namespace SkillSwap.API.Repositories.Implementations
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _context;

        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }
        //this is just a comment
        public async Task<Request> AddRequest(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<Request?> GetById(int Id)
        {
            return await _context.Requests
                .Include(r => r.Sender)
                .Include(r => r.Receiver)
                .FirstOrDefaultAsync(r => r.Id == Id);
        }

        public async Task<IEnumerable<Request>> GetSentRequests(int senderId)
        {
            return await _context.Requests
                .Include(r => r.Receiver) 
                .Where(r => r.SenderId == senderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetReceivedRequests(int receiverId)
        {
            return await _context.Requests
                .Include(r => r.Sender) 
                .Where(r => r.ReceiverId == receiverId)
                .ToListAsync();
        }

        public async Task<bool> ExistsBetweenUsers(int senderId, int receiverId)
        {
            return await _context.Requests
                .AnyAsync(r => r.SenderId == senderId && r.ReceiverId == receiverId);
        }

        public async Task Update(Request request)
        {
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
        }
    }
}
