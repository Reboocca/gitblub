using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows;
using BCrypt.Net;
using System.Data;

namespace Les1_LoginApp_Leerjaar1plus
{
    class dbs
    {
        #region fields
        private string conn;
        private MySqlConnection connect;
        #endregion

        //Connectie met de database
        private void db_connection()
        {
            try
            {
                conn = "Server=localhost;Database=oefeninlog;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }

            catch (MySqlException) //Foutafhandeling
            {
                MessageBox.Show("Kan geen verbinding maken met de database", "Foutmelding");
            }
        }

        //Functie voor het valideren van de login
        private bool validate_login(string user, string password)
        {
            //string sHash = BCrypt.Net.BCrypt.HashPassword(password);

           DataTable tbl = new DataTable();
           db_connection();
           MySqlCommand cmd = new MySqlCommand();
           cmd.CommandText = "Select * from users where Username=@user";
           cmd.Parameters.AddWithValue("@user", user);         //Parameter with the username
           //cmd.Parameters.AddWithValue("@pass", sHash);        // Parameter with the password
           cmd.Connection = connect;

            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                tbl.Load(reader);
            }
            catch
            {
                MessageBox.Show("Er is iets misgegaan met het laden van de gegevens");
            
            }
            finally
            {
                connect.Close();
            }


            bool validPassword = BCrypt.Net.BCrypt.Verify(password, tbl.Rows[0]["password"].ToString());

            if(validPassword == true)
            {

                return true;
            }
            else
            {
                return false;
            }
          
        }

        //Controleer wie er is ingelogd (welke rol -> voor het doorverwijzen naar volgende window)
        public void try_login(string user, string password, MainWindow loginform)
        {

            if (user == "" || password == "")       //Kleine controle of er gegevens zijn ingevuld
            {
                MessageBox.Show("Vul uw gebruikersnaam en wachtwoord in", "Foutmelding");
                return;
            }

            //Valideer de ingevoerde inloggegevens
            bool r = validate_login(user, password);

            if (r)      //Als de gegevens bekend zijn in de database & kloppen
            {
                form f = new form();
                f.Show();
                loginform.Close();
            }

            else            //Als de gegevens niet kloppen
            {
                MessageBox.Show("Uw gebruikersnaam of wachtwoord is onjuist", "Foutmelding");
            }

        }

        public void newUser(string user, string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into users (Username, Password) VALUES (@sUsername, @sPassword)";
            cmd.Parameters.AddWithValue("@sUsername", user);                    //Parameter with Username
            cmd.Parameters.AddWithValue("@sPassword", hashedPassword);          //Parameter with Password
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Het account is aangemaakt.", "Succes");
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van het account, probeer het nog eens.", "Error!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        public DataTable Search(string sTable)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + sTable))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return result
            return retValue;
        }
    }
}
