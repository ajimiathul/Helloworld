using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace DataAccessLayer
{
    public class clsDB
    {
        
        private string ConnString()
        {
                 string server = ConfigurationSettings.AppSettings["server"];
                 string db = ConfigurationSettings.AppSettings["db"];
                 string uid = ConfigurationSettings.AppSettings["uid"];
                 string pwd = ConfigurationSettings.AppSettings["pwd"];
                 string constr = "Data Source='" + server + "';Initial Catalog='" + db + "';uid=sa;pwd='" + pwd + "'";
                 return constr;
        }

        public DataSet GetData(string storedProcedureName, Hashtable parameterList)
        {
            string errMsg;
            IDictionaryEnumerator parameter;
            DataSet dataSet = new DataSet();
            SqlConnection databaseConnection = new SqlConnection(ConnString());
            try
            {
                databaseConnection.Open();
                SqlCommand databaseCommand = new SqlCommand();
                databaseCommand.Connection = databaseConnection;
                databaseCommand.CommandText = storedProcedureName;
                databaseCommand.CommandType = CommandType.StoredProcedure;
                if (parameterList != null)
                {
                    parameter = parameterList.GetEnumerator();
                    while (parameter.MoveNext())
                    {
                        databaseCommand.Parameters.AddWithValue(parameter.Key.ToString(), parameter.Value);
                    }
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = databaseCommand;
                dataAdapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
            }
            finally
            {
                databaseConnection.Close();
            }
            return dataSet;
        }//end getdata method

        public int ExecuteNonQuery(string storedProcedureName, SortedList parameterList)
        {
            string errMsg;
            int ret = 0;
            IDictionaryEnumerator parameter;
            SqlConnection databaseConnection = new SqlConnection(ConnString());
            try
            {
                databaseConnection.Open();
                SqlCommand databaseCommand = new SqlCommand();
                databaseCommand.Connection = databaseConnection;
                databaseCommand.CommandText = storedProcedureName;
                databaseCommand.CommandType = CommandType.StoredProcedure;
                if (parameterList != null)
                {
                    parameter = parameterList.GetEnumerator();
                    while (parameter.MoveNext())
                    {
                        databaseCommand.Parameters.AddWithValue(parameter.Key.ToString(), parameter.Value);
                    }
                }
                ret = databaseCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
            }
            finally
            {
                databaseConnection.Close();
            }
            return ret;
        }//end method

        public int ExecuteNonQueryWithRecId(string storedProcedureName, SortedList parameterList)
        {

            string errMsg;
            int ret = 0;
            IDictionaryEnumerator parameter;
            SqlConnection databaseConnection = new SqlConnection(ConnString());
            try
            {
                databaseConnection.Open();
                SqlCommand databaseCommand = new SqlCommand();
                databaseCommand.Connection = databaseConnection;
                databaseCommand.CommandText = storedProcedureName;
                databaseCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter();
                bool skip = false;
                string pname = "";
                object pvalue = 0;
                if (parameterList != null)
                {
                    parameter = parameterList.GetEnumerator();
                    while (parameter.MoveNext())
                    {
                        p = new SqlParameter();
                        p.ParameterName = parameter.Key.ToString();
                        p.SqlValue = parameter.Value;
                        if (parameter.Key.ToString() == "@NewId")
                        {
                            skip = true;
                            pname = parameter.Key.ToString();
                            pvalue = parameter.Value;
                        }
                        else
                        {
                            p.Direction = ParameterDirection.Input;
                            databaseCommand.Parameters.Add(p);
                        }

                    }
                }
                if (skip == true)
                {
                    p = new SqlParameter();
                    p.ParameterName = pname;
                    p.SqlValue = pvalue;
                    p.Direction = ParameterDirection.Output;
                    databaseCommand.Parameters.Add(p);
                }

                ret = databaseCommand.ExecuteNonQuery();
                ret = Convert.ToInt32(p.Value);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
            }
            finally
            {
                databaseConnection.Close();
            }

            return ret;

        }

    }
}
