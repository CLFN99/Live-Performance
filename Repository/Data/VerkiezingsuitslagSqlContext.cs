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
    public class VerkiezingsuitslagSqlContext : IVerkiezingsuitslagSqlContext
    {

        private PartijRepository partijRepo = new PartijRepository(new PartijSqlContext());

        public List<Verkiezingsuitslag> GetAll()
        {
            List<Verkiezingsuitslag> uitslagen = new List<Verkiezingsuitslag>();
            List<Partij> partijen = partijRepo.GetAll();
            try
            {
                Database.Conn.Open();
                string query = "SELECT * FROM Verkiezingsuitslag VU INNER JOIN Verkiezingssoort VS ON VS.VerkiezingssoortID = VU.VerkiezingssoortID INNER JOIN Verkiezingsuitslag_Partij VP ON VP.VerkiezingsuitslagID = VU.VerkiezingsuitslagID INNER JOIN Partij P ON P.PartijID = VP.PartijID";
                using(SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    
                    using(SqlDataReader r = cmd.ExecuteReader())
                    {
                        
                        while (r.Read())
                        {
                            Verkiezingssoort soort = CreateSoortFromReader(r, partijen);
                            uitslagen.Add(CreateUitslagFromReader(r, partijen, soort));
                        }
                    }
                }
                return uitslagen;
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

        public Verkiezingsuitslag GetById(int id)
        {
            List<Partij> partijen = partijRepo.GetAll();
            try
            {
                Database.Conn.Open();
                string queryCoalitie = "SELECT * FROM Verkiezingsuitslag VU INNER JOIN Verkiezingssoort VS ON VS.VerkiezingssoortID = VU.VerkiezingssoortID INNER JOIN Verkiezingsuitslag_Partij VP ON VP.VerkiezingsuitslagID = VU.VerkiezingsuitslagID INNER JOIN Partij P ON P.PartijID = VP.PartijID WHERE VU.VerkiezingsuitslagID = @id";
                using (SqlCommand cmd = new SqlCommand(queryCoalitie, Database.Conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        
                        while (r.Read())
                        {
                            Verkiezingssoort soort = CreateSoortFromReader(r, partijen);
                            return CreateUitslagFromReader(r, partijen, soort);
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

        public bool New(Verkiezingsuitslag s)
        {
            try
            {
                Database.Conn.Open();
                string query = "INSERT INTO Verkiezingsuitslag (Naam, Datum, VerkiezingssoortID) VALUES (@naam, @datum, @soort)";
                using (SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@naam", s.Naam);
                    cmd.Parameters.AddWithValue("@datum", s.Datum);
                    cmd.Parameters.AddWithValue("@soort", s.Soort.Id);
                    cmd.ExecuteNonQuery();
                }

                string queryVP = "INSERT INTO Verkiezingsuitslag_Partij (VerkiezingsuitslagID, PartijID, Stemmen, Percentage, Zetels) VALUES (@@IDENTITY, @partij, @stemmen, @percentage, @zetels)";
                using (SqlCommand cmd = new SqlCommand(queryVP, Database.Conn))
                {
                    foreach (Partij p in s.Partijen)
                    {
                        cmd.Parameters.AddWithValue("@partij", p.Id);
                        cmd.Parameters.AddWithValue("@stemmen", p.Stemmen);
                        cmd.Parameters.AddWithValue("@percentage", p.Percentage);
                        cmd.Parameters.AddWithValue("@zetels", p.NieuweZetels);
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

        public bool Update(Verkiezingsuitslag s)
        {
            try
            {
                Database.Conn.Open();
                string query = "UPDATE Verkiezingsuitslag SET Naam = @naam, Datum = @datum, VerkiezingssoortID = @soort WHERE VerkiezingsuitslagID = @id";
                using (SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@id", s.Id);
                    cmd.Parameters.AddWithValue("@naam", s.Naam);
                    cmd.Parameters.AddWithValue("@datum", s.Datum);
                    cmd.Parameters.AddWithValue("@soort", s.Soort.Id);
                    cmd.ExecuteNonQuery();
                }

                string queryVP = "UPDATE Verkiezingsuitslag_Partij SET PartijID = @partij, Stemmen = @stemmen, Percentage= @percentage, Zetels = @zetels WHERE VerkiezingsuitslagID = @id)";
                using (SqlCommand cmd = new SqlCommand(queryVP, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@id", s.Id);
                    foreach (Partij p in s.Partijen)
                    {
                        cmd.Parameters.AddWithValue("@partij", p.Id);
                        cmd.Parameters.AddWithValue("@stemmen", p.Stemmen);
                        cmd.Parameters.AddWithValue("@percentage", p.Percentage);
                        cmd.Parameters.AddWithValue("@zetels", p.NieuweZetels);
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

        private Verkiezingsuitslag CreateUitslagFromReader(SqlDataReader r, List<Partij> partijen, Verkiezingssoort soort)
        {
            List<Partij> uitslagPartijen = new List<Partij>();
            foreach (Partij p in partijen)
            {
                if (p.Id == Convert.ToInt32(r["PartijID"]))
                {
                    uitslagPartijen.Add(p);
                }
            }
            return new Verkiezingsuitslag(Convert.ToInt32(r["VerkiezingsuitslagID"]), r["Naam"].ToString(), Convert.ToDateTime(r["Datum"]),
                                        soort, uitslagPartijen);
        }
        

        private Verkiezingssoort CreateSoortFromReader(SqlDataReader r, List<Partij> partijen)
        {
            List<Partij> soortPartijen = new List<Partij>();
            foreach (Partij p in partijen)
            {
                if (p.Id == Convert.ToInt32(r["PartijID"]))
                {
                    soortPartijen.Add(p);
                }
            }
            return new Verkiezingssoort(Convert.ToInt32(r["VerkiezingssoortID"]), r["Naam"].ToString(),
                                        Convert.ToInt32(r["Zetels"]), soortPartijen);
        }
    }
}
