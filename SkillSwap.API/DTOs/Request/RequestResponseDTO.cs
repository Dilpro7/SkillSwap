namespace SkillSwap.API.DTOs.Request
{
    public class RequestResponseDTO
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
