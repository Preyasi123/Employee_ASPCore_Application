
using System.Data;
using System.Data.SqlClient;

namespace Employee_ASPCore_Application.Models
{
    public class EmployeeDB
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-C5IFGSE\SQLEXPRESS;database=EMP_CoreApplnDB;Integrated Security=true");
        public string InsertDB(Employee objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empna", objcls.ename);//get
                cmd.Parameters.AddWithValue("@empag", objcls.eage);//get
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Inserted successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }

        public List<Employee> SelectDB()
        {
            var list = new List<Employee>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var o = new Employee
                    {
                        eid = Convert.ToInt32(sdr["Emp_Id"]),
                        ename = sdr["Emp_Name"].ToString(),
                        eage = Convert.ToInt32(sdr["Emp_Age"])
                    };
                    list.Add(o);
                }
                con.Close();
                return list;// ("OK...");
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
            // return list;
        }

        public string UpdateDB(Employee emp)
        {
            string retVal = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", emp.eid);
                cmd.Parameters.AddWithValue("@empna", emp.ename);
                cmd.Parameters.AddWithValue("@empag", emp.eage);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                retVal = "OK...updated";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message);
            }
            return (retVal);
        }
        public string DeleteDB(int id)
        {
            string retVal = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid",id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                retVal = "OK...deleted";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message);
            }
            return (retVal);
        }
        public Employee SelectProfileDB(int id)
        {
            var getdata = new Employee();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    getdata = new Employee
                    {
                        eid = Convert.ToInt32(sdr["Emp_Id"]),//set
                        ename = sdr["Emp_Name"].ToString(),
                        eage = Convert.ToInt32 (sdr["Emp_Age"])
                       
                    };
                }
                con.Close();
                return getdata;// ("OK...");
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
    }

}