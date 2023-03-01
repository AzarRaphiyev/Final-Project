namespace JobBoard.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public Position? position { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "It can be 30 characters")]
        public string Fullname { get; set; }
        [Required]
        [StringLength(maximumLength: 1000, ErrorMessage = "It can be 1000 characters")]
        public string Description { get; set; }

        [StringLength(maximumLength: 300, ErrorMessage = "It can be 300 characters")]
        public string? InstagramUlr { get; set; }
        [StringLength(maximumLength: 300, ErrorMessage = "It can be 300 characters")]
        public string? FecebookUrl { get; set; }
        [StringLength(maximumLength: 300, ErrorMessage = "It can be 300 characters")]
        public string? TwitterUrl { get; set; }
        [StringLength(maximumLength: 300, ErrorMessage = "It can be 300 characters")]
        public string? LinkedinUrl { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "It can be 100 characters")]
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
