using System;

class Program
{
    static void Main()
    {
        IConfiguration configView1 = ConfigurationManager.Instance;
        ITaxConfig taxView1 = ConfigurationManager.Instance;

        DisplayConfiguration(configView1, taxView1);

        IConfiguration configView2 = ConfigurationManager.Instance;
        ITaxConfig taxView2 = ConfigurationManager.Instance;

        taxView2.UpdateTaxRate(18.0);

        Console.WriteLine("\nAfter Tax Update:");
        DisplayConfiguration(configView2, taxView2);

        Console.WriteLine("\nAre both instances the same?");
        Console.WriteLine(ReferenceEquals(configView1, configView2));
    }

    // Dependency Inversion: depends on abstractions only
    static void DisplayConfiguration(IConfiguration config, ITaxConfig tax)
    {
        Console.WriteLine($"Store Name: {config.StoreName}");
        Console.WriteLine($"Currency: {config.Currency}");
        Console.WriteLine($"Tax Rate: {tax.TaxRate}%");
    }
}