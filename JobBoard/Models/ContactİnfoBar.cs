namespace JobBoard.Models
{
    public class ContactİnfoBar
    {
        public int id { get; set; }

        [Required]
        [StringLength(maximumLength:200,ErrorMessage = "Maximum can be 200 characters")]
        public string Address { get; set; }
        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "Maximum can be 30 characters")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maximum can be 100 characters")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
