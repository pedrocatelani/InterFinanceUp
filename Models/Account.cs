using System.Data.SqlTypes;

public class Account {
    public Guid UserId { get; set; }
    public DateTime Mouth { get; set; }
    public float? Salary  { get; set; }
    public float? Returns { get; set; }
    public float? OtherEarnings { get; set; }
    public float? FoodExpense { get; set; }
    public float? ExpenseTransport { get; set; }
    public float? HousingExpense { get; set; }
    public float? HealthEducationExpenses { get; set; }
    public float? Investments {get; set; }
    public float? Taxes { get; set; }
    public float? LeisureExpenses { get; set; }
    public float? OtherExpenses {get; set; }
 }