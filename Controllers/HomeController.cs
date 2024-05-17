using Microsoft.AspNetCore.Mvc;

public class HomeController: Controller {
    public ActionResult Index() {
        return View();
    }
    public ActionResult SignIn(){
        return View();
    }
    public ActionResult LogIn(){
        return View();
    }
}