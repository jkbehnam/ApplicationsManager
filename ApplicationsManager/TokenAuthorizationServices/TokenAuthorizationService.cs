using MakeRasisToken;

namespace CustomerClub.Infrastracture.Utilities.TokenAuthorizationServices
{
    public static class TokenAuthorizationService
    {
        public static string MakeToken()
        {
            string ApiKey1 = SepPaySCG.EncryptDecryptMyPassword.decryptPassword("XkV0ah8QIKnXZaG9yqtpUYY2JYlbG8X1+lBUvUEZAA3rW/MTnSBGlOxNfUE8Ps8Y");
            string ApiKey2 = SepPaySCG.EncryptDecryptMyPassword.decryptPassword("5GtSf+hyrORIvhDHu7E2kBnV55RX8TKp");
            string ApiKey3 = SepPaySCG.EncryptDecryptMyPassword.decryptPassword("he4aG0Aqs1Bbqojv8W0lTNGvtznle+DawyRlc3DRoo5ZRQg/qzCb1A==");
            RasisKeyStore token = new RasisKeyStore(ApiKey1, ApiKey2, ApiKey3);
            var tokenGenerated = token.MakeToken("web", "1234", "1", "NewCustomerClub", "", "", "version3");
            return tokenGenerated;
        }
        public static string MakeToken(string userName, string password)
        {
            string ApiKey1 = SepPaySCG.EncryptDecryptMyPassword.decryptPassword("XkV0ah8QIKnXZaG9yqtpUYY2JYlbG8X1+lBUvUEZAA3rW/MTnSBGlOxNfUE8Ps8Y");
            string ApiKey2 = SepPaySCG.EncryptDecryptMyPassword.decryptPassword("5GtSf+hyrORIvhDHu7E2kBnV55RX8TKp");
            string ApiKey3 = SepPaySCG.EncryptDecryptMyPassword.decryptPassword("he4aG0Aqs1Bbqojv8W0lTNGvtznle+DawyRlc3DRoo5ZRQg/qzCb1A==");
            RasisKeyStore token = new RasisKeyStore(ApiKey1, ApiKey2, ApiKey3);
            var tokenGenerated = token.MakeToken("web", "1234", "1", "RasisGeneralCommodity", userName, password, "version2");
            return tokenGenerated;
        }
    }
}
