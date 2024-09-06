using Microsoft.Extensions.Configuration;

namespace Configuration;

public class csAppConfig
{
    public const string Appsettingfile = "appsettings.json";
    public const string UsersecretId = "b611a1d3-9a8e-4711-96dc-95252a346a60";

    #region Singleton design pattern
    private static csAppConfig _instance = null;
    private static IConfigurationRoot _configuration = null;
    #endregion

    #region Configuration data structures
    private static csConfAddress _address = new csConfAddress();
    private static csSecretKey _keys = new csSecretKey();
    #endregion


    private csAppConfig()
    {
        var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory());

        builder = builder.AddUserSecrets(UsersecretId, reloadOnChange: true);

        builder = builder.AddJsonFile(Appsettingfile, optional: true, reloadOnChange: true);
        _configuration = builder.Build();

        _configuration.Bind("Address", _address);
        _configuration.Bind("SuperSecretKeys", _keys);

    }

    public static IConfigurationRoot ConfigurationRoot
    {
        get
        {
            if (_instance == null)
            {
                _instance = new csAppConfig();
            }
            return _configuration;
        }
    }

    public static string Author => ConfigurationRoot["Author"];
    public static string Country => ConfigurationRoot["Country"];

    public static csConfAddress Address { 
        get
        {
            if (_instance == null)
            {
                _instance = new csAppConfig();
            }
            return _address;
        }} 
    public static csSecretKey SecretKeys { 
    get
    {
        if (_instance == null)
        {
            _instance = new csAppConfig();
        }
        return _keys;
    }} 
}

public class csConfAddress
{
    public string Street { get; set;}
    public int Zip { get; set;}
    public string City { get; set;}
}
public class csSecretKey
{
    public string EncryptionKey { get; set; }
    public int NrOfEncryptions { get; set; }
}
