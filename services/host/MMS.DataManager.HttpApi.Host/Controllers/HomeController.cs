namespace MMS.DataManager.Controllers
{
    public class HomeController : AbpController
    {
        public ActionResult Index()
        {
            return Redirect("/Login");
        }
    }
}
