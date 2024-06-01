using Microsoft.AspNetCore.Mvc;

public class UserController: Controller {
    private readonly DataBaseContext context;
    public UserController(DataBaseContext context) {
        this.context = context;
    }
    [HttpGet]
    public ActionResult SignIn(){
        return View();
    }
    [HttpPost]
    public ActionResult SignIn(User user){
        user.UserId = Guid.NewGuid();
        context.Users.Add(user);
        context.SaveChanges();
        return RedirectToAction("Questions"); 
    }
    public ActionResult LogIn(){
        return View();
    }
    [HttpGet]
    public ActionResult Questions(){
        return View();
    }
    public ActionResult Questions(User user){
        context.Users.Add(user);
        context.SaveChanges();
        return RedirectToAction("DashBoard","Main");
    }
    public ActionResult Update(){
        return View();
    }
}