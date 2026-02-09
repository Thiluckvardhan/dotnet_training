using System;
using NUnit.Framework;

public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative");

        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive");

        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds");

        Balance -= amount;
    }
}

[TestFixture]
public class BankAccountTests
{
    private BankAccount account;

    [SetUp]
    public void Setup()
    {
        account = new BankAccount(1000);
    }

    [Test]
    public void Deposit_ValidAmount_IncreasesBalance()
    {
        account.Deposit(500);
        Assert.That(account.Balance, Is.EqualTo(1500));
    }

    [Test]
    public void Deposit_NegativeAmount_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => account.Deposit(-100));
    }

    [Test]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        account.Withdraw(300);
        Assert.That(account.Balance, Is.EqualTo(700));
    }

    [Test]
    public void Withdraw_InsufficientFunds_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(1500));
    }

    [Test]
    public void Withdraw_NegativeAmount_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => account.Withdraw(-200));
    }
}
