public sealed class ConfigurationManager : IConfiguration, ITaxConfig
{
    private static ConfigurationManager _instance;
    private static readonly object _lock = new object();

    public string StoreName { get; private set; }
    public string Currency { get; private set; }
    public double TaxRate { get; private set; }

    // SRP: Responsible only for configuration state
    private ConfigurationManager()
    {
        StoreName = "Gadget Galaxy";
        Currency = "ZAR";
        TaxRate = 15.0;
    }

    // Singleton access point
    public static ConfigurationManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationManager();
                }
                return _instance;
            }
        }
    }

    public void UpdateTaxRate(double newRate)
    {
        TaxRate = newRate;
    }
}