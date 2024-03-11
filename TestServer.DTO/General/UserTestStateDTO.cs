namespace TestServer.DTO.General
{
    public class UserTestStateDTO
    {
        public long UserId { get; set; }
        public long TestId { get; set; }    
        public byte IsPassed { get; set; }
        public byte Grade { get; set; }
    }
}
