public class LoanEnquiry
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Income { get; set; }
    public decimal RequestedLoan { get; set; }  //Maybe this should be put into a seperate model that holds user and includes the loan property
}