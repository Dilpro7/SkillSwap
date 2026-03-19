using SkillSwap.API.Models;

namespace SkillSwap.API.Services.Interfaces
{
    public interface IRequestService 
    {
        
       Task<Request> SendRequest(int senderId, int receiverId);
       Task <IEnumerable<Request>>GetSentRequests(int senderId);
       Task <IEnumerable<Request>> GetReceivedRequests(int receiverId);
        Task <Request> AcceptRequest(int requestId,int currentUserId);
        Task <Request> RejectRequest(int requestId,int currentUserId);

    }
}
