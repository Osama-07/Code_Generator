using clsGeneratorData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GeneratorData
{
    public class clsGeneratorCreationData
    {

        public static bool GenerateCreateDatabase(string DBName)
        {
            bool Created = false;

            SqlConnection Connection = new SqlConnection(clsSettingsDataAccess.ConnectionString);

            string query = $"CREATE DATABASE {DBName}";

            SqlCommand Command = new SqlCommand(query, Connection);


            try
            {
                Connection.Open();

                Command.ExecuteNonQuery();

                clsSettingsDataAccess.ConnectionString = "Server = .; Database = " + DBName + "; User ID = sa; Password = Sa123456;";

                Created = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Created = false;
            }
            finally
            {
                Connection.Close();
            }

            return Created;
        }

        public static bool GenerateCreateTable(string DBName, string TableName, string[] Columns)
        {
            bool Created = false;

            clsSettingsDataAccess.ConnectionString = $"Server = .; Database = {DBName}; User ID = sa; Password = Sa123456";

            SqlConnection Connection = new SqlConnection(clsSettingsDataAccess.ConnectionString);

            string query = $"CREATE TABLE {TableName} (";

            for (int i = 0; i < Columns.Length; i++)
            {
                query += Columns[i];
            }

            query += ")";

            SqlCommand Command = new SqlCommand(query, Connection);


            try
            {
                Connection.Open();

                Command.ExecuteNonQuery();

                Created = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Created = false;
            }
            finally
            {
                Connection.Close();
            }

            return Created;
        }


        public static bool UpdatePeople(int PersonID, string NationalNo, string FirstName, string LastName, string Email, byte Gendor)
        {
            bool Updated = false;

            string query = @"UPDATE People
                           SET 
                              PersonID = @PersonID,
                              NationalNo = @NationalNo,
                              FirstName = @FirstName,
                              LastName = @LastName,
                              Email = @Email,
                              Gendor = @Gendor
                           WHERE ID = @ID"; // Here Primary key ID of the table

            using (SqlConnection Connection = new SqlConnection(clsSettingsDataAccess.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(query, Connection))
                {
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    Command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    Command.Parameters.AddWithValue("@FirstName", FirstName);
                    Command.Parameters.AddWithValue("@LastName", LastName);
                    Command.Parameters.AddWithValue("@Email", Email);
                    Command.Parameters.AddWithValue("@Gendor", Gendor);

                    try
                    {
                        Connection.Open();

                        Command.ExecuteNonQuery();

                        Updated = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Updated = false;
                    }
                    finally
                    {
                        Connection.Close();
                    }

                    return Updated;
                }
            }
        }

        public static bool DeletePeople(int id)
        {
            bool Deleted = false;

            string query = @"DELETE FROM People
                             WHERE ID = @ID";

            using (SqlConnection Connection = new SqlConnection(clsSettingsDataAccess.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(query, Connection))
                {
                    Command.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        Connection.Open();

                        Command.ExecuteNonQuery();

                        Deleted = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: + {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Deleted = false;
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }

            return Deleted;
        }


        public static bool FindPeople(int PersonID, ref string NationalNo, ref string FirstName, ref string LastName, ref string Email,
                                        ref string Phone, ref byte Gendor)
        {
            bool Found = false;

            string query = @"SELECT * FROM People
                           WHERE PersonID = @PersonID"; // Here Primary key ID of the table

            using (SqlConnection Connection = new SqlConnection(clsSettingsDataAccess.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(query, Connection))
                {
                    Command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        Connection.Open();

                        SqlDataReader reader = Command.ExecuteReader();

                        if (reader.Read())
                        {
                            NationalNo = (string)reader["NationalNo"];
                            FirstName = (string)reader["FirstName"];
                            LastName = (string)reader["LastName"];
                            Email = (string)reader["Email"];
                            Phone = (string)reader["Phone"];
                            Gendor = (byte)reader["Gendor"];

                            Found = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Found = false;
                    }
                    finally
                    {
                        Connection.Close();
                    }

                    return Found;
                }
            }
        }





    }
}
