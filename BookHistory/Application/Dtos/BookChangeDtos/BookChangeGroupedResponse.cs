namespace BookHistory.Application.Dtos.BookChangeDtos
{
    public class BookChangeGroupedResponse
    {
        public required DateOnly Date { get; set; }
        public required ICollection<BookChangeResponse> Changes { get; set; }
    }
}
