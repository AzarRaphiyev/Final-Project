namespace JobBoard.Models
{
    public class MiniInfoBar
    {
        public int Id { get; set; }

		[Required]
		public int order { get; set; }
		[Required]
        [StringLength(maximumLength:100,ErrorMessage = "Can be a maximum of 100 characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 500, ErrorMessage = "Can be a maximum of 500 characters")]
        public string Description { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
