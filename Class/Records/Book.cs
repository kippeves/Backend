namespace Backend.Class.Records;

public record Book
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string FirstName { get; set; }
    public required string SurName { get; set; }
    public DateOnly? PublicationDate { get; set; }
    public int? NoOfPages { get; set; }
    public string? BookType { get; set; }
}