using System.Text.Json;
using System.Text.Json.Serialization;
using Backend.Class.DTO;
using Backend.Class.Records;
using Microsoft.Extensions.Logging;

namespace Backend.Services
{
    public interface IBookRepository
    {
        public Book Create(CreateBookDTO newBook);
        public bool Update(UpdateBookDTO newState);
        public bool Delete(int id);
        public GetBookDTO? Get(int id);
        public GetBookDTO[] GetAll();
        public bool Exists(int id);
    }

    public class BookRepository : IBookRepository
    {

        private ILogger<IBookRepository> _logger { get; set; }
        public BookRepository(ILogger<IBookRepository> logger)
        {
            _logger = logger;
            Books =
            [
                new()
                {
                    Id = 1,
                    Title = "It",
                    FirstName = "Stephen",
                    SurName = "King",
                    PublicationDate = new DateOnly(1986, 1, 1),
                    BookType = "Bunden",
                    NoOfPages = 768
                },
                new()
                {
                    Id = 2,
                    Title = "The Shining",
                    FirstName = "Stephen",
                    SurName = "King",
                    PublicationDate = new DateOnly(1977, 1, 1),
                    BookType = "Pocket",
                    NoOfPages = 250
                },
                new()
                {
                    Id = 3,
                    Title = "The Clash of Kings",
                    FirstName = "George R.R.",
                    SurName = "Martin",
                    PublicationDate =  new DateOnly(1996, 1, 1),
                    BookType = "Bunden",
                    NoOfPages = 650
                },
                new()
                {
                    Id = 4,
                    Title = "The Lady of the Lake",
                    FirstName = "Andrzej",
                    SurName = "Sapkowski",
                    PublicationDate =  new DateOnly(1996, 1, 1),
                    BookType = "Pocket",
                    NoOfPages = 544
                },
                new()
                {
                    Id = 5,
                    Title = "Sword of Destiny",
                    FirstName = "Andrzej",
                    SurName = "Sapkowski",
                    PublicationDate =  new DateOnly(1996, 1, 1),
                    BookType = "Pocket",
                    NoOfPages = 250
                },

            ];
        }

        private List<Book> Books { get; set; }

        public GetBookDTO[] GetAll() => Books.Select(x => new GetBookDTO(x)).ToArray();

        public bool Delete(int id) => Books.RemoveAll(x => x.Id == id) > 0;

        public GetBookDTO? Get(int id) =>
            Books.Where(b => id == b.Id).Select(book => new GetBookDTO(book)).FirstOrDefault();

        public bool Update(UpdateBookDTO newState)
        {
            var book = Books.Find(x => x.Id == newState.Id);
            if (book == null) return false;
            try
            {
                book.Title = newState.Title;
                book.FirstName = newState.FirstName;
                book.SurName = newState.SurName;
                book.PublicationDate = newState.PublicationDate;
                book.NoOfPages = newState.NoOfPages;
                book.BookType = newState.BookType;
                book.NoOfPages = newState.NoOfPages;
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return false;
            }
            return true;
        }

        public Book Create(CreateBookDTO newBook)
        {
            Book b =
                new()
                {
                    Id = Books.Max(b => b.Id) + 1,
                    Title = newBook.Title,
                    FirstName = newBook.FirstName,
                    SurName = newBook.SurName,
                    PublicationDate = newBook.PublicationDate,
                    BookType = newBook.BookType,
                    NoOfPages = newBook.NoOfPages
                };
            Books.Add(b);
            return b;
        }

        public bool Exists(int id) => Books.Any(b => b.Id == id);
    }
}
