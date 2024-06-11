using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;

public class AccountController: Controller{
    private readonly DataBaseContext _context;
    public AccountController(DataBaseContext context){
        _context = context;
    }
    //Lista de balanços separadas por mês, baseado no Id do usuário
    public ActionResult Index(){
        //Agrupamento mensal dos balanços
        var UserId = Guid.Parse(HttpContext.Session.GetString("UserId"));
        List<Account> accounts = _context.Accounts.Where(x => x.UserId == UserId).ToList();
        return View(accounts);
    }
    [HttpGet]
    public ActionResult Balance(){
        return View();
    }
    public ActionResult Balance(Account account, string month){
        account.UserId = Guid.Parse(HttpContext.Session.GetString("UserId"));
        account.Month = month;
        _context.Accounts.Add(account);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Transactions(Guid id){
        var account = _context.Accounts.SingleOrDefault(x => x.UserId == id);
        return View(account);
    }
    public ActionResult Transactions(Guid id, string category, float newValue){
        var account = _context.Accounts.Single(x => x.UserId == id);
        switch (category){
            case "Salary":
                account.Salary += newValue;
                break;
            case "Returns":
                account.Returns += newValue;
                break;
            case "OtherEarnings":
                account.OtherEarnings += newValue;
                break;
            case "FoodExpense":
                account.FoodExpense += newValue;
                break;
            case "ExpenseTransport":
                account.ExpenseTransport += newValue;
                break;
            case "HousingExpense":
                account.HousingExpense += newValue;
                break;
            case "HealthEducationExpenses":
                account.HealthEducationExpenses += newValue;
                break;
            case "Investments":
                account.Investments += newValue;
                break;
            case "Taxes":
                account.Taxes += newValue;
                break;
            case "LeisureExpenses":
                account.LeisureExpenses += newValue;
                break;
            case "OtherExpenses":
                account.OtherExpenses += newValue;
                break;
        }
        _context.SaveChanges();
        return RedirectToAction("Transactions");
    }
}