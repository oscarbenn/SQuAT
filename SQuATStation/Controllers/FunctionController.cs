using Microsoft.AspNetCore.Mvc;
namespace SQuATStation.Controllers;

public class FunctionController : Controller
{
    // GET : /Function
    public IActionResult Index()
    {
        return View();
    }

    public void Connect(string ProjectName, string Url, string AccessKey)
    {
        System.Console.WriteLine(ProjectName);
        System.Console.WriteLine(Url);
        System.Console.WriteLine(AccessKey);
    }
}