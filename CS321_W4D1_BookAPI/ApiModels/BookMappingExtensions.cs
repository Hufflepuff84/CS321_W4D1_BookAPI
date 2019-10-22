using CS321_W4D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D1_BookAPI.ApiModels
{
    public static class BookMappingExtenstions
    {

        public static BookModel ToApiModel(this Book book)
        {
            // TODO: map the Book domain object to a BookModel
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                OriginalLanguage = book.OriginalLanguage,
                PublicationYear = book.PublicationYear,
                
                AuthorId = book.AuthorId,
                Author = book.Author != null?
                    book.Author.LastName + ", " +
                    book.Author.FirstName:"Unknown",
                // concatenate the author's name properties and use it as the value of
                // Author. Use null if the Author is null.
                //Author = needsToBeConvertedBook.Author.LastName + 
                //", " + needsToBeConvertedBook.Author.FirstName, //Publiser
                    // ? needsToBeConvertedBook.Author.LastName + ", " + needsToBeConvertedBook.Author.FirstName
                    // : null
                    PublisherId = book.PublisherId,
                    Publisher = book.Publisher != null ?
                    book.Publisher.Name + ", " +
                    book.Publisher.HeadQaurtersLocation : "NA"

            };
        }

        public static Book ToDomainModel(this BookModel bookModel)
        {
            // TODO: map the BookModel to a Book domain object
            return new Book
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Genre = bookModel.Genre,
                OriginalLanguage = bookModel.OriginalLanguage,
                PublicationYear = bookModel.PublicationYear,
                PublisherId = bookModel.PublisherId,
                AuthorId = bookModel.AuthorId,
                // Note that we don't set the Publisher or Author object properties. 
                // Setting the PublisherId and AuthorId fields is enough.
            };
        }

        public static IEnumerable<BookModel> ToApiModels(this IEnumerable<Book> authors)
        {
            return authors.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Book> ToDomainModel(this IEnumerable<BookModel> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel());
        }
    }
}
