using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DomainModel
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// Should always be stored in format: (00) 0000 0000
        /// </summary>
        public string PhoneNumberText { get; set; }

        /// <summary>
        /// Phone number as entered into UI is converted to a long here, for use as a natural key
        /// </summary>
        public long PhoneNumberKey { get; set; }

        public CuisineEnum Cuisine { get; set; }
        public string HeadChefName { get; set; }
        
        /// <summary>
        /// "star-ratings" for food/wine must be in range 0 - 3
        /// </summary>
        public byte? RatingFood { get; set; }
        public byte? RatingWine { get; set; }

        public string StreetAddress { get; set; }
        public string AddressSuburb { get; set; }
        public string AddressState { get; set; }
        public string AddressPostCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string WebAddress { get; set; }
        public string ReviewText { get; set; }
    }
}
