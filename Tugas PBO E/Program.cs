using Npgsql;
using System.Data;

namespace PBO_E
{
    class get_database
    {
        private static NpgsqlConnection conection()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=postgres;database=PBO_2047;");
        }
        public bool ExecuteQuery(out bool valid)

        {
            valid = true;
            try
            {

                NpgsqlConnection con = conection();
                con.Open();
                string sql = "select * from pengelola";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return valid;

            }
            catch (Exception)
            {
                valid = false;
                return valid;
            }

        }
    }
    class crud
    {
        private static NpgsqlConnection conn()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=postgres;database=PBO_2047;");
        }
        public bool insert(ref bool valid)
        {
            try
            {
                NpgsqlConnection con = conn();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into pengelola(id,nama,alamat) values ('1','Rizqi','Asembagus')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                valid = true;
                return valid;
            }
            catch (Exception)
            {
                return valid;
            }

        }

        public bool update(ref bool valid)
        {
            try
            {
                NpgsqlConnection con = conn();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update pengelola set nama = Rizqi, where id = '1' ", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                valid = true;
                return valid;
            }
            catch (Exception)
            {
                return valid;
            }

        }
        public bool Delete(ref bool valid)
        {
            try
            {
                NpgsqlConnection con = conn();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from pengelola where id = '1' ", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                valid = true;
                return valid;
            }
            catch (Exception)
            {
                return valid;
            }

        }
    }

    class program
    {

        static void Main(string[] args)
        {
            bool valid;
            bool validator = false;
            get_database dat = new get_database();
            crud op = new crud();
            if (dat.ExecuteQuery(out valid) == true)
            {
                Console.WriteLine("Berhasil Memuat Data");
            }
            else if (dat.ExecuteQuery(out valid) == false)
            {
                Console.WriteLine("Gagal Memuat Data");
            }
            if (op.insert(ref validator) == true)
            {
                Console.WriteLine("Data Berhasil Ditambahkan");
            }
            else if (op.insert(ref validator) == false)
            {
                Console.WriteLine("Gagal Menambahkan Data");
            }
            if (op.update(ref validator) == true)
            {
                Console.WriteLine("Data Berhasil Diubah");
            }
            else if (op.update(ref validator) == false)
            {
                Console.WriteLine("Gagal Mengubah Data");
            }
            if (op.Delete(ref validator) == true)
            {
                Console.WriteLine("Data Berhasil Dihapus");
            }
            else if (op.Delete(ref validator) == false)
            {
                Console.WriteLine("Gagal Menghapus Data");
            }
        }
    }
}