using System.Data.SqlTypes;

public class User{
    public Guid UserId { get; set;}
    public string Name { get; set;}
    public string Email { get; set;}
    public string Password { get; set;}
    public float Balance { get; set;}
    public string? Result { get; set;}

}