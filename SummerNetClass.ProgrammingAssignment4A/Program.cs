// Albert Tulo IV
// 6/19/2026
// CPSC 23000, Programming Assignment 4A

namespace SummerNetClass.ProgrammingAssignment4A;

internal class Program
{
    static void Main(string[] args)
    {
        Employee[] employees = [
            new SalaryWorker(123, "Martha", "Perez", 56785.59),
            new HourlyWorker(435, "Joe", "Smith", 42.5, 18.67),
            new CommissionWorker(356, "Anthony", "Mendez", 30563.56, 0.003, 57874.53),
            new PieceWorker(452, "Jimmy", "James", 0.50, 1201)
            ];

        Console.WriteLine("Employee Weekly Earnings");
        Console.WriteLine(new string('=', 75));

        Console.WriteLine($"{"Type",-18} {"ID",-8} {"First Name",-15} {"Last Name",-15} {"Weekly Pay",12}");
        Console.WriteLine(new string('-', 75));

        foreach(Employee employee in employees)
        {
            Console.WriteLine(employee.earnings());
        }

        Console.WriteLine();
        Console.WriteLine("Employee Full Data");
        Console.WriteLine(new string('=', 75));

        foreach(Employee employee in employees)
        {
            Console.WriteLine(employee.displayData());
        }
    }
}

public class Employee
{
    private int Id;
    private string FirstName;
    private string LastName;

    public Employee()
    {
        setData();
    }

    public Employee(int id, string firstName, string lastName)
    {
        setData(id, firstName, lastName);
    }

    public void setData()
    {
        this.Id = 0;
        this.FirstName = "No Name";
        this.LastName = "No Name";
    }

    public void setData(int id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public void setId(int id)
    {
        this.Id = id;
    }

    public void setFirstName(string firstName)
    {
        this.FirstName = firstName;
    }
    public void setLastName(string lastName)
    {
        this.LastName = lastName;
    }

    public int getId()
    {
        return Id;
    }

    public string getFirstName()
    {
        return FirstName;
    }

    public string getLastName()
    {
        return LastName;
    }

    public virtual string displayData()
    {
        return $"{Id,-8} {FirstName,-15} {LastName,-15}";
    }

    public virtual string earnings()
    {
        return $"{"Employee",-18} {Id,-8} {FirstName,-15} {LastName,-15} {0,12:C}";
    }
}

public class SalaryWorker : Employee
{
    private double Salary;

    public SalaryWorker() : base()
    {
        Salary = 0;
    }

    public SalaryWorker(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public void setData()
    {
        base.setData();
        Salary = 0;
    }

    public void setData(int id, string firstName, string lastName, double salary)
    {
        base.setData(id, firstName, lastName);
        this.Salary = salary;
    }

    public void setSalary(double salary)
    {
        this.Salary = salary;
    }

    public double getSalary()
    {
        return Salary;
    }

    public override string displayData()
    {
        return $"{base.displayData()} {"Salary:",-12} {Salary,12:C}";
    }

    public override string earnings()
    {
        double weeklyPay = Salary / 52;
        return $"{"Salary Worker",-18} {getId(),-8} {getFirstName(),-15} {getLastName(),-15} {weeklyPay,12:C}";
    }
}

public class HourlyWorker: Employee
{
    private double HoursWorked;
    private double PayRate;

    public HourlyWorker() : base()
    {
        HoursWorked = 0;
        PayRate = 0;
    }

    public HourlyWorker(int id, string firstName, string lastName, double hoursWorked, double payRate) : base(id, firstName, lastName)
    {
        this.HoursWorked = hoursWorked;
        this.PayRate = payRate;
    }

    public void setData()
    {
        base.setData();
        HoursWorked = 0;
        PayRate = 0;
    }

    public void setData(int id, string firstName, string lastName, double hoursWorked, double payRate)
    {
        base.setData(id, firstName, lastName);
        this.HoursWorked = hoursWorked;
        this.PayRate = payRate;
    }

    public void setHoursWorked(double hoursWorked)
    {
        this.HoursWorked = hoursWorked;
    }

    public void setPayRate(double payRate)
    {
        this.PayRate = payRate;
    }

    public double getHoursWorked()
    {
        return HoursWorked;
    }

    public double getPayRate()
    {
        return PayRate;
    }

    public override string displayData()
    {
        return $"{base.displayData()} {"Hours:",-8} {HoursWorked,8:F2} {"Rate:",-8} {PayRate,10:C}";
    }

    public override string earnings()
    {
        double weeklyPay;

        if(HoursWorked <= 40)
        {
            weeklyPay = HoursWorked * PayRate;
        }
        else
        {
            double regularPay = 40 * PayRate;
            double overTime = (HoursWorked - 40) * PayRate * 1.5;
            weeklyPay = regularPay + overTime;
        }

        return $"{"Hourly Worker",-18} {getId(),-8} {getFirstName(),-15} {getLastName(),-15} {weeklyPay,12:C}";
    }
}

public class CommissionWorker : Employee
{
    private double Salary;
    private double CommissionRate;
    private double Sales;

    public CommissionWorker() : base()
    {
        Salary = 0;
        CommissionRate = 0;
        Sales = 0;
    }

    public CommissionWorker(int id,string firstName, string lastName, double salary, double commissionRate, double sales) : base(id, firstName, lastName)
    {
        this.Salary = salary;
        this.CommissionRate = commissionRate;
        this.Sales = sales;
    }

    public void setData()
    {
        base.setData();
        Salary = 0;
        CommissionRate = 0;
        Sales = 0;
    }

    public void setData(int id, string firstName, string lastName, double salary, double commissionRate, double sales)
    {
        base.setData(id, firstName, lastName);
        this.Salary = salary;
        this.CommissionRate = commissionRate;
        this.Sales = sales;
    }

    public void setSalary(double salary)
    {
        this.Salary = salary;
    }

    public void setCommissionRate(double commissionRate)
    {
        this.CommissionRate = commissionRate;
    }

    public void setSales(double sales)
    {
        this.Sales = sales;
    }

    public double getSalary()
    {
        return Salary;
    }

    public double getCommissionRate()
    {
        return CommissionRate;
    }

    public double getSales()
    {
        return Sales;
    }

    public override string displayData()
    {
        return $"{base.displayData()} {"Salary", -12} {Salary,12:C} {"Rate:", -8} {CommissionRate,8:F3} {"Sales:", -8} {Sales,12:C}";
    }

    public override string earnings()
    {
        double weeklyPay = (Salary / 52) + (Sales * CommissionRate);
        return $"{"Commission Worker",-18} {getId(),-8} {getFirstName(),-15} {getLastName(),-15} {weeklyPay,12:C}";
    }
}

public class PieceWorker : Employee
{
    private double WagePerPiece;
    private int Quantity;

    public PieceWorker() : base()
    {
        WagePerPiece = 0;
        Quantity = 0;
    }

    public PieceWorker(int id, string firstName, string lastName, double wagePerPiece, int quantity) : base(id, firstName, lastName)
    {
        this.WagePerPiece = wagePerPiece;
        this.Quantity = quantity;
    }

    public void setData()
    {
        base.setData();
        WagePerPiece = 0;
        Quantity = 0;
    }

    public void setData(int id, string firstName, string lastName, double wagePerPiece, int quantity)
    {
        base.setData(id, firstName, lastName);
        this.WagePerPiece = wagePerPiece;
        this.Quantity = quantity;
    }

    public void setWagePerPiece(double wagePerPiece)
    {
        this.WagePerPiece = wagePerPiece;
    }

    public void setQuantity(int quantity)
    {
        this.Quantity = quantity;
    }

    public double getWagePerPiece()
    {
        return WagePerPiece;
    }

    public int getQuantity()
    {
        return Quantity;
    }

    public override string displayData()
    {
        return $"{base.displayData()} {"Wage:",-8} {WagePerPiece,8:C} {"Quantity:",-10} {Quantity,8}";
    }

    public override string earnings()
    {
        double weeklyPay = WagePerPiece * Quantity;

        return $"{"Piece Worker",-18} {getId(),-8} {getFirstName(),-15} {getLastName(),-15} {weeklyPay,12:C}";
    }
}