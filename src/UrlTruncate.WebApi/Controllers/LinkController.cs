using System;
using System.Collections.Generic;
using System.Web.Http;

namespace UrlTruncate.WebApi.Controllers
{
    using System.Security.Policy;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    using UrlTruncate.Model.Models;
    using UrlTruncate.Service.Providers;

    public class LinkController : ApiController
    {
        private readonly ITruncatedUrlServiceProvider truncatedUrlServiceProvider;

        public LinkController(ITruncatedUrlServiceProvider serviceProvider)
        {
            this.truncatedUrlServiceProvider = serviceProvider;
        }

        [HttpGet]
        public IEnumerable<TruncatedUrl> Get()
        {
            return this.truncatedUrlServiceProvider.TruncatedUrlService.GetAll();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("URL cannot be empty");
            }

            Uri uriResult;
            bool created = Uri.TryCreate(url, UriKind.Absolute, out uriResult);
            if (!created)
                throw new ArgumentException("Invalid URL format");

            string baseUrl = $"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Authority}";

            TruncatedUrl resultUrl = await this.truncatedUrlServiceProvider.TruncatedUrlService.TruncateUrl(baseUrl, url);

            return this.Ok(resultUrl.ShortUrl);
        }
    }
}
