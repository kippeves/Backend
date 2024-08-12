namespace Backend.Class.DTO
{
    public record CreateBookDTO
    {
        public required string Title { get; set; }
        public required string FirstName { get; set; }
        public required string SurName { get; set; }
        public DateOnly? PublicationDate { get; set; }
        public int NoOfPages { get; set; }
        public required string BookType { get; set; }
    }
}