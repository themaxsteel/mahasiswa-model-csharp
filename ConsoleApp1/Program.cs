// See https://aka.ms/new-console-template for more information


namespace ConsoleApp1
{
    class Program
    {
        private static List<Mahasiswa> mahasiswas = new List<Mahasiswa>();

        static void Main(string[] args)
        {
            mahasiswas.Add(new Mahasiswa( "220030400", "Turbowisesa", "Br. Banda", "Sistem Informasi")); 
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
                    backToMenu();
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

        static void mahasiswaList()
        {
            Console.Clear();
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
                Console.WriteLine($" {i+1}\t| {mahasiswas[i].name}\t\t| {mahasiswas[i].nim}\t| {mahasiswas[i].prodi}\t| {mahasiswas[i].address}\t|");
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

            mahasiswas.Add(new Mahasiswa(nim, name, address, prodi));
            divider();
            Console.WriteLine("Berhasil menambahkan data mahasiswa baru");
            backToMenu();
        }

        static void editMahasiswa(bool error = false, int id=0)
        {
            mahasiswaList();
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
            else if (mahasiswas.Count >= id)
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

                mahasiswas[id - 1] = new Mahasiswa(nim, name, address, prodi);
                divider();
                Console.WriteLine("Berhasil mengubah data mahasiswa");
                backToMenu();   
            }
            else
            {
                editMahasiswa(true, id);
            }
            
        }

        static void deleteMahasiswa(bool error = false, int id = 0)
        {
            mahasiswaList();
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
            else if (mahasiswas.Count >= id)
            {
                mahasiswas.RemoveAt(id-1);
                divider();
                Console.WriteLine("Berhasil menghapus data mahasiswa");
                backToMenu();    
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

