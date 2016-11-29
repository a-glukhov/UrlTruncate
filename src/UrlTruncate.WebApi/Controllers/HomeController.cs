namespace UrlTruncate.WebApi.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using UrlTruncate.Model.Models;
    using UrlTruncate.Service.Providers;

    public class HomeController : Controller
    {
        private readonly ITruncatedUrlServiceProvider truncatedUrlServiceProvider;

        public HomeController(ITruncatedUrlServiceProvider serviceProvider)
        {
            this.truncatedUrlServiceProvider = serviceProvider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Redirect(string truncatedUrl)
        {
            TruncatedUrl url = await this.truncatedUrlServiceProvider.TruncatedUrlService.Jump(truncatedUrl);

            return this.RedirectPermanent(url.OriginalUrl);
        }

        public ActionResult History()
        {
            ViewBag.Message = "Information about created links";

            return View();
        }
    }
}
