using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class MainController : Controller {
    private readonly DataBaseContext _context;
    public MainController(DataBaseContext context) {
        _context = context;
    }
    public ActionResult DashBoard(string month, int year) {
        var UserId = Guid.Parse(HttpContext.Session.GetString("UserId"));
        var user = _context.Users.FirstOrDefault(x => x.UserId == UserId);
        ViewBag.Balance = user.Balance;
        var account  = _context.Accounts.Where(x => x.Month == month && x.Year == year && x.UserId == UserId).FirstOrDefault();
        if (account == null) {
            ViewBag.Message = "Not Found";
            ViewBag.Expenses = new List<ChartData>();
        }
        else{
            var expenses = new List<ChartData>
            {
                new ChartData { Category = "Food", Amount = account.FoodExpense },
                new ChartData { Category = "Transport", Amount = account.ExpenseTransport },
                new ChartData { Category = "Housing", Amount = account.HousingExpense },
                new ChartData { Category = "Health & Education", Amount = account.HealthEducationExpenses },
                new ChartData { Category = "Leisure", Amount = account.LeisureExpenses },
                new ChartData { Category = "Other", Amount = account.OtherExpenses }
            };
            ViewBag.Expenses = expenses;
            ViewBag.Message = null;
        }
        return View();
    }
    public ActionResult GetChartData(string month, int year){
        return RedirectToAction("DashBoard", new {month, year});
    }
}