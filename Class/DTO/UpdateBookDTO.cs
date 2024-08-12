namespace Backend.Class.DTO
{
    public record UpdateBookDTO
    {
        public int Id { get; init; }
        public required string Title { get; set; }
        public required string FirstName { get; set; }
        public required string SurName { get; set; }
        public DateOnly? PublicationDate { get; set; }
        public int NoOfPages { get; set; }
        public required string BookType { get; set; }
    }
}