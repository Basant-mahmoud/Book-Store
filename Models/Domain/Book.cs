using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Models.Domain
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
         [Required]
        public string Isbn {  get; set; }
        [Required]
        public int TotalPages {  get; set; }
        [Required]
        public int AutherId { get; set; }
        [Required]
        public int PublisherId {  get; set; }
        [Required]
        public int GenreId {  get; set; }
        [NotMapped]
        public string? AuthorName {  get; set; }
        [NotMapped]
        public string? PublisherName { get; set; }
        [NotMapped]
        public string? GenreName { get; set; }
        [NotMapped]
        public List<SelectListItem>? Booklist { get; set; }
        [NotMapped]
        public List<SelectListItem>? Genrelist { get; set; }
        [NotMapped]
        public List<SelectListItem>? Authorlist { get; set; }
        [NotMapped]
        public List<SelectListItem>? Publisherlist { get; set; }






    }
}
