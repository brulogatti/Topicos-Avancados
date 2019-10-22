using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AcessoDados
{
    public class BD
    {
        private string _stringConexao;

        public string StringConexao
        {
            get
            {
                //SQL SERVER 2008
                _stringConexao = @"Data Source=PC-BRUNA\MSSQLSERVER01;Initial Catalog=empresa;Integrated Security=SSPI;";
                return _stringConexao;
            }
        }


        private SqlConnection _con;

        private SqlConnection Con
        {
            get { return _con; }
            set { _con = value; }
        }

        public BD()
        {
            if (_con == null)
            {
                _con = new SqlConnection(StringConexao);

            }
        }

        public bool AbrirConexao()
        {

            try
            {
                if (_con.State == ConnectionState.Closed)
                {
                    _con.Open();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }

        public bool FecharConexao()
        {
            try
            {
                if (_con != null)
                {

                    if (_con.State == ConnectionState.Open)
                    {
                        _con.Close();
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                _con.Dispose();
                _con = null;
            }
        }

        public DataSet ExecutarConsulta(string sql)
        {
            DataSet ds = null;
            SqlDataAdapter dap = null;

            if (this.AbrirConexao() && (String.IsNullOrEmpty(sql) == false))
            {
                ds = new DataSet();
                dap = new SqlDataAdapter(sql, Con);
                dap.Fill(ds);
                this.FecharConexao();
            }

            return ds;
        }

        public bool ExecutarInsert(SqlCommand sql)
        {
            SqlConnection sqlc = new SqlConnection();
            sqlc.ConnectionString = StringConexao;
            SqlCommand sc = new SqlCommand();
            sc = sql;
            sc.Connection = sqlc;
            sc.CommandType = CommandType.Text;

            sqlc.Open();
            sc.ExecuteNonQuery();

            return true;
        }


        public bool ExecutarProcedure(SqlCommand sql)
        {
            SqlConnection sqlc = new SqlConnection();
            sqlc.ConnectionString = StringConexao;
            SqlCommand sc = new SqlCommand();
            sc = sql;
            sc.Connection = sqlc;
            sc.CommandType = CommandType.StoredProcedure;

            sqlc.Open();
            sc.ExecuteNonQuery();
            sqlc.Close();
            return true;
        }

        public DataSet ExecutarProcedureConsulta(SqlCommand sql)
        {
            DataSet ds = null;
            SqlDataAdapter dap = null;
            SqlConnection sqlc = new SqlConnection();
            sqlc.ConnectionString = StringConexao;
            SqlCommand sc = new SqlCommand();
            sc = sql;
            sc.Connection = sqlc;
            sc.CommandType = CommandType.StoredProcedure;
            sqlc.Open();
            ds = new DataSet();
            dap = new SqlDataAdapter(sql);
            dap.Fill(ds);
            sqlc.Close();
            return ds;
        }
    }
}
