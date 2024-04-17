using System;

public class cardHolder
{
    private string cardNum;
    private int pin;
    private string fName;
    private string lName;
    private double balance;

    public cardHolder(string cardNum, int pin, string fName, string lName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.fName = fName;
        this.lName = lName;
        this.balance = balance;
    }

    public cardHolder() { }

    public string getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public string getFName()
    {
        return fName;
    }
    public string getLName()
    {
        return lName;
    }
    public double getBalance()
    {
        return balance;
    }
    public void setCardNum(string cardNum)
    {
        this.cardNum = cardNum;
    }
    public void setPin(int pin)
    {
        this.pin = pin;
    }
    public void setFName(string fName)
    {
        this.fName = fName;
    }
    public void setLName(string lName)
    {
        this.lName = lName;
    }
    public void setBalance(double balance)
    {
        this.balance = balance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options: ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit?: ");
            double deposit = -1;
            while (deposit <= 0)
            {
                try
                {
                    deposit = double.Parse(Console.ReadLine());
                    if (deposit <= 0)
                    {
                        deposit = -1;
                        throw new Exception();
                    }
                    currentUser.setBalance(currentUser.getBalance() + deposit);
                    Console.WriteLine("You've entered ${0}.\tYour balance is now ${1}.", deposit, currentUser.getBalance());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter a valid amount!");
                }
            }
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw?: ");
            double  withdraw = -1;
            while (withdraw <= 0)
            {
                try
                {
                    withdraw = double.Parse(Console.ReadLine());
                    // checks if withdrawal amount is valid
                    if (withdraw <= 0 || withdraw > currentUser.getBalance())
                    {
                        withdraw = -1;
                        throw new Exception();
                    }
                    currentUser.setBalance(currentUser.getBalance() - withdraw);
                    Console.WriteLine("You've withdrwan ${0}.\tYour balance is now ${1}.", withdraw, currentUser.getBalance());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter a valid amount!");
                }
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance: {0}", currentUser.getBalance());
        }

        List<cardHolder> users = new List<cardHolder>();
        users.Add(new cardHolder("1111", 4455, "Jeb", "Battler", 250));
        users.Add(new cardHolder("1234", 1298, "Marty", "Patton", 100000));
        users.Add(new cardHolder("0987", 8369, "Gatler", "Nufty", 75.68));
        users.Add(new cardHolder("2468", 4444, "Meiss", "Schumann", 1000));

        Boolean run = true;
        int userChoice = -1;

        // Console.WriteLine("Welcome to C# Bank ATM!\nPlease insert your debit card: ");
        string debitCardNum = "";
        int inputPIN=0;
        cardHolder currUser = new cardHolder(); ;

        while (true)
        {
            Console.WriteLine("Welcome to C# Bank ATM!");

            // gets user from credit card num
            while (true)
            {
                try
                {
                    Console.WriteLine("Please insert your debit card number: ");
                    debitCardNum = Console.ReadLine();
                    currUser = users.FirstOrDefault(a => a.getNum() == debitCardNum);
                    if (currUser != null) {
                        break;
                    }
                    Console.WriteLine("Unrecognised card. Try again: ");
                }
                catch (Exception e)
                {
                }
            }

            // loops until correct PIN or exit code
            Console.WriteLine("Please enter PIN (To exit, enter 0): ");
            while (true)
            {
                try
                {
                    inputPIN = int.Parse(Console.ReadLine());
                    // exits current user
                    if (inputPIN == 0) { 
                        run = false;
                        Console.WriteLine();
                        break; }
                    if (inputPIN != currUser.getPin())
                    {
                        Console.WriteLine("Incorrect PIN. Retry:");
                    } 
                    else
                    {
                        break;
                    }
                } catch (Exception e){}
            }
            
            while (run)
            {
                try
                {
                    printOptions();
                    userChoice = int.Parse(Console.ReadLine());
                    switch (userChoice)
                    {
                        case 1:
                            deposit(currUser);
                            break;
                        case 2:
                            withdraw(currUser);
                            break;
                        case 3:
                            balance(currUser);
                            break;
                        case 4:
                            Console.WriteLine("Thank you for choosing C# Bank!\n");
                            run = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter valid choice... (1-4)");
                }
            }
            run = true;
        }
    }
}