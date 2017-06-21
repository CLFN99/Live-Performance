using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace Repository.Data
{
    public class LidSqlContext : ILidSqlContext
    {
        public List<Lid> GetAll()
        {
            List<Lid> leden = new List<Lid>();
            try
            {
                Database.Conn.Open();
                string query = "SELECT * FROM Lid";
                using(SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    using(SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            leden.Add(CreateLidFromReader(r));
                        }
                    }
                }
                return leden;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                Database.Conn.Close();
            }
            
        }

        public Lid GetById(int id)
        {
            try
            {
                Database.Conn.Open();
                string query = "SELECT * FROM Lid WHERE LidID = @id";
                using (SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            return CreateLidFromReader(r);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                Database.Conn.Close();
            }
            return null;
        }

        public bool NewMember(Lid l)
        {
            try
            {
                Database.Conn.Open();
                string query = "INSERT INTO Lid(Naam, PartijID) VALUES (@Naam, @partijid) ";
                using (SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@Naam", l.Naam);
                    cmd.Parameters.AddWithValue("@PartijId", l.PartijId);
                    cmd.ExecuteNonQuery();
                }
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                Database.Conn.Close();
            }
        }
        public bool DeleteMember(Lid l)
        {
            try
            {
                Database.Conn.Open();
                string query = "DELETE FROM Lid WHERE LidID = @id";
                using (SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@id", l.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                Database.Conn.Close();
            }
        }

        private Lid CreateLidFromReader(SqlDataReader r)
        {
            return new Lid(Convert.ToInt32(r["LidID"]), r["Naam"].ToString(), Convert.ToInt32(r["PartijID"]));
        }
    }
}
