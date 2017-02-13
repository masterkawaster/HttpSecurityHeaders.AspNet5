using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HttpSecurityHeaders.AspNet5
{
	public class HpkpModule : IHttpModule
	{
		private static string certPrimaryHash = WebConfigurationManager.AppSettings["CertPrimaryHash"];
		private static string certSecondaryHash = WebConfigurationManager.AppSettings["CertSecondaryHash"];
		private static string expireTime = WebConfigurationManager.AppSettings["ExpireTime"];
		private static string reportUri = WebConfigurationManager.AppSettings["ReportUri"];


		public void Init(HttpApplication context)
		{
			context.PreSendRequestHeaders += Context_PreSendRequestHeaders;
		}

		private void Context_PreSendRequestHeaders(object sender, EventArgs e)
		{
			if(!string.IsNullOrEmpty(certPrimaryHash) &&
			   !string.IsNullOrEmpty(certSecondaryHash) &&
			   !string.IsNullOrEmpty(expireTime))
				HttpContext.Current.Response.Headers.Add("Public-Key-Pins",
					$"pin-sha256=\"{certPrimaryHash}\"; " +
					$"pin-sha256=\"{certSecondaryHash}\"; " +
					$"max-age={expireTime}; " +
					$"includeSubdomains; " +
					$"report-uri=\"{reportUri}\"");
		}

		public void Dispose()
		{
			
		}
	}
}