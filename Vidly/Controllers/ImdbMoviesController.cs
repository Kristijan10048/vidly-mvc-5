using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class ImdbMoviesController : Controller
    {
        #region Private Members
        ApplicationDbContext m_appDbAccess;
        #endregion

        #region Constructors/Destructors
        /// <summary>
        /// 
        /// </summary>
        public ImdbMoviesController()
        {
            m_appDbAccess = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            m_appDbAccess.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        // GET: ImdbMovies
        public ActionResult Index()
        {
            //create move list
            var moviesList = new List<ImdbMovie>();

            //insert data in to the list
            //moviesList.Add(new ImdbMovie
            //{
            //    Id = 1,
            //    ImdbName = "test",
            //    ImdbUrl = "www.somethind.com"
            //});

            //get imdb movies from database 
            foreach (var move in m_appDbAccess.AspNetIMDBTable)
                moviesList.Add(move);

            //pass the model to the view
            return View("ImdbMovies", moviesList);
        }
    }
}