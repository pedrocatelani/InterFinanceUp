using System.Globalization;
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
    //Criação do agrupamento do balanço baseado no mês e no ano (Get)
    [HttpGet]
    public ActionResult Balance(){
        return View();
    }
    //Criação do agrupamento do balanço baseado no mês e no ano (Get)
    [HttpPost]
    public ActionResult Balance(Account account, string month){
        account.AccountId = Guid.NewGuid();
        account.UserId = Guid.Parse(HttpContext.Session.GetString("UserId"));
        account.Month = month;
        _context.Accounts.Add(account);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Delete(Guid id){
        var account = _context.Accounts.Single(x => x.AccountId == id);
        _context.Remove(account);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Transactions(Guid id){
        var account = _context.Accounts.SingleOrDefault(x => x.AccountId == id);
        return View(account);
    }
    public ActionResult Transactions(Guid id, string category, string newValue){
        float value = float.Parse(newValue, CultureInfo.InvariantCulture);
        var account = _context.Accounts.Single(x => x.AccountId == id);
        switch (category){
            case "Salary":
                account.Salary += value;
                break;
            case "Returns":
                account.Returns += value;
                break;
            case "OtherEarnings":
                account.OtherEarnings += value;
                break;
            case "FoodExpense":
                account.FoodExpense += value;
                break;
            case "ExpenseTransport":
                account.ExpenseTransport += value;
                break;
            case "HousingExpense":
                account.HousingExpense += value;
                break;
            case "HealthEducationExpenses":
                account.HealthEducationExpenses += value;
                break;
            case "Investments":
                account.Investments += value;
                break;
            case "Taxes":
                account.Taxes += value;
                break;
            case "LeisureExpenses":
                account.LeisureExpenses += value;
                break;
            case "OtherExpenses":
                account.OtherExpenses += value;
                break;
        }
        _context.SaveChanges();
        return RedirectToAction("Transactions");
    }
}