namespace JobBoard.Models
{
    public class JobSeeker
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public int? CompanyId { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 8, ErrorMessage = "Maksimum 30 simvol ola biler")]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool IsCompleted { get; set; }=false;

        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Maksimum 100 simvol ola biler")]
        public string Image { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Maksimum 100 simvol ola biler")]
        public string Cv { get; set; }
        public Job? Job { get; set; }
        public Company? Company { get; set; }
         
    }
}
