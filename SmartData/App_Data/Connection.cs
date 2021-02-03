using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Net.Mail;



public class Connection
{
    public SqlConnection con = new SqlConnection("Data Source=DESKTOP-C0NHIE5;Initial Catalog=harcourt;Integrated Security=True");
    public Connection()
    {
       
    }
    public void connect()
    {
        con.Open();
    }
    public void disconnect()
    {
        con.Close();
    }
   
   
    public String encode(String data)
    {
        char[] b = new char[50];
        b = data.ToCharArray();
        String c = "";
        int i, len;
        len = b.Length;
        for (i = 0; i < len; i++)
        {
            c = c + Convert.ToChar(b[i] * (i + 2));
        }
        return c;
    }
    public String decode(String data)
    {
        char[] b = new char[50];
        b = data.ToCharArray();
        String c = "";
        int i, len;
        len = data.Length;
        for (i = 0; i < len; i++)
        {
            c = c + Convert.ToChar(b[i] / (i + 2));
        }
        return c;
    }
}