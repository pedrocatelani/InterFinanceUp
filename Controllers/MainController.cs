using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class MainController : Controller {
    private readonly DataBaseContext context;
    public MainController(DataBaseContext context) {
        this.context = context;
    }
    public ActionResult DashBoard() {
        return View();
    }
}