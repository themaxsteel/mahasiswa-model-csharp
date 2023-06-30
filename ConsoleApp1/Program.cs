// See https://aka.ms/new-console-template for more information


using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        private static List<Mahasiswa> mahasiswas = new List<Mahasiswa>();
        private static HttpClient _httpClient = new HttpClient();

        static void Main(string[] args)
        {
            _httpClient.BaseAddress = new Uri("https://62959458810c00c1cb635575.mockapi.io/api/");
            // Console.WriteLine(response.Result); 
            // Console.ReadLine();
            menu();
        }

        static void menu(bool error = false)
        {
            Console.WriteLine("Menu Kampus GuestPro");
            divider();
            Console.WriteLine("1. Lihat Data Mahasiswa");
            Console.WriteLine("2. Tambahkan Data Mahasiswa");
            Console.WriteLine("3. Edit Data Mahasiswa");
            Console.WriteLine("4. Hapus Data Mahasiswa");
            divider();
            if (error)
            {   Console.WriteLine("Tolong input angka dari 1-4");
            }
            Console.Write("Pilih menu : ");

            int result;
            try
            {
                result = int.Parse(Console.ReadLine() ?? "0");
            }
            catch (Exception e)
            {
                result = 0;
            }
            
            switch (result)
            {
                case 0:
                    Console.Clear();
                    menu(true);
                    break;
                case 1:
                    mahasiswaList();
                    break;
                case 2:
                    addMahasiswa();
                    break;
                case 3:
                    editMahasiswa();
                    break;
                case 4:
                    deleteMahasiswa();
                    break;
            }
        }

        static void  mahasiswaList(bool showOnly = false)
        {
            Console.Clear();
            Task<List<Mahasiswa>?> response = _httpClient.GetFromJsonAsync<List<Mahasiswa>>("mahasiswa");
            mahasiswas = response.Result;
            if (mahasiswas.Count == 0)
            {
                Console.WriteLine("Data mahasiswa  kosong");
                return;
            }
            Console.WriteLine("Data Mahasiswa Kampus GuestPro");
            divider();
            Console.WriteLine("ID\t| Nama\t\t\t| NIM\t\t| Prodi\t\t\t| Alamat\t|");
            for (int i=0;i<mahasiswas.Count;i++)
            {
                Console.WriteLine($" {mahasiswas[i].Id}\t| {mahasiswas[i].Name}\t\t| {mahasiswas[i].Nim}   \t| {mahasiswas[i].Prodi}\t| {mahasiswas[i].Address}\t|");
            }

            if (showOnly == false)
            {
                backToMenu();

            }
        }

        static void addMahasiswa()
        {
            Console.Clear();
            Console.WriteLine("Tambah Data Mahasiswa Baru");
            divider();
            Console.Write("Nama: ");
            String name = Console.ReadLine();
            Console.Write("NIM: ");
            String nim = Console.ReadLine();
            Console.Write("Prodi: ");
            String prodi = Console.ReadLine();
            Console.Write("Alamat: ");
            String address = Console.ReadLine();

            string data = JsonConvert.SerializeObject(new Mahasiswa(nim, name, address, prodi));
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            // Console.WriteLine(data);
            var response = _httpClient.PostAsync("mahasiswa", content);
            divider();
            
            Console.WriteLine($"Berhasil menambahkan data mahasiswa baru: ");
            backToMenu();
        }

        static void editMahasiswa(bool error = false, int id=0)
        {
            mahasiswaList(true);
            divider();
            if (mahasiswas.Count == 0)
            {
                backToMenu();
            }
            if (error)
            {
                Console.WriteLine($"ID {id} tidak dapat ditemukan");
            }
            Console.WriteLine("Ketik 0 untuk kembali ke menu");
            Console.Write("Pilih id yang ingin diubah: ");
            id = int.Parse(Console.ReadLine());
            if (id == 0)
            {
                Console.Clear();
                menu();
            }
            else if (mahasiswas.Find(x => x.Id == id) != null)
            {
                divider();
                Console.Write("Nama: ");
                String name = Console.ReadLine();
                Console.Write("NIM: ");
                String nim = Console.ReadLine();
                Console.Write("Prodi: ");
                String prodi = Console.ReadLine();
                Console.Write("Alamat: ");
                String address = Console.ReadLine();

                try
                {
                    string data = JsonConvert.SerializeObject(new Mahasiswa(nim, name, address, prodi));
                    var content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = _httpClient.PutAsync($"mahasiswa/{id}", content);
                    divider();
                    Console.WriteLine("Berhasil mengubah data mahasiswa");
                    backToMenu();
                }
                catch (Exception e)
                {
                    divider();
                    Console.WriteLine($"Gagal mengubah data mahasiswa: {e}");
                    backToMenu();
                }
            }
            else
            {
                editMahasiswa(true, id);
            }
            
        }

        static void deleteMahasiswa(bool error = false, int id = 0)
        {
            mahasiswaList(true);
            divider();
            if (mahasiswas.Count == 0)
            {
                backToMenu();
            }
            if (error)
            {
                Console.WriteLine($"ID {id} tidak dapat ditemukan");
            }
            Console.WriteLine("Ketik 0 untuk kembali ke menu");
            Console.Write("Pilih id yang ingin dihapus: ");
            id = int.Parse(Console.ReadLine() ?? "0");
            if (id == 0)
            {
                Console.Clear();
                menu();
            }
            else if (mahasiswas.Find(x => x.Id == id) != null)
            {
                try
                {
                    var response =  _httpClient.DeleteAsync($"mahasiswa/{id}");

                    divider();
                    Console.WriteLine("Berhasil menghapus data mahasiswa");
                    backToMenu();
                }
                catch (Exception e)
                {
                    divider();
                    Console.WriteLine($"Gagal menghapus data mahasiswa: {e.Message}");
                    backToMenu();
                }
                    
            }
            else
            {
                deleteMahasiswa(true, id);
            }
            
        }

        static void backToMenu()
        {
            Console.Write("Kembali ke menu? (y/n): ");
            string result = Console.ReadLine();
            if (result is "y" or "Y")
            {
                Console.Clear();
                menu();
            }
        }
        
        static void divider()
        {
            Console.WriteLine("============================================================================");
        }
        
        
    }
}

