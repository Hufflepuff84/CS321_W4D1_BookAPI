using System;
using System.ComponentModel.DataAnnotations;
using CS321_W4D1_BookAPI.Models;
using CS321_W4D1_BookAPI.Data;
using System.Security.Policy;
using CS321_W4D1_BookAPI.ApiModels;
using CS321_W4D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W4D1_BookAPI.ApiModels
{
    public class BookModel
    {
        public int Id { get; set; }
        // TODO: fill in BookModel properties
        
        public string Title { get; set; }
        public string OriginalLanguage { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }

        public int AuthorId { get; set; }
        public string Author { get; set; } // simple string

        public int PublisherId { get; set; }
        public string Publisher { get; set; }
        
        
    }
}
// asdf
