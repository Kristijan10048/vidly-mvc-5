using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class ImdbMovie
    {
        #region Public Properties
        /// <summary>
        /// Movie Id
        /// </summary>
        public int Id  { get; set; }

        /// <summary>
        /// Move name in IMDB
        /// </summary>
        public string ImdbName { get; set; }

        /// <summary>
        /// Move Url on imdb website
        /// </summary>
        public string ImdbUrl { get; set; }
        #endregion
    }
}