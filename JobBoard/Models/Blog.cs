namespace JobBoard.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public int CatagoryId { get; set; }
        [Required]
        public int order { get; set; }
        public int AuthourId { get; set; }
        [Required]
        [StringLength(maximumLength: 500, ErrorMessage = "Can be a maximum of 500 characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 10000, ErrorMessage = "Can be a maximum of 10000 characters")]

        public string Description { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Can be a maximum of 50 characters")]
        [DataType(DataType.DateTime)]
        public DateTime? Data { get; set; }
        
        [StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
        public string? Image { get; set; }
        
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public Catagory? Catagory { get; set; }
        public Authour? Authour { get; set; }
        public List<CommentBlog>? commentBlogs { get; set;}
    }
}
