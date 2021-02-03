using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartData
{
    public partial class UserDetails : System.Web.UI.Page
    {
        public Connection co = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
            }
        }
        protected void show()
        {
            co.connect();
            String stt = "SELECT * FROM tblusr ";
            SqlCommand cmd = new SqlCommand(stt, co.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            co.disconnect();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvfee.RowStyle.ForeColor = Color.Blue;
                gvfee.DataSource = ds;
                gvfee.DataBind();
            }
        }
        protected void gv_edit(object sender, GridViewEditEventArgs e)
        {
            gvfee.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(gvfee.DataKeys[e.NewEditIndex].Value);
            editing(id);
            show();
        }
        protected void gv_canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            editing(0);
            gvfee.EditIndex = -1;
            show();
        }
        protected void gv_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                String data = dr["usr"].ToString();
                e.Row.Cells[0].Text = co.decode(data);
                dr = (DataRowView)e.Row.DataItem;
                data = dr["dob"].ToString();
                e.Row.Cells[1].Text = co.decode(data);
                dr = (DataRowView)e.Row.DataItem;
                data = dr["cont"].ToString();
                e.Row.Cells[2].Text = co.decode(data);
                dr = (DataRowView)e.Row.DataItem;
                data = dr["email"].ToString();
                e.Row.Cells[3].Text = co.decode(data);

            }
        }
        protected void btninsert_Click(object sender, EventArgs e)
        {

            String name = co.encode(lblusr.Text.Trim());
            String dob = co.encode(lbldob.Text.Trim());
            String cont = co.encode(lblcont.Text.Trim());
            String email = co.encode(lblmail.Text.Trim());
            if ( btnupdate.Text == "INSERT")
            {
                co.connect();
                String stt = "insert into tblusr (usr,email,cont,dob,pass,veri) values(N'"+name+ "',N'" + email + "',N'" + cont + "',N'" + dob + "',N'123456',N'true')";
                SqlCommand cmd = new SqlCommand(stt, co.con);
                int result = cmd.ExecuteNonQuery();
                co.disconnect();
                if (result > 0)
                {
                    gvfee.EditIndex = -1;
                    show();
                    lblmsg.ForeColor = Color.Green;
                    lblmsg.Text = "User Registered Succesfully";
                }
                else
                {
                    lblmsg.ForeColor = Color.Red;
                    lblmsg.Text = "User Not Registered";
                }
                co.disconnect();
            }
            else if (btnupdate.Text == "UPDATE")
            {
                co.connect();
                String stt = "update tblusr set usr=N'"+name+"',email=N'"+email+"',cont=N'"+cont+"',dob=N'"+dob+ "'where id=" + gvfee.DataKeys[gvfee.EditIndex].Value;
                SqlCommand cmd = new SqlCommand(stt, co.con);
                int result = cmd.ExecuteNonQuery();
                co.disconnect();
                if (result > 0)
                {
                    gvfee.EditIndex = -1;
                    show();
                    lblmsg.ForeColor = Color.Green;
                    lblmsg.Text = "Data Updated Succesfully";
                }
                else
                {
                    lblmsg.ForeColor = Color.Red;
                    lblmsg.Text = "Data Not Updated Succesfully";
                }
                co.disconnect();
            }
            editing(0);
        }
        protected void editing(int id)
        {
            if (id > 0)
            {
                co.connect();
                string stt = "select * from tblusr where id=" + id + "";
                SqlCommand cmd = new SqlCommand(stt, co.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblusr.Text = co.decode(dr["usr"].ToString());
                        lblcont.Text = co.decode(dr["cont"].ToString());
                        lbldob.Text = co.decode(dr["dob"].ToString());
                        lblmail.Text = co.decode(dr["email"].ToString());
                        btnupdate.Text=lblhead.Text= "UPDATE";
                    }
                }
                co.disconnect();
            }
            else
            {
                btnupdate.Text=lblhead.Text = "INSERT";
                lblusr.Text =lblcont.Text = lbldob.Text = lblmail.Text =  "";
            }
        }

        protected void gv_delete(object sender, GridViewDeleteEventArgs e)
        {
            gvfee.EditIndex = e.RowIndex;
            int id = Convert.ToInt32(gvfee.DataKeys[e.RowIndex].Value);
            co.connect();
            String stt = "delete from tblusr where id="+id;
            SqlCommand cmd = new SqlCommand(stt, co.con);
            int result = cmd.ExecuteNonQuery();
            co.disconnect();
            if (result > 0)
            {
                gvfee.EditIndex = -1;
                show();
                lblmsg.ForeColor = Color.Green;
                lblmsg.Text = "User Deleted Succesfully";
            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "User Not Deleted Succesfully";
            }
            co.disconnect();
        }
    }
}