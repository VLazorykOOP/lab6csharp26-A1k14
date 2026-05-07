using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab6CSharp {
    // Task 3.5
    public class BankException : Exception {
        public BankException(string msg) : base(msg) { }
    }
    // Task 3.5 end

    // Task 1.4
    public interface IProduct : IComparable<IProduct> {
        string Name { get; }
        void Show();
    }

    public class Part : IProduct { 
        public string Name { get; set; }
        public string Material = "Сталь";
        public Part(string n) => Name = n;
        public void Show() => Console.WriteLine($"[1.4] Деталь: {Name}, Матеріал: {Material}");
        public void SpecialPartMethod() => Console.WriteLine("-> Специфічний метод Деталі");
        public int CompareTo(IProduct? o) => Name.CompareTo(o?.Name);
    }

    public class Mechanism : IProduct { 
        public string Name { get; set; }
        public Mechanism(string n) => Name = n;
        public void Show() => Console.WriteLine($"[1.4] Механізм: {Name}");
        public void SpecialMechMethod() => Console.WriteLine("-> Специфічний метод Механізму");
        public int CompareTo(IProduct? o) => Name.CompareTo(o?.Name);
    }
    // Task 1.4 end

    // Task 4
    public class ProductCatalog : IEnumerable<IProduct> {
        private List<IProduct> list = new();
        public void Add(IProduct p) => list.Add(p);
        public IEnumerator<IProduct> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    // Task 4 end

    // Task 2.9
    public interface IClient {
        string Name { get; }
        DateTime Date { get; }
        void Show();
    }

    public class Depositor : IClient {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Depositor(string n, DateTime d) { Name = n; Date = d; }
        public void Show() => Console.WriteLine($"[2.9] Вкладник: {Name}, Дата: {Date:d}");
    }
    // Task 2.9 end

    class Program {
        static void Main() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Task 1.4
            ProductCatalog catalog = new() { new Mechanism("Редуктор"), new Part("Болт") };
            foreach (var item in catalog) {
                item.Show();
                if (item is Part p) p.SpecialPartMethod();
                if (item is Mechanism m) m.SpecialMechMethod();
            }
            // Task 1.4 end

            // Task 2.9
            IClient client = new Depositor("Сидоров", DateTime.Now);
            client.Show();
            // Task 2.9 end

            // Task 3.5
            try {
                Console.WriteLine("Спроба викликати BankException...");
                throw new BankException("Недостатньо коштів!");
            } catch (BankException ex) {
                Console.WriteLine($"Перехоплено: {ex.Message}");
            } catch (OutOfMemoryException) {
                Console.WriteLine("Перехоплено: OutOfMemoryException");
            }
            // Task 3.5 end

            Console.WriteLine("\nРобота завершена. Натисніть клавішу...");
            Console.ReadKey();
        }
    }
}
