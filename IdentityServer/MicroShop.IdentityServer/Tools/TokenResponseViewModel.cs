using System;

namespace MicroShop.IdentityServer.Tools
{
	public class TokenResponseViewModel
	{
		public TokenResponseViewModel(string token, DateTime expireData)
		{
			Token = token;
			ExpireDate = expireData;
		}

		public string Token { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
