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
        //private PartijRepository partijRepo = new PartijRepository(new PartijSqlContext());

        public List<Verkiezingssoort> GetAll()
        {
            List<Verkiezingssoort> soorten = new List<Verkiezingssoort>();

            try
            {
                Database.Conn.Open();
                
                string queryCoalitie = "SELECT * FROM Verkiezingssoort";
                using (SqlCommand cmd = new SqlCommand(queryCoalitie, Database.Conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            soorten.Add(CreateSoortFromReader(r));
                        }
                    }
                }
                foreach(Verkiezingssoort s in soorten)
                {
                    GetParties(s);
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

        public List<Partij> GetParties(Verkiezingssoort soort)
        {
            try
            {
               // Database.Conn.Open();

                string queryCoalitie = "SELECT s.VerkiezingssoortID, p.PartijID,P.Afkorting,P.Naam,P.Zetels, P.LijsttrekkerID FROM Verkiezingssoort S INNER JOIN Verkiezingssoort_Partij SP ON S.VerkiezingssoortID = SP.VerkiezingssoortID INNER JOIN Partij P ON P.PartijID = SP.PartijID";
                using (SqlCommand cmd = new SqlCommand(queryCoalitie, Database.Conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            soort.Partijen.Add(CreatePartijFromReader(r));
                        }
                    }
                }
                return soort.Partijen;
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
            //List<Partij> partijen = partijRepo.GetAll();

            try
            {
                Database.Conn.Open();
                string queryCoalitie = "SELECT * FROM Verkiezingssoort WHERE VerkiezingssoortID = @id";
                using (SqlCommand cmd = new SqlCommand(queryCoalitie, Database.Conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        while (r.Read())
                        {
                            return CreateSoortFromReader(r);
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
        private Partij CreatePartijFromReader(SqlDataReader r)
        {
            return new Partij(Convert.ToInt32(r["PartijID"]), r["Afkorting"].ToString(), r["Naam"].ToString(),
                                Convert.ToInt32(r["Zetels"]), Convert.ToInt32(r["LijsttrekkerID"]));
        }

        private Verkiezingssoort CreateSoortFromReader(SqlDataReader r)
        {
            //List<Partij> soortPartijen = new List<Partij>();
            //foreach(Partij p in partijen)
            //{
            //    if(p.Id == Convert.ToInt32(r["PartijID"]))
            //    {
            //        soortPartijen.Add(p);
            //    }
            //}
            return new Verkiezingssoort(Convert.ToInt32(r["VerkiezingssoortID"]), r["Naam"].ToString(),
                                        Convert.ToInt32(r["Zetels"]));
        }

    }
}
