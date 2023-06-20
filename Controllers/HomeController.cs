using System.Web.Mvc;
using SignIframeIntegration.Models;
using Bulksign.Api;

namespace SignIframeIntegration.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View(new HomeViewModel()
			{
				Email = "youremai@email.com",
				Name = "Your Name",
				Url = string.Empty
			});
		}

		[HttpPost]
		public ActionResult SendEnvelope(string name, string email)
		{
			BulksignResult<SendEnvelopeResultApiModel> result = new BulksignIntegration().SendEnvelope(name, email, this.Request.MapPath("~/TestFile/bulksign_test_sample.pdf"));

			if (result.IsSuccessful)
			{
				string url = result.Result.RecipientAccess[0].SigningUrl;

				return View("Index", new HomeViewModel()
				{
					Url = url
				});
			}

			return Content("Error");
		}
	}
}