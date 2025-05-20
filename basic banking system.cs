using System.Data;
using System.Diagnostics.CodeAnalysis;
bool CreateAccount = false;
string Answer;
Console.WriteLine("would you like to create a new account?");
Answer = Console.ReadLine();
if (Answer.ToUpper() == "Y")
{
    Console.WriteLine("what kind of exam (standard or student)");
    Answer = Console.ReadLine();
    if (Answer.ToLower() == "standard")
    {
        Console.WriteLine("what is your opening balance");
        Account account = new Account(int.Parse(Console.ReadLine()));

    }
}
public class Account
{   private double _intrest,_balance;
    private int _id;
    private string _name;  
    public Account(double OpeningBalance)
    { 
        Random GenerateID = new Random();
         _id =GenerateID.Next(10000000,99999999);
        _balance = OpeningBalance;
    } // constructor
    public double SetIntrestRate(double rate)
    {
        rate = 1.05;
        return rate;
    }
    public int GetID() 
    {
        return _id;
    }
    public string GEtName() 
    {
        return _name; 
    }
    public double GetIntrestRate() 
    {
        return _intrest;
    }
    public double GetBalance() 
    { 
        return _balance; 
    }
    virtual public double GetAvailableFunds()
    {
        return _balance;
    }
    public void Deposit(double amount)
    {
        _balance += amount;
    }
    public void Withdraw(double amount)
    {
        if (GetAvailableFunds()- amount >= 0)
        {
            _balance -= amount;
            
        }else
        {
            throw new Exception();
        }
        
    }
}//base class
public class StudentAccount : Account
{   private double _overdraft;
    public StudentAccount(double OpeningBalance, double OverdraftLimit) : base(OpeningBalance)
    {
        _overdraft = OverdraftLimit;
    }//constructor
    public override double GetAvailableFunds()
    {
        return GetBalance() + _overdraft;
    }
    public double GetOverdraftLimit()
    {
        return _overdraft;
    }
    public bool OverDraftAllowed(double AnualSalary,int Age)
    {
        if ((Age < 30 && Age > 16) && AnualSalary < 20000)
        {
            return true;
        }
        else
            _overdraft = 0;
            return false;
        
            
    }
    public double SetOverdraftLimit(double limit ) 
    {
        _overdraft = limit;
        return _overdraft; 
    }
}// inheareted class