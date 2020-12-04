using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Praktinis
{
    class MySql
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=root;database=akademine_sistema");
        public Naudotojas naudotojas;
        public Studentas st;
        public void Prisijungti(string vardas, string slaptazodis)
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "select * from naudotojas" +
                    " where Vardas=@un and Pavarde=@p;";
                command.Parameters.AddWithValue("@un", vardas);
                command.Parameters.AddWithValue("@p", slaptazodis);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        naudotojas = new Naudotojas(Int32.Parse(reader["N_ID"].ToString()), reader["Vardas"].ToString(), reader["Pavarde"].ToString(), Int32.Parse(reader["NL_ID"].ToString()));
                    }
                }
                con.Close();
                if (naudotojas == null)
                {
                    throw new Exception("Neteisingi duomenys");
                }
            }
            catch
            {
                throw new Exception("Neteisingi duomenys");
            }
        }

        public List<string> temp1 = new List<string>();
        public List<string> temp2 = new List<string>();


        public List<string> temp3 = new List<string>();
        public List<string> temp4 = new List<string>();
        public void GaukPaskaitas(Studentas st)
        {
            try
            {

                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "select distinct d.Da_Pav,p.Pazymis from dalykas d join paskaitos p on  p.Da_ID=d.Da_ID " +
                "where p.S_ID = @id ";
                command.Parameters.AddWithValue("@id", st.SID);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    temp1.Add(reader["Da_Pav"].ToString());
                    temp2.Add(reader["Pazymis"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal void GautGrupes()
        {
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select DISTINCT g.G_Pav, d.Da_Pav from paskaitos p join studentas s on p.S_ID=s.S_ID join grupe g on g.G_ID=s.Grupe_ID join dalykas d on  d.Da_ID=p.Da_ID;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                temp1.Add(reader["G_Pav"].ToString());
                temp2.Add(reader["Da_Pav"].ToString());
            }
            con.Close();
        }

        public void GautDestytojus()
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "select Vardas,Pavarde,N_ID from naudotojas where NL_ID=2";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp1.Add(reader["Vardas"].ToString());
                        temp2.Add(reader["Pavarde"].ToString());
                        temp3.Add(reader["N_ID"].ToString());
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void SalintiDestytoja(string listViewSubItem)
        {
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Delete from naudotojas where N_ID=@id;" +
                " delete from destytojo_dalykas where N_ID=@id;";
            command.Parameters.AddWithValue("@id", listViewSubItem);
            command.ExecuteNonQuery();
            con.Close();
        }

        public void PridetiDestytoja(string text1, string text2)
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "insert into naudotojas(Vardas,Pavarde,NL_ID) values(@var,@pav,2) ; ";
                command.Parameters.AddWithValue("@var", text1);
                command.Parameters.AddWithValue("@pav", text2);

                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal void SalintiStudenta(string text)
        {
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "delete paskaitos, studentas from paskaitos inner join studentas on paskaitos.S_ID=studentas.S_ID where studentas.N_ID=@id; " +
                "Delete from naudotojas where N_ID=@id;" +
                " Delete from studentas where N_ID=@id; ";
            command.Parameters.AddWithValue("@id", text);
            command.ExecuteNonQuery();
            con.Close();
        }

        internal void PridetiStudenta(string text1, string text2)
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "insert into naudotojas(Vardas,Pavarde,NL_ID) values(@var,@pav,1);" +
                    "insert into studentas(N_ID) Select N_ID  from naudotojas n where n.Vardas =@var and n.Pavarde=@pav";
                command.Parameters.AddWithValue("@var", text1);
                command.Parameters.AddWithValue("@pav", text2);

                command.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal void PaskirtiPaskaitas(string text1, string text2)
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "insert into destytojo_dalykas select @id,Da_ID from dalykas where Da_Pav = @pav; ";
                command.Parameters.AddWithValue("@id", text1);
                command.Parameters.AddWithValue("@pav", text2);

                command.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void PildytiDestytojuDalykuLentele()
        {
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select n.Vardas,n.Pavarde,n.N_ID,d.Da_Pav,d.Da_ID from destytojo_dalykas dd join naudotojas n on n.N_ID=dd.De_ID join dalykas d on d.Da_ID=dd.Da_ID;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                temp1.Add(reader["Vardas"].ToString() + " " + reader["Pavarde"].ToString() + " " + reader["Da_Pav"].ToString());
                temp2.Add(reader["N_ID"].ToString());
                temp3.Add(reader["Da_ID"].ToString());
            }
            con.Close();
        }

        internal void PildytiStudentus()
        {
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select n.Vardas,n.Pavarde,g.G_Pav,s.S_ID from studentas s  join naudotojas n on n.N_ID = s.N_ID left join grupe g on g.G_ID = s.Grupe_ID ";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                temp1.Add(reader["Vardas"].ToString() + " " + reader["Pavarde"].ToString());
                temp2.Add(reader["G_Pav"].ToString());
                temp4.Add(reader["S_ID"].ToString());
            }
            con.Close();
        }

        internal void PaskirtiGrupe(string text, string text2)
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "Update studentas s join grupe g set s.Grupe_ID=g.G_ID where g.G_Pav=@pav and s.S_ID=@id;" +
                    "insert into paskaitos(S_ID,Da_ID) Select @id,p.Da_ID from paskaitos p join studentas s on p.S_ID=s.S_ID join grupe g on g.G_ID=s.Grupe_ID where g.G_Pav =@pav;";
                command.Parameters.AddWithValue("@pav", text);
                command.Parameters.AddWithValue("@id", text2);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }


        internal void DuotiGrupeiPaskaitas(string text1, string text2)
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "insert into paskaitos (S_ID,Da_ID)  select s.S_ID,d.Da_ID from studentas s join grupe g on s.Grupe_ID=g.G_ID join dalykas d where g.G_Pav=@gpav and d.Da_Pav=@dpav ";
                command.Parameters.AddWithValue("@gpav", text1);
                command.Parameters.AddWithValue("@dpav", text2);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        internal void SalintiGrupesPaskaitas(string text1, string text2)
        {
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SET SQL_SAFE_UPDATES = 0; " +
            " delete p from paskaitos p inner join dalykas d on d.Da_ID = p.Da_ID inner join studentas s on s.S_ID = p.S_ID inner join grupe g on g.G_ID = s.Grupe_ID where d.Da_Pav =@dapav and g.G_Pav =@gpav; " +
            "SET SQL_SAFE_UPDATES = 1; ";
            command.Parameters.AddWithValue("@dapav",text2);
            command.Parameters.AddWithValue("@gpav",text1);

            command.ExecuteNonQuery();
            con.Close();
        }

        internal void PasalintiGrupe(string text)
        {
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Update studentas set Grupe_ID=null where S_ID=@id;" +
                "delete from paskaitos where S_ID=@id ";
            command.Parameters.AddWithValue("@id", text);
            command.ExecuteNonQuery();
            con.Close();
        }

        internal void PaskirtPaskaitas(string text1, string text2)
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "insert into paskaitos(S_ID,Da_ID) select @sid,d.Da_ID from dalykas d where d.Da_Pav=@pav ;";
                command.Parameters.AddWithValue("@pav", text1);
                command.Parameters.AddWithValue("@sid", text2);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }

        internal void AtleistiDestytoja(string text1, string text2)
        {
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "delete from destytojo_dalykas where Da_ID=@daid and De_ID=@deid;";
            command.Parameters.AddWithValue("@daid", text2);
            command.Parameters.AddWithValue("@deid", text1);
            command.ExecuteNonQuery();
            con.Close();
        }

        public void StudentoDuom(Naudotojas nd)
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "select * from studentas s join grupe g on g.G_ID=s.Grupe_ID where s.N_ID=@id";
                command.Parameters.AddWithValue("@id", nd.ID);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        st = new Studentas(nd.ID, nd.vardas, nd.pavarde, nd.lygis, Int32.Parse(reader["S_ID"].ToString()), Int32.Parse(reader["Grupe_ID"].ToString()), reader["G_Pav"].ToString());
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<string> GautiGrupe()
        {
            try
            {
                List<string> list = new List<string>();
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "select G_Pav from grupe";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["G_Pav"].ToString());
                    }
                }

                con.Close();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<string> GautiGrupeDestytojo(Naudotojas nd)
        {
            try
            {
                List<string> list = new List<string>();
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "select DISTINCT g.G_Pav from grupe g join studentas s on s.Grupe_ID=g.G_ID join paskaitos p on p.S_ID=s.S_ID join destytojo_dalykas dd on p.Da_ID=dd.Da_ID where dd.De_ID=@id";
                command.Parameters.AddWithValue("@id", nd.ID);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["G_Pav"].ToString());
                    }
                }

                con.Close();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<string> GautDalyka(Naudotojas nd)
        {
            try
            {
                List<string> list = new List<string>();
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "select DISTINCT d.Da_Pav from dalykas d join destytojo_dalykas dd on dd.Da_ID=d.Da_ID where dd.De_ID=@id";
                command.Parameters.AddWithValue("@id", nd.ID);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["Da_Pav"].ToString());
                    }
                }

                con.Close();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void GautiStudentus(string grupe, string dalykas)
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "select DISTINCT p.Pazymis,n.Vardas,n.Pavarde from paskaitos p " +
                    "join studentas s " +
                    "join naudotojas n " +
                    "on n.N_ID=s.N_ID " +
                    "on p.S_ID= s.S_ID " +
                    "join dalykas d " +
                    "on d.Da_ID=p.Da_ID " +
                    "join grupe g " +
                    "on g.G_ID=s.Grupe_ID " +
                    "where d.Da_Pav=@pav and g.G_Pav=@gpav;";
                command.Parameters.AddWithValue("@pav", dalykas);
                command.Parameters.AddWithValue("@gpav", grupe);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp1.Add(reader["Vardas"].ToString());
                        temp2.Add(reader["Pavarde"].ToString());
                        temp3.Add(reader["Pazymis"].ToString());
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void KeistiPazymi(string vardas, string pavarde, string dalykas, int paz)
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "Update paskaitos p"
                    + " join studentas s on s.S_ID = p.S_ID"
                    + " join naudotojas n on n.N_ID = s.N_ID"
                    + " join dalykas d on d.Da_ID = p.Da_ID"
                    + " set p.Pazymis=@pa"
                    + " where n.Vardas=@var and n.Pavarde=@pav and d.Da_Pav=@da;";
                command.Parameters.AddWithValue("@pa", paz);
                command.Parameters.AddWithValue("@var", vardas);
                command.Parameters.AddWithValue("@pav", pavarde);
                command.Parameters.AddWithValue("@da", dalykas);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                throw new Exception("Error");
            }
        }

        public void PridetiGrupe(string pav)
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "insert into grupe(G_Pav) select @pav from dual where not exists( select 1 from grupe where G_Pav=@pav ) Limit 1; ";
                command.Parameters.AddWithValue("@pav", pav);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GautStudentus()
        {
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "select Vardas,Pavarde,N_ID from naudotojas where NL_ID=1";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp1.Add(reader["Vardas"].ToString());
                        temp2.Add(reader["Pavarde"].ToString());
                        temp3.Add(reader["N_ID"].ToString());
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void IstrintiGrupe(string pav)
        {
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "update studentas s join grupe g on s.Grupe_ID=g.G_ID set s.Grupe_ID=null where g.G_Pav=@pav;" +
                " Delete from grupe where G_Pav=@pav;";
            command.Parameters.AddWithValue("@pav", pav);
            command.ExecuteNonQuery();
            con.Close();
        }

        public List<string> GautPaskaita()
        {
            try
            {
                List<string> list = new List<string>();
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "select Da_Pav from dalykas";

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["Da_Pav"].ToString());
                    }
                }

                con.Close();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void IstrintiDalyka(string text)
        {
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "delete dalykas,paskaitos from paskaitos inner join dalykas on paskaitos.Da_ID=dalykas.Da_ID where dalykas.Da_Pav=@pav; " +
                "delete dalykas,destytojo_dalykas from destytojo_dalykas inner join dalykas on dalykas.Da_ID=destytojo_dalykas.Da_ID where dalykas.Da_Pav=@pav; " +
                "Delete from dalykas where Da_Pav=@pav;";
            command.Parameters.AddWithValue("@pav", text);
            command.ExecuteNonQuery();
            con.Close();
        }

        public void PridetDalyka(string pav)
        {
            try
            { 
                con.Open();
                MySqlCommand command = con.CreateCommand();
              command.CommandText = "insert into dalykas(Da_Pav) select @pav from dual where not exists( select 1 from dalykas where Da_Pav=@pav ) Limit 1; ";
                command.Parameters.AddWithValue("@pav", pav);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
