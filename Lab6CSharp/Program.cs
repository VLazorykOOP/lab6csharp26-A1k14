using System;
using System.Collections;
using System.Collections.Generic;

//перше завдання
public interface IBaseInterface {
    void Show();
}

public interface IInfoInterface {
    string GetInfo();
}

public class Detail : IBaseInterface, IInfoInterface, IComparable {
    public string Name { get; set; }
    public Detail(string name) => Name = name;
    public void Show() => Console.WriteLine($"Деталь: {Name}");
    public string GetInfo() => $"Інфо про деталь {Name}";
    public int CompareTo(object? obj) => Name.CompareTo((obj as Detail)?.Name);
    public void SpecialDetailMethod() => Console.WriteLine("Особливий метод деталі");
}

public class Mechanism : IBaseInterface, IInfoInterface {
    public string Name { get; set; }
    public Mechanism(string name) => Name = name;
    public void Show() => Console.WriteLine($"Механізм: {Name}");
    public string GetInfo() => $"Інфо про механізм {Name}";
    public void SpecialMechanismMethod() => Console.WriteLine("Особливий метод механізму");
}

public class Product : IBaseInterface, IInfoInterface {
    public string Name { get; set; }
    public Product(string name) => Name = name;
    public void Show() => Console.WriteLine($"Виріб: {Name}");
    public string GetInfo() => $"Інфо про виріб {Name}";
}

public class AssemblyUnit : IBaseInterface, IInfoInterface {
    public string Name { get; set; }
    public AssemblyUnit(string name) => Name = name;
    public void Show() => Console.WriteLine($"Вузол: {Name}");
    public string GetInfo() => $"Інфо про вузол {Name}";
}
// перше закінчили

//друге завдання
public abstract class Client {
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Client(string name, DateTime date) {
        Name = name;
        Date = date;
    }
    public abstract void Show();
    public bool IsMatch(DateTime date) => Date.Date == date.Date;
}

public class Depositor : Client {
    public double Amount { get; set; }
    public double Interest { get; set; }
    public Depositor(string name, DateTime date, double amount, double interest) : base(name, date) {
        Amount = amount;
        Interest = interest;
    }
    public override void Show() => Console.WriteLine($"Вкладник: {Name}, Дата: {Date.ToShortDateString()}, Сума: {Amount}, Відсоток: {Interest}");
}

public class Creditor : Client {
    public double Loan { get; set; }
    public double Interest { get; set; }
    public double Balance { get; set; }
    public Creditor(string name, DateTime date, double loan, double interest, double balance) : base(name, date) {
        Loan = loan;
        Interest = interest;
        Balance = balance;
    }
    public override void Show() => Console.WriteLine($"Кредитор: {Name}, Дата: {Date.ToShortDateString()}, Кредит: {Loan}, Залишок: {Balance}");
}

public class Organization : Client {
    public string AccountNumber { get; set; }
    public double Balance { get; set; }
    public Organization(string name, DateTime date, string acc, double balance) : base(name, date) {
        AccountNumber = acc;
        Balance = balance;
    }
    public override void Show() => Console.WriteLine($"Організація: {Name}, Дата: {Date.ToShortDateString()}, Рахунок: {AccountNumber}, Баланс: {Balance}");
}
// друге закінчили

//третє завдання
public class MyCustomException : Exception {
    public MyCustomException(string message) : base(message) { }
}
// третє закінчили

//четверте завдання
public class Triangle {
    public int A { get; set; }
    public int B { get; set; }
    public Triangle(int a, int b) { A = a; B = b; }
}

public class TriangleCollection : IEnumerable {
    private Triangle[] items;
    public TriangleCollection(Triangle[] array) => items = array;
    public IEnumerator GetEnumerator() => items.GetEnumerator();
}
// четверте закінчили

class Program {
    static void Main() {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //перше завдання
        Console.WriteLine("--- Завдання 1 ---");
        IBaseInterface[] interfaces = new IBaseInterface[] {
            new Detail("Болт"),
            new Mechanism("Мотор"),
            new Product("Верстат"),
            new AssemblyUnit("Карбюратор")
        };

        foreach (var item in interfaces) {
            item.Show();
            if (item is IInfoInterface info) Console.WriteLine(info.GetInfo());
            
            // type pattern
            if (item is Detail d) d.SpecialDetailMethod();
            if (item is Mechanism m) m.SpecialMechanismMethod();
        }
        // перше закінчили

        //друге завдання
        Console.WriteLine("\n--- Завдання 2 ---");
        Client[] clients = new Client[] {
            new Depositor("Іванов", new DateTime(2023, 5, 10), 1000, 5),
            new Creditor("Петров", new DateTime(2023, 6, 15), 5000, 12, 3000),
            new Organization("Фірма А", new DateTime(2023, 5, 10), "12345", 10000)
        };

        foreach (var client in clients) client.Show();

        DateTime searchDate = new DateTime(2023, 5, 10);
        Console.WriteLine($"\nПошук за датою {searchDate.ToShortDateString()}:");
        foreach (var client in clients) {
            if (client.IsMatch(searchDate)) client.Show();
        }
        // друге закінчили

        //третє завдання
        Console.WriteLine("\n--- Завдання 3 ---");
        try {
            throw new MyCustomException("Це власний виняток!");
        } catch (MyCustomException ex) {
            Console.WriteLine($"Перехоплено: {ex.Message}");
        }

        try {
            throw new OutOfMemoryException("Це стандартний виняток OutOfMemory!");
        } catch (OutOfMemoryException ex) {
            Console.WriteLine($"Перехоплено: {ex.Message}");
        }
        // третє закінчили

        //четверте завдання
        Console.WriteLine("\n--- Завдання 4 ---");
        TriangleCollection triangles = new TriangleCollection(new Triangle[] {
            new Triangle(3, 4),
            new Triangle(5, 12)
        });

        foreach (Triangle t in triangles) {
            Console.WriteLine($"Трикутник: a={t.A}, b={t.B}");
        }
        // четверте закінчили
    }
}
