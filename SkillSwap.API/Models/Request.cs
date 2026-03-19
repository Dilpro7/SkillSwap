namespace SkillSwap.API.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public enum RequestStatus
        {
            Pending,
            Accepted,
            Rejected
        }
        public RequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
        public User? Sender { get; set; }
        public User? Receiver { get; set; }//users who receive the request
    }
}
