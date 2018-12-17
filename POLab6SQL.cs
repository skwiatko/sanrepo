using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace POLab6_SQL
{
    public class Rodzaj
    {

        private string daneNazwa;
        private string daneWartosc;

        public Rodzaj(string daneNazwa, string daneWartosc)
        {
            this.daneNazwa = daneNazwa;
            this.daneWartosc = daneWartosc;
        }

        public string DaneNazwa
        {
            get { return daneNazwa; }
            set { daneNazwa = value; }
        }

        public string DaneWartosc
        {
            get { return daneWartosc; }
            set { daneWartosc = value; }
        }

        public override string ToString()
        {
            return daneNazwa;
        }

    }

    public static class Dodaj
    {
        public static void DodajKsiazke(String tytul, String rok, String autor, String nazwaW, String isbn)
        {
            String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projekt;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            String query = String.Format("insert into ksiazka(tytul, rokWydania, autorzy, nazwaWydawnictwa, numerISBN) values('{0}','{1}','{2}','{3}','{4}')", tytul, rok, autor, nazwaW, isbn);
            command.CommandText = query;
            connection.Open();
            command.ExecuteNonQuery();

            MessageBox.Show("Pomyślnie dodano do bazy!");
        }

        public static void DodajCzasopismo(String tytul, String rok, String numer, String rodzaj)
        {
            String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projekt;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            String query = String.Format("insert into czasopismo(tytul, rokWydania, numer, rodzaj) values('{0}','{1}','{2}','{3}')", tytul, rok, numer, rodzaj);
            command.CommandText = query;
            connection.Open();
            command.ExecuteNonQuery();

            MessageBox.Show("Pomyślnie dodano do bazy!");
        }

        public static void DodajPlytaAudio(String tytul, String typ, String wykonawcy, String utwory)
        {
            String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projekt;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            String query = String.Format("insert into plytaAudio(tytul, typNosnika, spisWykonawcow, spisUtworow) values('{0}','{1}','{2}','{3}')", tytul, typ, wykonawcy, utwory);
            command.CommandText = query;
            connection.Open();
            command.ExecuteNonQuery();

            MessageBox.Show("Pomyślnie dodano do bazy!");
        }

        public static void DodajProgram(String tytul, String typ, String nazwafirmy)
        {
            String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projekt;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            String query = String.Format("insert into plytaProgram(tytul, typNosnika, nazwaFirmy) values('{0}','{1}','{2}')", tytul, typ, nazwafirmy);
            command.CommandText = query;
            connection.Open();
            command.ExecuteNonQuery();

            MessageBox.Show("Pomyślnie dodano do bazy!");
        }

        public static void DodajKasAudio(String tytul, String autor, String utwory)
        {
            String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projekt;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            String query = String.Format("insert into kasetaAudio(tytul, spisWykonawcow, spisUtworow) values('{0}','{1}','{2}')", tytul, autor, utwory);
            command.CommandText = query;
            connection.Open();
            command.ExecuteNonQuery();

            MessageBox.Show("Pomyślnie dodano do bazy!");
        }

        public static void DodajKasVHS(String tytul, String rezyser)
        {
            String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projekt;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            String query = String.Format("insert into kasetaVHS(tytul, rezyser) values('{0}','{1}')", tytul, rezyser);
            command.CommandText = query;
            connection.Open();
            command.ExecuteNonQuery();

            MessageBox.Show("Pomyślnie dodano do bazy!");
        }
    }
}
