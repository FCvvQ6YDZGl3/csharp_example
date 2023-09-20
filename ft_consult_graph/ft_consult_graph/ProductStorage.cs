using System;
using System.Collections.Generic;
using System.Text;
using ft_consult.connection;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Microsoft.Data.SqlTypes;
using System.Data;

namespace ft_consult
{

    class Izdel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Link
    {
        public long izdelUp { get; set; }
        public long izdel { get; set; }
        public uint kol { get; set; }
    }

    class ProductStorage
    {
        private SqlConnection connection;

        private List<Izdel> IzdelsField;
        private List<Link> LinksField;
        public ProductStorage()
        {
            IzdelsField = new List<Izdel>();
            LinksField = new List<Link>();
        }
        public List<Izdel> Izdels
        {
            get
            {
                return IzdelsField;
            }
        }

        public List<Link> Links
        {
            get
            {
                return LinksField;
            }
        }
        public void addInIzdel(Izdel newIzdel)
        {


            connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                string sql = "INSERT dbo.Izdel VALUES (@name, @price); SET @id = SCOPE_IDENTITY();";
                SqlCommand cmd = getSqlCommand(sql);

                SqlCommand command = new SqlCommand(sql, connection);

                SqlParameter nameParam = new SqlParameter("@name", newIzdel.Name);
                command.Parameters.Add(nameParam);

                SqlParameter priceParam = new SqlParameter("@price", newIzdel.Price);
                command.Parameters.Add(priceParam);

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
                newIzdel.Id = (int)idParam.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }

        }
        public void init()
        {
            connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                string sql;

                sql = "SELECT Id, Name, Price FROM Izdel";
                this.readIzdelsAndAddInCollection(this.getSqlCommand(sql));

                sql = "SELECT IzdelUp, Izdel, kol FROM Links";
                this.readLinksAndSetUpLinks(this.getSqlCommand(sql));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        private SqlCommand getSqlCommand(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = sql;
            return cmd;
        }
        private void readIzdelsAndAddInCollection(SqlCommand cmd)
        {
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.readIzdelAndAddInList(reader);
                    }
                }
            }
        }
        private void readIzdelAndAddInList(DbDataReader reader)
        {
            Izdel izdel = new Izdel();

            int idIndex = reader.GetOrdinal("Id");
            izdel.Id = Convert.ToInt64(reader.GetValue(idIndex));

            int nameIndex = reader.GetOrdinal("Name");
            izdel.Name = reader.GetString(nameIndex);

            int priceIndex = reader.GetOrdinal("Price");
            double price = Convert.ToDouble(reader.GetValue(priceIndex));

            IzdelsField.Add(izdel);
        }

        private void readLinksAndSetUpLinks(SqlCommand cmd)
        {
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.readLinkAndAddInList(reader);
                    }
                }
            }
        }

        private void readLinkAndAddInList(DbDataReader reader)
        {
            Link link = new Link();

            int izdelUpIndex = reader.GetOrdinal("IzdelUp");
            link.izdelUp = Convert.ToInt64(reader.GetValue(izdelUpIndex));

            int izdelIndex = reader.GetOrdinal("Izdel");
            link.izdel = Convert.ToInt64(reader.GetValue(izdelIndex));

            int kolIndex = reader.GetOrdinal("Kol");
            link.kol = Convert.ToUInt32(reader.GetValue(kolIndex));

            Links.Add(link);
        }
    }
}
