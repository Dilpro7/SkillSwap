using SkillSwap.API.Models;

namespace SkillSwap.API.Repositories.Interfaces
{
    public interface IRequestRepository
    {
        Task<Request> AddRequest(Request request);
        Task<Request?> GetById(int Id);
        Task<IEnumerable<Request>> GetSentRequests(int senderId);
        Task<IEnumerable<Request>> GetReceivedRequests(int receiverId);
        Task<bool> ExistsBetweenUsers(int senderId,int receiverId);
        Task Update(Request request);
    }
}
