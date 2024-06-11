using Microsoft.AspNetCore.Mvc;

public class UserController: Controller {
    private readonly DataBaseContext context;
    public UserController(DataBaseContext context) {
        this.context = context;
    }
    //SIGIN - Registro de usuário (Get)
    [HttpGet]
    public ActionResult SignIn(){
        return View();
    }
    //SIGIN - Registro de usuário (Post)
    [HttpPost]
    public ActionResult SignIn(User user){
        if(ModelState.IsValid){
            user.UserId = Guid.NewGuid();
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("LogIn");
        }
        return View(user);
    }
    //LOGIN - Autendificação de usuário (Get)
    [HttpGet]
    public ActionResult LogIn(){
        if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId"))) return RedirectToAction("DashBoard","Main");
        return View();
    }
    //LOGIN - Autendificação de usuário (Post)
    [HttpPost]
    public ActionResult LogIn(string email, string password){
        User? user = context.Users.SingleOrDefault(x => x.Email.ToUpper() == email.ToUpper()); 
        if(user != null){
            if(password == user.Password){
                HttpContext.Session.SetString("UserId", user.UserId.ToString());
                HttpContext.Session.SetString("UserName",user.Name);
                return RedirectToAction("DashBoard","Main");
            }
            return View("LogIn");
        }
        return View("LogIn");
    }
    public ActionResult Logout(){
        HttpContext.Session.Clear();
        return RedirectToAction("LogIn");
    }
    public ActionResult Profile(){
        List<User> users = context.Users.ToList();
        return View(users);
    }
    [HttpGet]
    public ActionResult Update(Guid id){
        var user = context.Users.SingleOrDefault(x => x.UserId == id);
        return View(user);
    }
    [HttpPost]
    public ActionResult Update(Guid id, User user){
        var _user = context.Users.Single(x => x.UserId == id);
        _user.Name = user.Name;
        _user.Email = user.Email;
        context.SaveChanges();
        return RedirectToAction("Profile");
    }
    public ActionResult Delete(Guid id){        
        var user = context.Users.Single(x => x.UserId == id);
        context.Users.Remove(user);
        context.SaveChanges();
        return RedirectToAction("Profile");
    }
}