using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace QuanLyCHDTDD
{
    class XuLiUser
    {
        public SqlConnection cnn;
        public XuLiUser()
        {
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CC"].ConnectionString);
        }
        public static string type;
    }
}
