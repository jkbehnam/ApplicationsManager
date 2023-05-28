using ApplicationsManager.Entitiy;

namespace Api.Endpoint.Helpers.Authorizations
{
    public class UPCheck
    {
        public static bool Login(string username, string password, UserRole role)
        {
            //using (RasisSoftwareSolutionEntities entities = new RasisSoftwareSolutionEntities())
            //{
            //    Boolean flag = false;
            //    Int32? returnId = entities.UPCheckAPI(username, password).FirstOrDefault();
            //    if (returnId > 0)
            //        flag = true;
            //    return flag;
            //}
            return true;
        }
    }
}