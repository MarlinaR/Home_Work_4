using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project4.Models
{
    public class SampleData
    {
        public static void Initialize(BookContext context)
        {
           
            if (!context.Books.Any()) {
                context.Books.AddRange(
                    new Book
                    {
                        Name = "Red",
                        Artist = "FireGuy",
                        Count = 6
                    },
                    new Book
                    {
                        Name = "Black",
                        Artist = "NiggaGuy",
                        Count = 10
                    },
                    new Book
                    {
   
                        Name = "Yellow",
                        Artist = "SunGuy",
                        Count = 12
                    }
                ); 
                context.SaveChanges();
            }

            if (!context.Authors.Any()) {
                context.Authors.AddRange(
                    new Author
                    {
                        Name = "RedGuy",
                        Country = "Russia",
                       
                    },
                    new Author
                    {
                        Name = "YellowGuy",
                        Country = "China",
                    },
                    new Author
                    {

                        Name = "WhiteGuy",
                        Country = "USA",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
