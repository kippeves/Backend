using Backend.Class.Records;

namespace Backend.Class.DTO
{
    public record GetBookDTO
    {
        public GetBookDTO(Book b)
        {
            Id = b.Id;
            Title = b.Title;
            FirstName = b.FirstName;
            SurName = b.SurName;
            PublicationDate = b.PublicationDate;
            NoOfPages = b.NoOfPages ?? 0;
            BookType = b.BookType;
        }
        public int Id { get; init; }
        public string Title { get; init; }
        public string FirstName { get; init; }
        public string SurName { get; init; }
        public DateOnly? PublicationDate { get; init; }
        public int NoOfPages { get; set; }
        public string? BookType { get; set; }
    }
}