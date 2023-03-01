namespace JobBoard.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50,ErrorMessage = "Can be a maximum of 50 characters")]
        public string CatagoryName { get; set; }    
    }
}
