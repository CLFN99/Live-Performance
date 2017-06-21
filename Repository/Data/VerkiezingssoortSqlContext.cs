using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using Repository.Logic;

namespace Repository.Data
{
    public class VerkiezingssoortSqlContext : IVerkiezingssoortSqlContext
    {
        private PartijRepository partijRepo = new PartijRepository(new PartijSqlContext());

        public List<Verkiezingssoort> GetAll()
        {
            List<Verkiezingssoort> soorten = new List<Verkiezingssoort>();
            List<Partij> partijen = partijRepo.GetAll();

            try
            {
                Database.Conn.Open();
                
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
            List<Partij> partijen = partijRepo.GetAll();

            try
            {
                Database.Conn.Open();
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

    }
}
