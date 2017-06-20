using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace Repository.Data
{
    public class VerkiezingssoortSqlContext : IVerkiezingssoortSqlContext
    {
        public List<Verkiezingssoort> GetAll()
        {
            List<Verkiezingssoort> soorten = new List<Verkiezingssoort>();
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

                foreach(Partij p in partijen)
                {
                    foreach (Lid l in leden)
                    {
                        if (l.PartijId == p.Id)
                        {
                            p.Leden.Add(l);
                        }
                    }
                }

                string queryCoalitie = "SELECT * FROM Verkiezingssoort S INNER JOIN Verkiezingssoort_Partij SP ON S.VerkiezingssoortID = SP.VerkiezingssoortID INNER JOIN Partij P ON P.PartijID = SP.PartijID";
                using (SqlCommand cmd = new SqlCommand(queryCoalitie, Database.Conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            soorten.Add(CreateSoortFromReader(r, partijen));
                        }
                    }
                }
                return soorten;
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
        public Verkiezingssoort GetById(int id)
        {
            List<Lid> leden = new List<Lid>();
            List<Partij> partijen = new List<Partij>();

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
                            partijen.Add(CreatePartijFromReader(r, leden));
                        }
                    }
                }

                string queryCoalitie = "SELECT * FROM Verkiezingssoort S INNER JOIN Verkiezingssoort_Partij SP ON S.VerkiezingssoortID = SP.VerkiezingssoortID INNER JOIN Partij P ON P.PartijID = SP.PartijID WHERE S.VerkiezingssoortID = @id";
                using (SqlCommand cmd = new SqlCommand(queryCoalitie, Database.Conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        while (r.Read())
                        {
                            return CreateSoortFromReader(r, partijen);
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
        public bool New(Verkiezingssoort s)
        {
            try
            {
                Database.Conn.Open();
                string query = "INSERT INTO Verkiezingssoort (Naam, Zetels) VALUES (@naam, @zetels)";
                using (SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@naam", s.Naam);
                    cmd.Parameters.AddWithValue("@zetels", s.Zetels);
                    cmd.ExecuteNonQuery();
                }

                string queryVP = "INSERT INTO Verkiezingssoort_Partij (VerkiezingssoortID, PartijID) VALUES (@@IDENTITY, @partij)";
                using (SqlCommand cmd = new SqlCommand(queryVP, Database.Conn))
                {
                    foreach(Partij p in s.Partijen)
                    {
                        cmd.Parameters.AddWithValue("@partij", p.Id);
                        cmd.ExecuteNonQuery();
                    }
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

        private Verkiezingssoort CreateSoortFromReader(SqlDataReader r, List<Partij> partijen)
        {
            List<Partij> soortPartijen = new List<Partij>();
            foreach(Partij p in partijen)
            {
                if(p.Id == Convert.ToInt32(r["PartijID"]))
                {
                    soortPartijen.Add(p);
                }
            }
            return new Verkiezingssoort(Convert.ToInt32(r["VerkiezingssoortID"]), r["Naam"].ToString(),
                                        Convert.ToInt32(r["Zetels"]), soortPartijen);
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
