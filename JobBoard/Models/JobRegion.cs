namespace JobBoard.Models
{
    public class JobRegion
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "can be a maximum of 30 characters")]
        public string Region { get; set; }
    }
}
