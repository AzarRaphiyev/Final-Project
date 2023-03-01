namespace JobBoard.Models
{
    public class ServicesSite
    {
        public int Id { get; set; }

        [Required]
        public int Order { get; set; }
        [Required]
        [StringLength(maximumLength:100,ErrorMessage = "Must contain no more than 50 characters")]
        public string Name { get; set; }        
        [Required]
        [StringLength(maximumLength:3000,ErrorMessage = "Must contain no more than 3000 characters")]
        public string Description { get; set; }
        [Required]
        [StringLength(maximumLength: 1000, ErrorMessage = "Must contain no more than 1000 characters")]
        public string Icon { get; set; }
    }
}
