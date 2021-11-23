using System;
using System.IO;
using Bulksign.Api;

namespace SignIframeIntegration
{
	public class BulksignIntegration
	{
		private const string authEmail = "";
		private const string authToken = "";


		public BulksignResult<SendEnvelopeResultApiModel> SendEnvelope(string name, string email, string filePath)
		{
			//specify the integration url for on-premise version of Bulksign, leave empty to target bulksign.com
			//BulkSignApi api = new BulkSignApi("http://your_on_premise_BulksignApi_endpoint);

			BulkSignApi api = new BulkSignApi();
			


			EnvelopeApiModel bundle = new EnvelopeApiModel();
			bundle.Name = "Website Integration Sample";
			bundle.DisableSignerEmailNotifications = true; //no email notifications


			RecipientApiModel recipient = new RecipientApiModel();
			recipient.Index = 1;
			recipient.Email = email;
			recipient.Name = name;
			recipient.RecipientType = RecipientTypeApi.Signer;

			bundle.Recipients = new RecipientApiModel[1] { recipient };


			DocumentApiModel document = new DocumentApiModel();
			document.FileName = "test.pdf";
			document.FileContentByteArray = new FileContentByteArray()
			{
				ContentBytes = File.ReadAllBytes(filePath)
			};

			bundle.Documents = new DocumentApiModel[1] { document };


			AuthenticationApiModel auth = new AuthenticationApiModel();

			auth.UserEmail = authEmail;
			auth.Token = authToken;


			return api.SendEnvelope(auth, bundle);
		}

	}
}