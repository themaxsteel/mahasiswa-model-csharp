using System.Globalization;

namespace ConsoleApp1;

public class Mahasiswa
{
    public string nim;
    public string name;
    public string address;
    public string prodi;

    public Mahasiswa(string nim, string name, string address, string prodi)
    {
        this.nim = nim;
        this.name = name;
        this.address = address;
        this.prodi = prodi;
    }
}