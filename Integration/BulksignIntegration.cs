using System;
using System.IO;
using Bulksign.Api;


namespace SignIframeIntegration
{
	public class BulksignIntegration
	{
		private const string userEmail = "";
		private const string key = "";


		public BulksignResult<SendEnvelopeResultApiModel> SendEnvelope(string name, string email, string filePath)
		{
			//specify the integration url for on-premise version of Bulksign, leave empty to target bulksign.com
			//BulksignApiClient api = new BulksignApiClient("http://your_on_premise_BulksignApi_endpoint);

			BulksignApiClient api = new BulksignApiClient();
			

			
			EnvelopeApiModel envelope = new EnvelopeApiModel();
			envelope.Name = "Website Integration Sample";
			envelope.DisableSignerEmailNotifications = true; //no email notifications


			RecipientApiModel recipient = new RecipientApiModel();
			recipient.Index = 1;
			recipient.Email = email;
			recipient.Name = name;
			recipient.RecipientType = RecipientTypeApi.Signer;

			envelope.Recipients = new RecipientApiModel[1] { recipient };


			DocumentApiModel document = new DocumentApiModel();
			document.FileName = "test.pdf";
			document.FileContentByteArray = new FileContentByteArray()
			{
				ContentBytes = File.ReadAllBytes(filePath)
			};

			envelope.Documents = new DocumentApiModel[1] { document };


			AuthenticationApiModel auth = new AuthenticationApiModel();

			auth.UserEmail = userEmail;
			auth.Key = key;


			return api.SendEnvelope(auth, envelope);
		}

	}
}