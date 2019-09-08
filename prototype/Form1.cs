using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace prototype
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        bool OpenOrClose;
        int userID=0;
        //double item,cridet;//وضعنا فيه قيمة التقييم
        string UserBarcode;
        DataTable dt = new DataTable();
        int rowIndex = -1;
        DataGridViewRow row;
        double TotalCridit;
        double Values, sum = 0;
        //double qutnesbah = 0;//وضعنا فية قيمة الخصم لكل صنف
        //double x;
        int i;

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Prototype;Integrated Security=True");
        //SqlConnection con = new SqlConnection("Data Source=EMAD\\SQLEXPRESS;Initial Catalog=Prototype;Integrated Security=SSPI;User ID=admin;Password=123456;");
        //SqlConnection con = new SqlConnection("Server=[EMAD\\SQLEXPRESS];Database=[Prototype];Uid=[admin];Pwd=[123456]");

        public frmMain()
        {
            InitializeComponent();
            DataColumn dc = new DataColumn("id", typeof(int));
            dt.Columns.Add(dc);

            dc = new DataColumn("barcode", typeof(string));
            dt.Columns.Add(dc);
            

            dc = new DataColumn("name", typeof(string));
            dt.Columns.Add(dc);

            dc = new DataColumn("qty", typeof(int));
            dt.Columns.Add(dc);

            dc = new DataColumn("price", typeof(string));
            dt.Columns.Add(dc);

            dt.PrimaryKey =  new DataColumn[] { dt.Columns["barcode"] };
        }

        void calculate()
        {
            double sum = 0;
            foreach(DataRow dr in dt.Rows) {
                sum = sum + Convert.ToDouble(dr[4].ToString()) * Convert.ToDouble(dr[3].ToString());
            }
            txtTotal.Text = sum.ToString();
        }

        void FindItem(string barcode)
        {
            string query = "select * from goods where g_barcode = @barcode";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@barcode", barcode);
            DataRow dr = dt.NewRow();
            con.Open();
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                dr[0] = Convert.ToInt32(r["g_id"].ToString());
                dr[1] = r["g_barcode"].ToString();
                dr[2] = r["g_name"].ToString();
                dr[3] = 1;
                dr[4] = r["g_price"].ToString();

                DataRow foundRow = dt.Rows.Find(dr[1].ToString());
                if (foundRow != null)
                {
                    foundRow[3] = Convert.ToInt32(foundRow[3].ToString()) + 1;
                }
                else
                {
                    dt.Rows.Add(dr);
                }
                gvMain.DataSource = dt;
                txtBarcode.Clear();
            }
            else { txtBarcode.Clear(); }
            con.Close();
            calculate();
        }

        void SystemState(bool state)
        {
            if(state==false)
            {
                OpenOrClose = false;
                //خدمة عبدالله

                if (txtCredit.Text == "") txtCredit.Text = "0";
                if (txtTotal.Text == "") txtTotal.Text = "0";
                if (Convert.ToDouble(txtTotal.Text)>Convert.ToDouble (txtCredit.Text))
                {
                    MessageBox.Show("رصيدك غير كافي", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (MessageBox.Show("هل تريد شحن رصيدك الان", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
                    {
                        //لشحن الرصيد وثمّ يعاد عرض رصيد البطاقة وتحدث المقارنة بين الاجكالي ورصيد البطاقة وتمشي الامور ^^

                        //Prototype2.Forms.FCards f = new Prototype2.Forms.FCards();
                        //f.ShowDialog();
                        return;

                    }
                    //في حالة ترجيع كمية من البضاعة المؤخوذه باش تتساوي القيم
                    else
                    {
                        MessageBox.Show("سنقدم إليك بعض الإقتراحات ^__^", "لحظة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TotalCridit=Convert.ToDouble(txtTotal.Text)-(Convert.ToDouble(txtCredit.Text)-3);//قيمة الترجيعات مفروض انها تكون 13.50 دينار

                        if (Convert.ToDouble(txtCredit.Text)<3.10)
                        {
                            MessageBox.Show("رصيدك لا يكفي للشراء الرجاء إعادة شحن البطاقة", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                 
                        panel1.Visible = true;
                    
                        SqlCommand cmdHas;
                        SqlDataReader dr;
                        string sql;
                        //نقوم بحذف جميع العناصر الموجودة في الجدول ال}مؤقت
                        sql = "delete TEMP";
                        cmdHas = new SqlCommand(sql, con);
                        con.Open(); cmdHas.ExecuteNonQuery();con.Close();
                        sql = "delete Tests";
                        cmdHas = new SqlCommand(sql, con);
                        con.Open(); cmdHas.ExecuteNonQuery(); con.Close();
                        //الي هنا تتم عملية الحذف

                        //نبدأ عملية المقارنة بين الأصناف وجدول التقيمات

                        for (int i = 0; i < gvMain.Rows.Count; i++)
                        {
                            sql = "select g_name,g_id,g_price,Ra_Evaluation from Ratings,GOODS where Ra_Goods=g_id and g_barcode='"+ gvMain.Rows[i].Cells[1].Value.ToString() + "' and Ra_Status=1";
                            cmdHas = new SqlCommand(sql, con);
                            con.Open();
                            dr = cmdHas.ExecuteReader();
                            dr.Read();
                            if (dr.HasRows)//في حالة أن الصنف موجود في جدول التقييمات
                            {
                                //التقييم + موجود أو لا + الكمية
                                sql = "insert into TEMP values("+dr[3]+",1,"+ gvMain.Rows[i].Cells[3].Value.ToString() + ","+ gvMain.Rows[i].Cells[4].Value.ToString() + ",N'"+ gvMain.Rows[i].Cells[2].Value.ToString() + "')";
                                con.Close();
                                cmdHas = new SqlCommand(sql, con);
                                con.Open();
                                cmdHas.ExecuteNonQuery();
                                con.Close();
                                
                            }
                            else  //في حالة ان الصنف مش موجود في جدول التقييمات
                            {
                               
                                con.Close();
                                sql = "insert into TEMP values(0,0," + gvMain.Rows[i].Cells[3].Value.ToString() + "," + gvMain.Rows[i].Cells[4].Value.ToString() + ",N'"+ gvMain.Rows[i].Cells[2].Value.ToString() + "')";
                                //الصفر الأول يعني ان تقييمه صفر والثاني يعني أن مش موجود في جدول التقييمات
                                cmdHas = new SqlCommand(sql, con);
                                con.Open();
                                cmdHas.ExecuteNonQuery();
                                con.Close();
                            }
                             }//هنا تنتهي عملية المقارنة وتحصلنا على بيانات مخزنة في الجدول المؤقت TEMP
                              //بداية رسالة الإقتراح
                      
                        //الي هنا النفخ متع نقص الكميات حسب الارقام الموجودة الخاصة بالتقييم
                        //else // كانهو ساوى 11
                        //{


                            sql = "select * from TEMP  order by TM_Ra_ID,TM_Price asc ";
                            cmdHas = new SqlCommand(sql, con);
                            con.Open();
                            dr = cmdHas.ExecuteReader();
                            //3الكمية  
                            //4 السعر
                            //1 التقييم
                            //5 الإسم
                            LabLoob.Text = "قم بإرجاع ";
                            while (dr.Read())
                            {

                            if (Values < (Convert.ToDouble(txtCredit.Text) - 1) && Values !=0)
                            {
                                //LabLoob.Text += "  " + dr[5] + " " + "يلي كميته" + " " + i;
                                break;
                            }
                            int f = Convert.ToInt32(dr[3]);
                            //d = dr[3].ToString();
                            int count=0;
                            for (i = 1; i <= f; i++)
                            {

                                sum += Convert.ToDouble(dr[4]) * 1;
                                count++;
                                //sum = 3;
                                Values = Convert.ToDouble(txtTotal.Text) - sum;
                                if (Values < (Convert.ToDouble(txtCredit.Text) - 1))
                                {                        
                                    LabLoob.Text += "  " + count +" "+"قطع من "+ " " +dr[5];
                                    break;
                                }

                                if(count==f)
                                {
                                    LabLoob.Text += "  " + count + "قطع  من " + " " + dr[5];
                                }
                                //else
                                //{
                                //    LabLoob.Text += "  " + dr[5] + " " + "يلي كميته" + " " + i;
                                //}
                            }
                        }
                        //    sum += Convert.ToDouble(dr[4]) *  Convert.ToDouble(dr[3]);
                        ////sum = 0;
                        //Values = Convert.ToDouble(txtTotal.Text) - sum;
                        //    if (Values < (Convert.ToDouble(txtCredit.Text) - 3))
                        //    {
                        //        LabLoob.Text += "  " + dr[5] + " " + "يلي كميته" + " " + dr[3];
                        //        break;
                        //    }
                        //    else
                        //    {
                        //        LabLoob.Text += "  " + dr[5] + " " + "يلي كميته" + " " + dr[3];
                        //    }




                    }
                        con.Close();
                            return;
                    //}// //الي هنا حالة ترجيع كمية من البضاعة المؤخوذه باش تتساوي القيم

                }

           //الي هنا
                //userID = 0;
                //UserBarcode = "";
                /////////////////////////////////////////
                //if (Convert.ToDouble(txtCredit.Text) >= Convert.ToDouble(txtTotal.Text))
                //{
                    SqlCommand cmd;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            cmd = new SqlCommand("insert into INVOICE_DETAILS values(@id,@qty,@price,1,@date,2)", con);
                            cmd.Parameters.AddWithValue("@id", dr[0].ToString());
                            cmd.Parameters.AddWithValue("@qty", dr[3].ToString());
                            cmd.Parameters.AddWithValue("@price", dr[4].ToString());
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        cmd = new SqlCommand("insert into RECIPTS values(@amount,2,@id,@card)", con);
                        cmd.Parameters.AddWithValue("@amount", txtTotal.Text);
                        cmd.Parameters.AddWithValue("@id", userID);
                        cmd.Parameters.AddWithValue("@card", UserBarcode);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    dt.Clear();
                //}
                //else { lblMessage.Text = "رصيدك لا يكفي"; }//MessageBox.Show("رصيدك لا يكفي"); }
                                                         /////////////////////////////////////////
                    lblMessage.Text = "تم تسجيل الخروج";//MessageBox.Show("تم تسجيل الخروج");
                    txtBarcode.Clear();
                txtCredit.Clear();
                txtTotal.Clear();
            }
            else if (state == true)
            {
                SqlCommand cmd = new SqlCommand("select * from CARDS where c_barcode = @barcode", con);
                cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text.Trim());
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    if(Convert.ToBoolean(r["c_active"].ToString())==true)
                    {
                        userID = Convert.ToInt32(r["c_user_id"].ToString());
                        UserBarcode = r["c_barcode"].ToString();
                            lblMessage.Text = "تم تسجيل الدخول"; //MessageBox.Show("تم تسجيل الدخول");
                        txtBarcode.Clear();
                        OpenOrClose = true;
                        con.Close();
                        string query = "select sum(r_amount) - (select sum(r_amount) from RECIPTS where r_user_id=" + userID + " and r_type=2) from recipts where r_user_id = " + userID + " and r_type = 1";
                        cmd = new SqlCommand(query, con);
                        con.Open();
                        string x = cmd.ExecuteScalar().ToString();
                        con.Close();
                        if (x!="")
                        {
                            txtCredit.Text = x;//cmd.ExecuteScalar().ToString();
                        }
                        else
                        {
                            cmd = new SqlCommand("select sum(r_amount) from RECIPTS where r_user_id=" + userID + " and r_type=1", con);
                            con.Open();
                            x = cmd.ExecuteScalar().ToString();
                            if (x != "")
                            { txtCredit.Text = x; }
                            else { txtCredit.Text = "0"; }
                            con.Close();
                        }
                    }
                    else
                    {
                        lblMessage.Text = "البطاقة منتهية الصلاحية"; //MessageBox.Show("البطاقة منتهية الصلاحية");
                        txtBarcode.Clear();
                    }
                }
                else
                {
                    lblMessage.Text = "خطأ في تسجيل الدخول"; //MessageBox.Show("خطأ في تسجيل الدخول");
                    txtBarcode.Clear();
                }
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBarcode.Width = 750;
            txtBarcode.Top = this.Top + 60;
            txtBarcode.Left = this.Width / 2-txtBarcode.Width/2;
            gvMain.Width = txtBarcode.Width;
            gvMain.Left = txtBarcode.Left;
            gvMain.Top = txtBarcode.Top + txtBarcode.Height + 10;
            gvMain.Height = this.Height-200;
            btnDelete.Top = gvMain.Top;
            btnDelete.Height = gvMain.Height;
            btnDelete.Width = 100;
            btnDelete.Left = txtBarcode.Left + (txtBarcode.Width+10);
            txtCredit.Top = gvMain.Top + gvMain.Height + 10;
            txtTotal.Top = txtCredit.Top;
            label1.Top = txtCredit.Top+7;
            label2.Top = txtCredit.Top+7;
            label1.Left = gvMain.Left;
            txtCredit.Left = gvMain.Left + label1.Width;
            txtTotal.Left = gvMain.Left + gvMain.Width-txtTotal.Width;
            label2.Left = txtTotal.Left - label2.Width;
            btnAddQty.Width = btnDelete.Width;
            btnReduceQty.Width = btnDelete.Width;
            btnAddQty.Top = gvMain.Top;
            btnAddQty.Height = gvMain.Height / 2 - 5;
            btnReduceQty.Height = gvMain.Height / 2 - 5;
            btnReduceQty.Top = btnAddQty.Top + btnAddQty.Height + 10;
            btnAddQty.Left = gvMain.Left - btnAddQty.Width - 10;
            btnReduceQty.Left = btnAddQty.Left;
            pcbox.Height = 150;
            pcbox.Width = gvMain.Width;
            pcbox.Top = gvMain.Top + 70;
            pcbox.Left = gvMain.Left;
            //lblMessage.Left = pcbox.Left + pcbox.Width / 2 - lblMessage.Width;
            //lblMessage.Top = pcbox.Top + pcbox.Height / 2 - lblMessage.Height;
            lblMessage.Font=new Font("Hacen Beirut Md", 18, FontStyle.Bold);
            //lblMessage.Top = label1.Top-10;
            lblMessage.Top = txtBarcode.Top - lblMessage.Height;
            //lblMessage.Left = gvMain.Left + gvMain.Width / 2 - lblMessage.Width;
            lblMessage.Left = this.Width / 2;
            lblMessage.Text = "";

            gvMain.RowTemplate.MinimumHeight = 40;
            gvMain.EnableHeadersVisualStyles = false;
            gvMain.ColumnHeadersDefaultCellStyle.BackColor = txtCredit.BackColor;
            gvMain.ColumnHeadersDefaultCellStyle.Font = new Font("Hacen Beirut Md", 20, FontStyle.Bold);
            OpenOrClose = false;
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
       
        
        {
                if (e.KeyChar == (char)Keys.Enter && txtBarcode.Text.Trim() != string.Empty)
                {
                //اذا كان مفيش بطاقة مفتوحة
                    if (OpenOrClose == true)
                    {
                        if (UserBarcode == txtBarcode.Text.Trim())
                        {
                            SystemState(false);
                        }
                        else
                        {
                            FindItem(txtBarcode.Text.Trim());
                        }
                    }
                    //كان في بطاقة مفتوحة
                    else
                    {
                    //حط الستيت ترو
                        SystemState(true);
                    }
                }
            }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (rowIndex > -1)
            {
                DataRow foundRow = dt.Rows.Find(row.Cells[1].Value);
                if (foundRow != null)
                {
                    foundRow.Delete();
                }
                calculate();
                gvMain.DataSource = dt;
            }
        }

        private void btnAddQty_Click(object sender, EventArgs e)
        {
            if (rowIndex > -1)
            {
                DataRow foundRow = dt.Rows.Find(row.Cells[1].Value);
                if (foundRow != null)
                {
                    foundRow[3] = Convert.ToInt32(foundRow[3].ToString()) + 1;
                }
                calculate();
                gvMain.DataSource = dt;
            }
            txtBarcode.Select();
        }

        private void gvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex > -1)
            {
                row = gvMain.Rows[rowIndex];
            }
            txtBarcode.Select();
        }

        private void gvMain_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void btnReduceQty_Click(object sender, EventArgs e)
        {
            if (rowIndex > -1)
            {
                DataRow foundRow = dt.Rows.Find(row.Cells[1].Value);
                if (foundRow != null && Convert.ToInt32(foundRow[3].ToString()) > 1)
                {
                    foundRow[3] = Convert.ToInt32(foundRow[3].ToString()) - 1;
                }
                calculate();
                gvMain.DataSource = dt;
            }
            txtBarcode.Select();
        }

        private void lblMessage_TextChanged(object sender, EventArgs e)
        {
            //lblMessage.Top = label1.Top - 10;
            //lblMessage.Left = gvMain.Left + gvMain.Width / 2 - lblMessage.Width / 2;
            lblMessage.Top = txtBarcode.Top - lblMessage.Height;
            lblMessage.Left = this.Width/2;
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
