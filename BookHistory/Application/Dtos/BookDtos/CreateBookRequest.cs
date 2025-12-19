using System.ComponentModel.DataAnnotations;

namespace BookHistory.Application.Dtos.BookDtos
{
    public sealed class CreateBookRequest
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; init; } = String.Empty;
        [Required]
        [MaxLength(1000)]
        public string Description { get; init; } = String.Empty;
        [Required]
        public DateOnly PublishDate { get; init; }
        [Required]
        public List<string> Authors { get; init; } = [];
    }
}
