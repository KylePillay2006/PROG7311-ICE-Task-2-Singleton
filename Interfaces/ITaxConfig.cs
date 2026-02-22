public interface ITaxConfig
{
    double TaxRate { get; }
    void UpdateTaxRate(double newRate);
}