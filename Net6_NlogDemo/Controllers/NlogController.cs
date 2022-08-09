using Microsoft.AspNetCore.Mvc;

namespace Net6_NlogDemo.Controllers
{
    public class NlogController : Controller
    {
        private readonly ILogger<ProductLog> _Productlogger;
        private readonly ILogger<OrderLog> _Orderlogger;
        private readonly ILogger<ExtensionLog> _Extensionlogger;

        public NlogController(ILogger<ProductLog> productlogger, ILogger<OrderLog> orderlogger)
        {
            _Productlogger = productlogger;
            _Orderlogger = orderlogger;
        }

        public IActionResult Product()
        {
            try
            {
                _Productlogger.LogInformation("寫入info log");
                throw new Exception("錯了");
                return Json("成功");
            }
            catch (Exception ex)
            {
                _Productlogger.LogError(ex, "寫入error log");
                return Json("失敗");
            }
        }

        public IActionResult Order()
        {
            try
            {
                _Orderlogger.LogInformation("寫入info log");
                throw new Exception("錯了");
                return Json("成功");
            }
            catch (Exception ex)
            {
                _Orderlogger.LogError(ex, "寫入error log");
                return Json("失敗");
            }
        }
        public IActionResult Extension()
        {
            _Extensionlogger.LogInformation("admin01", "寫入info log");
            return Json("成功");
        }
    }
}
