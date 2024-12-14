using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models.Domain
{
    public class Authorcs
    {
        public int Id { get; set; }
        [Required]
        public string AuthorName { get; set; }
    }
}
