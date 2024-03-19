
namespace Mission11_Webb.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext context;
        public EFBookstoreRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public List<Book> Books => context.Books.ToList();
    }
}
