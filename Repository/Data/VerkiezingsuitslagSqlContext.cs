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

        // private PartijRepository partijRepo = new PartijRepository(new PartijSqlContext());
        private VerkiezingssoortRepository soortRepo = new VerkiezingssoortRepository(new VerkiezingssoortSqlContext());

        public List<Verkiezingsuitslag> GetAll()
        {
            List<Verkiezingsuitslag> uitslagen = new List<Verkiezingsuitslag>();
            try
            {
                Database.Conn.Open();
                string query = "SELECT VU.VerkiezingsuitslagID, vu.Naam, vu.Datum, vu.VerkiezingssoortID, vs.Naam AS Soort, vs.Zetels FROM Verkiezingsuitslag VU INNER JOIN Verkiezingssoort VS ON VU.VerkiezingssoortID = VS.VerkiezingssoortID ";
                using(SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    
                    using(SqlDataReader r = cmd.ExecuteReader())
                    {
                        
                        while (r.Read())
                        {
                            Verkiezingssoort soort = CreateSoortFromReader(r);
                            //soortRepo.GetParties(soort);
                            //Database.Conn.Open();
                            uitslagen.Add(CreateUitslagFromReader(r,soort));
                        }
                    }
                }
                foreach(Verkiezingsuitslag u in uitslagen)
                {
                    u.Partijen = GetParties(u);
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

     

        public List<Partij> GetParties(Verkiezingsuitslag u)
        {
            try
            {
               // Database.Conn.Open();

                string queryCoalitie = "SELECT s.VerkiezingsuitslagID, p.PartijID,P.Afkorting,P.Naam,P.Zetels, P.LijsttrekkerID FROM Verkiezingsuitslag S INNER JOIN Verkiezingsuitslag_Partij SP ON S.VerkiezingssoortID = SP.VerkiezingsuitslagID INNER JOIN Partij P ON P.PartijID = SP.PartijID";
                using (SqlCommand cmd = new SqlCommand(queryCoalitie, Database.Conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            u.Partijen.Add(CreatePartijFromReader(r));
                        }
                    }
                }
                return u.Partijen;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            
        }

        public void GetPartyElectionResults(Verkiezingsuitslag u)
        {
            try
            {
                Database.Conn.Open();
                string query = "SELECT PartijID, Stemmen, Percentage, Zetels FROM Verkiezingsuitslag_Partij WHERE VerkiezingsuitslagID = @id";
                using (SqlCommand cmd = new SqlCommand(query, Database.Conn))
                {
                    cmd.Parameters.AddWithValue("@id", u.Id);
                    foreach(Partij p in u.Partijen)
                    {
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                if(p.Id == Convert.ToInt32(r["PartijID"]))
                                {
                                    p.Stemmen = Convert.ToInt32(r["Stemmen"]);
                                    p.Percentage = Convert.ToDouble(r["Percentage"]);
                                    p.NieuweZetels = Convert.ToInt32(r["Zetels"]);
                                }
                               
                            }
                        }
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Database.Conn.Close();
            }
        }

        public Verkiezingsuitslag GetById(int id)
        {
           // List<Partij> partijen = partijRepo.GetAll();
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
                            Verkiezingssoort soort = CreateSoortFromReader(r);
                            return CreateUitslagFromReader(r, soort);
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

        private Verkiezingsuitslag CreateUitslagFromReader(SqlDataReader r, Verkiezingssoort soort)
        {
            return new Verkiezingsuitslag(Convert.ToInt32(r["VerkiezingsuitslagID"]), r["Naam"].ToString(), Convert.ToDateTime(r["Datum"]),
                                        soort);
        }
        private Partij CreatePartijFromReader(SqlDataReader r)
        {
            return new Partij(Convert.ToInt32(r["PartijID"]), r["Afkorting"].ToString(), r["Naam"].ToString(),
                                Convert.ToInt32(r["Zetels"]), Convert.ToInt32(r["LijsttrekkerID"]));
        }

        private Verkiezingssoort CreateSoortFromReader(SqlDataReader r)
        {
            return new Verkiezingssoort(Convert.ToInt32(r["VerkiezingssoortID"]), r["Soort"].ToString(),
                                        Convert.ToInt32(r["Zetels"]));
        }
    }
}
