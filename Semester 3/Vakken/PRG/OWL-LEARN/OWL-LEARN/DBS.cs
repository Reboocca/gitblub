using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;

namespace OWL_LEARN
{
    class DBS
    {
        private string conn;
        private MySqlConnection connect;

        private void db_connection()
        {
            try
            {
                conn = "Server=localhost;Database=owl-learn;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Kan geen verbinding maken met de database", "Oh nee!");
            }
        }
 
        private bool validate_login(string user, string password)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from users where Username=@user and Password=@pass";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }
        }

        public void try_login(string user, string password, MainWindow loginform)
        {

            if (user == "" || password == "")
            {
                MessageBox.Show("Vul uw gebruikersnaam en wachtwoord in", "Oeps!");
                return;
            }
            bool r = validate_login(user, password);
            if (r)
            {
                string sRolID = GetRol(user).ToString();
                if (sRolID == "1")
                {
                    ConsulentForm form = new ConsulentForm();
                    form.Show();
                    loginform.Close();
                }

                else if (sRolID == "2")
                {
                    LeerlingForm form = new LeerlingForm();
                    form.Show();
                    loginform.Close();
                }

                else 
                {
                    MessageBox.Show("Er is een fout opgetreden in het systeem, neem contact op met de beheerders van het programma", "Whoops!");
                }

            }
            else
            {
                MessageBox.Show("Uw gebruikersnaam of wachtwoord is onjuist", "Oh oh...");
            }
        }

        public string GetRol(string sUser)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from users where Username='" + sUser + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            string RolID = Convert.ToString(retValue.Rows[0]["rolID"]);
            return RolID;
        }
        public DataTable GetVakken()
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from vak"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable getLO(string vakID)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from lesonderwerp where VakID=" + vakID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable getLes(string lesOnderwerpID)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from Les where LesOnderwerpID=" + lesOnderwerpID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable getUsers()
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from users"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable getLOcms(string VakNaam)
        {
            string VakID="0";
            switch (VakNaam)
            {
                case "Geschiedenis":
                    VakID = "1";
                    break;
                
                case "Rekenen":
                    VakID = "2";
                    break;
                
                case "Biologie":
                    VakID = "3";
                    break;

                case "Nederlands":
                    VakID = "4";
                    break;

                case "Engels":
                    VakID = "5";
                    break;

                default: 
                    break;
            }

            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from LesOnderwerp where VakID="+ VakID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public void VoegLesOnderwerpToe(string VakID, string loOmschrijving)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO lesonderwerp(Omschrijving, VakID) VALUES('" + loOmschrijving + "', " + VakID + ")");
            cmd.Connection = connect;
            cmd.Parameters.AddWithValue("@lesonderwerp", loOmschrijving);
            cmd.ExecuteNonQuery();
            connect.Close();
        }
    }
}
