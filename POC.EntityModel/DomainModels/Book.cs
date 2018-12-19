using System;

namespace POC.EntityModel
{
    public class Book : BaseEntity
    {
        /// <value>Get or Set Title</value>
        public string Title { get; set; }

        /// <value>Get or Set Price</value>
        public decimal Price { get; set; }

        /// <value>Get or Set Genre</value>
        public string Genre { get; set; }

        /// <value>Get or Set PublishDate</value>
        public DateTime PublishDate { get; set; }

        /// <value>Get or Set Description</value>
        public string Description { get; set; }

        /// <value>Get or Set AuthorId</value>
        public int AuthorId { get; set; }

        /// <value>Get or Set Author</value>
        public Author Author { get; set; }
    }
}
