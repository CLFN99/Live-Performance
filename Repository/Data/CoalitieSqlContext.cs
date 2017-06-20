using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace Repository.Data
{
    public class CoalitieSqlContext:ICoalitieSqlContext
    {
        
        public List<Coalitie> GetAll()
        {
            List<Coalitie> coalities = new List<Coalitie>();
            List<Lid> leden = new List<Lid>();
            List<Partij> partijen = new List<Partij>();

            try
            {
                Database.Conn.Open();
                string queryLid = "SELECT * FROM Lid";
                using(SqlCommand cmd = new SqlCommand(queryLid, Database.Conn))
                {
                    using(SqlDataReader r = cmd.ExecuteReader())
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

                foreach (Partij p in partijen)
                {
                    foreach (Lid l in leden)
                    {
                        if (l.PartijId == p.Id)
                        {
                            p.Leden.Add(l);
                        }
                    }
                }

                string queryCoalitie = "SELECT * FROM Coalitie c INNER JOIN Coalitie_Partij CP ON c.CoalitieID = CP.CoalitieID INNER JOIN Partij P ON P.PartijID = CP.PartijID";
                using (SqlCommand cmd = new SqlCommand(queryCoalitie, Database.Conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            coalities.Add(CreateCoalitieFromReader(r, partijen));
                        }
                    }
                }
                return coalities;
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
        public Coalitie GetById(int id)
        {
            Coalitie c = new Coalitie();
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

                string queryCoalitie = "SELECT * FROM Coalitie c INNER JOIN Coalitie_Partij CP ON c.CoalitieID = CP.CoalitieID INNER JOIN Partij P ON P.PartijID = CP.PartijID WHERE C.CoalitieID = @id";
                using (SqlCommand cmd = new SqlCommand(queryCoalitie, Database.Conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        while (r.Read())
                        {
                            return CreateCoalitieFromReader(r, partijen);
                        }
                    }
                }
                return c;
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
        public bool NewCoalition(Coalitie c)
        {
            try
            {
                Database.Conn.Open();
                using(SqlCommand cmd = new SqlCommand("NewCoalition"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Naam", c.Naam);
                    cmd.Parameters.AddWithValue("@PremierID", c.PremierId);
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand("AddCoalitionParties"))
                {
                    foreach(Partij p in c.Partijen)
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PartijId", p.Id);
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

        private Lid CreateLidFromReader(SqlDataReader r)
        {
            return new Lid(Convert.ToInt32(r["LidID"]), r["Naam"].ToString(), Convert.ToInt32(r["PartijID"]));
        }

        private Partij CreatePartijFromReader(SqlDataReader r, List<Lid> leden)
        {
            return new Partij(Convert.ToInt32(r["PartijID"]), r["Afkorting"].ToString(), r["Naam"].ToString(),
                                Convert.ToInt32(r["Zetels"]), Convert.ToInt32(r["LijsttrekkerID"]), leden);
        }

        private Coalitie CreateCoalitieFromReader(SqlDataReader r, List<Partij> partijen)
        {
            List<Partij> coalitiePartijen = new List<Partij>();
            foreach (Partij p in partijen)
            {
                if (p.Id == Convert.ToInt32(r["PartijID"]))
                {
                    coalitiePartijen.Add(p);
                }
            }
            return new Coalitie(Convert.ToInt32(r["CoalitieID"]), r["Naam"].ToString(), Convert.ToInt32(r["PremierID"]), coalitiePartijen);
        }
    }
}
