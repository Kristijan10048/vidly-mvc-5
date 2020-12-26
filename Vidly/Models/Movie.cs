
using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Movie
    {
        #region Public Movie Properties
        /// <summary>
        /// Movie Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Movie Name
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Movie Genre
        /// </summary>
        public Genre Genre { get; set; }

        /// <summary>
        /// Ganre Id
        /// </summary>
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        /// <summary>
        /// Data of the move when it is added
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// Release date of the movie
        /// </summary>
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Available movies ???
        /// </summary>
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        /// <summary>
        /// Number of available movies
        /// </summary>
        public byte NumberAvailable { get; set; }
        #endregion
    }
}