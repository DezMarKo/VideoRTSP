public class CameraConfig
{
    public string Nome { get; set; }
    public string Ip { get; set; }
    public int Porta { get; set; }
    public string Utente { get; set; }
    public string PasswordCriptata { get; set; }
    public string PathFinale { get; set; }
    public bool Abilitata { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public string Password
    {
        get => Decrypt(PasswordCriptata);
        set => PasswordCriptata = Encrypt(value);
    }

    public string GetRtspUrl()
    {
        return $"rtsp://{Utente}:{Password}@{Ip}:{Porta}{PathFinale}";
    }

    private static string Encrypt(string plain)
    {
        if (string.IsNullOrEmpty(plain)) return "";
        var bytes = System.Text.Encoding.UTF8.GetBytes(plain);
        return Convert.ToBase64String(bytes);
    }

    private static string Decrypt(string encoded)
    {
        if (string.IsNullOrEmpty(encoded)) return "";
        try
        {
            var bytes = Convert.FromBase64String(encoded);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
        catch
        {
            return "";
        }
    }
}
