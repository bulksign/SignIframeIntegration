using System.ComponentModel.DataAnnotations;

namespace SignIframeIntegration.Models
{
	public class HomeViewModel
	{
		[MaxLength(100)]
		public string Name
		{
			get;
			set;
		}


		[MaxLength(50), EmailAddress]
		public string Email
		{
			get;
			set;
		}


	    public string Url
	    {
	        get;
	        set;
	    }
	}
}