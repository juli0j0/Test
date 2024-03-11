using System.ComponentModel.DataAnnotations.Schema;

namespace TestServer.DTO
{
    public class TestIdDTO
    {
        public int? Number { get; set; }
        public string? Text { get; set; }
        public string? CorrectAnswer { get; set; }

        [Column(TypeName = "XML")]
        public string? OtherAnswer { get; set; }    
    }
}
