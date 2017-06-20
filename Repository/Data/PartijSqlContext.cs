using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace Repository.Data
{
    public class PartijSqlContext
    {
        public List<Partij> GetAll()
        {
            List<Lid> leden = new List<Lid>();
            List<Partij> partijen = new List<Partij>();

            try
            {
                Database.Conn.Open();
                string queryLid = "SELECT * FROM Lid";
                using (SqlCommand cmd = new SqlCommand(queryLid, Database.Conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            leden.Add(CreateLidFromReader(r));
                        }
                    }
                }

                string queryPartij = "SELECT * FROM Partij";
                using (SqlCommand cmd = new SqlCommand(queryPartij, Database.Conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            partijen.Add(CreatePartijFromReader(r, leden));
                        }
                    }
                }
                
                return partijen;
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

        public Partij GetById(int id)
        {
            List<Lid> leden = new List<Lid>();

            try
            {
                Database.Conn.Open();
                string queryLid = "SELECT * FROM Lid WHERE PartijID = @id";
                using (SqlCommand cmd = new SqlCommand(queryLid, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            leden.Add(CreateLidFromReader(r));
                        }
                    }
                }

                string queryPartij = "SELECT * FROM Partij WHERE PartijID = @id";
                using (SqlCommand cmd = new SqlCommand(queryPartij, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            return CreatePartijFromReader(r, leden);
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

        public bool Update(Partij p)
        {
            try
            {
                Database.Conn.Open();
                string query = "UPDATE Partij SET Afkorting = @afk, Naam = @naam, Zetels = @zetels, LijsttrekkerID = @lijsttrekkerid";
                using (SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@afk", p.Afkorting);
                    cmd.Parameters.AddWithValue("@naam", p.Naam);
                    cmd.Parameters.AddWithValue("@zetels", p.Zetels);
                    cmd.Parameters.AddWithValue("@lijsttrekkerid", p.LijsttrekkerId);
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

        public bool Delete(Partij p)
        {
            try
            {
                Database.Conn.Open();
                string query = "DELETE FROM Lid WHERE LidID = @id";
                using (SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@id", l.ID);
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

        private Partij CreatePartijFromReader(SqlDataReader r, List<Lid> leden)
        {
            return new Partij(Convert.ToInt32(r["PartijID"]), r["Afkorting"].ToString(), r["Naam"].ToString(),
                                Convert.ToInt32(r["Zetels"]), Convert.ToInt32(r["LijsttrekkerID"]), leden);
        }
    }
}
