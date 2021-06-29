﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCafe.DAO
{
    class DataProvider
    {
        private string connectionSTR = "Data Source=.\\SQLEXPRESS;Initial Catalog=QLQuanCafe;Integrated Security=True";
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionSTR)) 
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                
                if(parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listpara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }

        //update
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }
                data = command.ExecuteNonQuery();
                conn.Close();
            }
            return data;
        }

        //select count *
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }
                data = command.ExecuteScalar();
                conn.Close();
            }
            return data;
        }

    }
}
