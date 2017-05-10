using StoreSample.Web.Data;
using System;

namespace StoreSample.Web.Models
{
    public static class ModelExtensions
    {
        /// <summary>
        /// Returns the url of the image book.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static string GetCoverUrl(this Book book)
        {
            //var u = new UrlHelper(HttpContext.Current.Request.RequestContext);
            //return u.Content(String.Format("~/Content/images/covers/{0}.png", book.IdBook));
            return String.Format("https://storesamplestorage.blob.core.windows.net/books/{0}.png", book.IdBook);
        }
    }
}