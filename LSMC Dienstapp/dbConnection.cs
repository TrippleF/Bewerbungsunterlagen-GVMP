using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace LSMC_Dienstapp
{
    public class dbConnection : IDisposable
    {

        public static MySqlConnection conn;
        public static MySqlConnection conn1;
        public MySqlTransaction transaction;


        public dbConnection()
        {


            string connStr = @"Server=localhost;port=3306;Database=LSMCDienstApp;Uid=LSMCDienstApp;Pwd=testdb;SslMode=none";

            conn = new MySqlConnection(connStr);
            conn1 = new MySqlConnection(connStr);

        }

        public void openConnection()
        {
            conn.Close();
            try
            {
                conn.Open();
                conn1.Open();
            }
            catch (Exception)
            {

            }

            SetTimer();
            if (IsDBConnectionOpen())
                transaction = conn.BeginTransaction();
        }


        public void closeConnection()
        {
            if (transaction != null)
                try
                {
                    transaction.Commit();
                }
                catch (Exception) { }

            conn.Close();
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void ExecuteSQL(string sSql)
        {
            MySqlCommand cmd = new MySqlCommand(sSql, conn);
            cmd.ExecuteNonQuery();
        }

        public MySqlDataReader readerSQL(string sSql)
        {
            MySqlCommand cmd = new MySqlCommand(sSql, conn);
            MySqlDataReader readerSql = cmd.ExecuteReader();

            return readerSql;
        }
        public int readerSQLScalar(string sSql)
        {
            MySqlCommand cmd1 = new MySqlCommand(sSql, conn1);
            int readerSql = int.Parse(cmd1.ExecuteScalar().ToString());
            

            return readerSql;

        }
        public static bool IsDBConnectionOpen()
        {
            if (conn.State == System.Data.ConnectionState.Open && conn1.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        protected int ExecuteSQLReturnId(string sSql)
        {
            MySqlCommand cmd = new MySqlCommand(sSql, conn);
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.LastInsertedId);
        }
        private static System.Timers.Timer aTimer;

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            //aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                conn.Ping();
                conn1.Ping();
            }
            catch (Exception) { }
        }
    }
}
