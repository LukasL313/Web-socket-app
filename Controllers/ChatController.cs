
using Microsoft.AspNetCore.Mvc;

namespace WebSocketApp.Controllers
{
    public class ChatController : Controller
    {     
       public IActionResult Index()
       {
         return View();
       }
    }
}