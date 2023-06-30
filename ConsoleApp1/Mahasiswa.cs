using Newtonsoft.Json;

namespace ConsoleApp1;
public class Mahasiswa
{
    [JsonProperty("nim")]
    public string Nim { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("prodi")]
    public string Prodi { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }
    
    public Mahasiswa(string nim, string name, string address, string prodi)
    {
        this.Nim = nim;
        this.Name = name;
        this.Address = address;
        this.Prodi = prodi;
    }
}