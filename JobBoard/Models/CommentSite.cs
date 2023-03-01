namespace JobBoard.Models
{
    public class CommentSite
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:1000,ErrorMessage = "The maximum can be 1000 characters")]
        public string Comment { get; set; }
        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "The maximum can be 30 characters")]
        public string CommentatorName { get; set; }
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "The maximum can be 50 characters")]
        public string CommentatorSurname { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "The maximum can be 100 characters")]
        public string? Commentatorİmage { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "The maximum can be 100 characters")]
        [DataType(DataType.DateTime)]
        public DateTime? Data { get; set; }
        public bool? IsViewed { get; set; } = false;
		public bool IsFavorıte { get; set; } = false;

	}
}
