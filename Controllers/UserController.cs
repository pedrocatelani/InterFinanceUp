using Microsoft.AspNetCore.Mvc;

public class UserController: Controller {
    private readonly DataBaseContext _context;
    public UserController(DataBaseContext context) {
        _context = context;
    }
    //SIGIN - Registro de usuário (Get)
    [HttpGet]
    public ActionResult SignIn(){
        return View();
    }
    //SIGIN - Registro de usuário (Post)
    [HttpPost]
    public ActionResult SignIn(User user){
        var check = _context.Users.FirstOrDefault(x => x.Email == user.Email);
        if(check != null){
            ModelState.AddModelError("Email", "Esse email já está cadastrado");
        }
        if(string.IsNullOrEmpty(user.Password) || user.Password.Length < 6){
            ModelState.AddModelError("Password","A senha deve conter no mínimo 6 caracteres");
        }
        if(ModelState.IsValid){
            user.UserId = Guid.NewGuid();
            _context.Users.Add(user);
            _context.SaveChanges();
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
        User? user = _context.Users.SingleOrDefault(x => x.Email.ToUpper() == email.ToUpper()); 
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
    //LOGOUT - Finalização da sessão do usuário
    public ActionResult Logout(){
        HttpContext.Session.Clear();
        return RedirectToAction("LogIn");
    }
    //PROFILE - Mostra o perfil do usuário
    public ActionResult Profile(){
        var UserId = Guid.Parse(HttpContext.Session.GetString("UserId"));
        var user = _context.Users.SingleOrDefault(x => x.UserId == UserId); 
        return View(user);
    }
    //UPDATE - Chama a tela de edição com os dados do usuário já preenchidos
    [HttpGet]
    public ActionResult Update(Guid id){
        var user = _context.Users.SingleOrDefault(x => x.UserId == id);
        return View(user);
    }
    //UPDATE - Inserção dos novos dados para a tabela
    [HttpPost]
    public ActionResult Update(Guid id, User user){
        var _user = _context.Users.Single(x => x.UserId == id);
        _user.Name = user.Name;
        _user.Email = user.Email;
        _user.Password = user.Password;
        _user.Balance = user.Balance;
        _context.SaveChanges();
        return RedirectToAction("Profile");
    }
    public ActionResult Delete(Guid id){        
        var user = _context.Users.Single(x => x.UserId == id);
        HttpContext.Session.Clear();
        _context.Users.Remove(user);
        _context.SaveChanges();
        return RedirectToAction("LogIn");
    }
}