using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DDOOCP_Assignment_Summer_2019_00178090
{
    public class usercontrol
    {
        SqlConnection con;
        SqlDataAdapter ad;
        DataSet ds;
        DataTable dt;
        SqlCommand cmd;
        

        public DataTable but1(int wid)
        {
            ad = new SqlDataAdapter("select * from en where ws_Id="+wid+"", con);
            ds = new DataSet();
            ad.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }

        public usercontrol()
        {
            con = new SqlConnection("Data Source=MSI;Initial Catalog=DDOOCP;Integrated Security=True");
        }
        public string chec(string text, string temp)
        {
            string[] qeury = new string[27];
            string input = text;
            int counter = 1;
            while (counter < qeury.Length)
            {
                qeury[counter] = "select word" + counter + " from en where ws_Id=" + MainMenu.wid + " and word"+counter+"!=N'"+temp+"'";
                ad = new SqlDataAdapter(qeury[counter], con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                //foreach (DataRow row in dt.Rows)
                    if (dt.Rows.Count<2)
                    {
                        return dt.Rows[0]["word" + counter + ""].ToString();
                    }             
                counter = counter + 1;
            }
            return null;
        }
        public int insertPlayer(string p1, string p2)
        {
            cmd = new SqlCommand("insert into game (p1,p2) values ('" + p1 + "','" + p2 + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ad = new SqlDataAdapter("select gameid from game where p1='" + p1 + "' and p2='" + p2 + "'", con);
            ds = new DataSet();
            ad.Fill(ds);
            int id = (Convert.ToInt16(ds.Tables[0].Rows[0]["gameid"].ToString()));
            return id;           
        }
        public int retrieveGameID()
        {
            ad = new SqlDataAdapter("select Gameid from game order by Gameid desc", con);
            ds = new DataSet();
            ad.Fill(ds);
            return Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
        }        
        public string[] PlayerName(int id)
        {
            ad = new SqlDataAdapter("select p1,p2 from game where gameid=" + id + "", con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            string [] player = new string[2];
            player[0] = ds.Tables[0].Rows[0]["p1"].ToString();player[1] = ds.Tables[0].Rows[0]["p2"].ToString();
            return player;
        }
        public string[] showLan(int id)
        {
            ad = new SqlDataAdapter("select lan from en where ws_Id=" + id + "", con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            string[] language = new string[2];
            language[0] = ds.Tables[0].Rows[0]["lan"].ToString();language[1] = ds.Tables[0].Rows[1]["lan"].ToString();
            return language;
        }
        public DataTable sWordset()
        {
            ad = new SqlDataAdapter("select * from Wordset", con);
            ds = new DataSet();
            ad.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }
        public int updateScore(int s1, int s2, int gid, int[] gTime, int[]p1, int[] p2)
        {
            MessageBox.Show(s1 + "" + s2 + "" + gid + "" + gTime);
            cmd = new SqlCommand("update game set p1S=" + s1 + ", p2S=" + s2 + ",ws_Id="+MainMenu.wid+",gTime='" + 0 + ":" + gTime[0] + ":" + gTime[1] + "', gP1Time='" + 0 + ":" + p1[0] + ":" + p1[1] + "', gP2Time='" + 0 + ":" + p2[0] + ":" + p2[1] + "' where gameid=" + gid + "", con);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }

        public int insertWS(string wsName)
        {
            cmd = new SqlCommand("insert into Wordset values('" + wsName + "')", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            string name = wsName;
            ad = new SqlDataAdapter("select ws_id from Wordset where ws_Name='" + name + "'",con);         
            ds = new DataSet();
            ad.Fill(ds);
            dt = ds.Tables[0];
            int ret = Convert.ToInt16(dt.Rows[0]["ws_Id"].ToString());
            return ret;
        }
        public int updateWS(string wsName, int id)
        {
            cmd = new SqlCommand("update Wordset set ws_Name='" + wsName + "' where ws_Id="+id+"", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            string name = wsName;
            ad = new SqlDataAdapter("select ws_id from Wordset where ws_Name='" + name + "'", con);
            ds = new DataSet();
            ad.Fill(ds);
            dt = ds.Tables[0];
            int ret = Convert.ToInt16(dt.Rows[0]["ws_Id"].ToString());
            return ret;
        }
        public int insertWords(string []l1, string []l2, int id)
        {
            int ret=0;
            try
            {
                cmd = new SqlCommand("insert into en values ('" + l1[0] + "','" + l1[1] + "','" + l1[2] + "','" + l1[3] + "','" + l1[4] + "','" + l1[5] + "','" + l1[6] + "','" + l1[7] + "','" + l1[8] + "','" + l1[9] + "','" + l1[10] + "','" + l1[11] + "','" + l1[12] + "','" + l1[13] + "','" + l1[14] + "','" + l1[15] + "','" + l1[16] + "','" + l1[17] + "','" + l1[18] + "','" + l1[19] + "','" + l1[20] + "','" + l1[21] + "','" + l1[22] + "','" + l1[23] + "','" + l1[24] + "','" + l1[25] + "','" + l1[26] + "',"+id+"),('" + l2[0] + "','" + l2[1] + "','" + l2[2] + "','" + l2[3] + "','" + l2[4] + "','" + l2[5] + "','" + l2[6] + "','" + l2[7] + "','" + l2[8] + "','" + l2[9] + "','" + l2[10] + "','" + l2[11] + "','" + l2[12] + "','" + l2[13] + "','" + l2[14] + "','" + l2[15] + "','" + l2[16] + "','" + l2[17] + "','" + l2[18] + "','" + l2[19] + "','" + l2[20] + "','" + l2[21] + "','" + l2[22] + "','" + l2[23] + "','" + l2[24] + "','" + l2[25] + "','" + l2[26] + "',"+id+")", con);
                con.Open();
                ret =cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(NoNullAllowedException n)
            {
                MessageBox.Show(n.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }
        public int deleteWs(int id)
        {            
            ad = new SqlDataAdapter("select id from en where ws_Id=" + id + "", con);
            ds = new DataSet();
            ad.Fill(ds);
            dt = ds.Tables[0];
            cmd = new SqlCommand("delete from en where id=" + dt.Rows[0][0] + " or id=" + dt.Rows[1][0] + "", con);
            SqlCommand cmd2 = new SqlCommand("delete from wordset where ws_Id="+id+"", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                int a = cmd2.ExecuteNonQuery();
                return a;             
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            finally
            {
                con.Close();                
            }
            return 0;
        }

        public DataSet highScore2()
        {
            ad = new SqlDataAdapter("SELECT CASE WHEN  Max(p1S) >= Max(p2S) THEN max(p1S) ELSE max(p2S) END AS MostRecentDate from game where ws_id = " + 2 + "", con);
            ds = new DataSet();
            ad.Fill(ds, "1");
            ad = new SqlDataAdapter("Select Max(p1S) from game where ws_Id=" + 2 + "", con);
            ad.Fill(ds, "Fisrt Table");
            ad = new SqlDataAdapter("Select Max(p2S) from game where ws_Id=" + 2 + "", con);
            ad.Fill(ds, "Second Table");
            int p1m = Convert.ToInt16(ds.Tables[1].Rows[0][0].ToString());
            int p2m = Convert.ToInt16(ds.Tables[2].Rows[0][0].ToString());
            if (p1m > p2m)
            {
                ad = new SqlDataAdapter("select ws_Name as Wordset, p1 as Player, p1S as Score,gTime as Total_Time, gP1Time as Player_Time from game, Wordset where p1S=" + p1m + " and game.ws_Id=Wordset.ws_Id", con);
                ad.Fill(ds, "3");
            }
            else
            {
                ad = new SqlDataAdapter("select ws_Name as Wordset, p2 as Player, p2s as Score,gTime as Total_Time, gP2Time as Player_Time from game, Wordset where p2S=" + p2m + " and game.ws_Id=Wordset.ws_Id", con);
                ad.Fill(ds, "3");
            }
            Convert.ToInt16(ds.Tables[2].Rows[0][0].ToString());
            return ds;
        }

        public DataSet highScore3()
        {
            ad = new SqlDataAdapter("SELECT CASE WHEN  Max(p1S) >= Max(p2S) THEN max(p1S) ELSE max(p2S) END AS MostRecentDate from game where ws_id = " + 7 + "", con);
            ds = new DataSet();
            ad.Fill(ds, "1");
            ad = new SqlDataAdapter("Select Max(p1S) from game where ws_Id=" + 7 + "", con);
            ad.Fill(ds, "Fisrt Table");
            ad = new SqlDataAdapter("Select Max(p2S) from game where ws_Id=" + 7 + "", con);
            ad.Fill(ds, "Second Table");
            int p1m = Convert.ToInt16(ds.Tables[1].Rows[0][0].ToString());
            int p2m = Convert.ToInt16(ds.Tables[2].Rows[0][0].ToString());
            if (p1m > p2m)
            {
                ad = new SqlDataAdapter("select ws_Name as Wordset, p1 as Player, p1s as Score,gTime as Total_Time, gp1Time as Player_Time from game,Wordset where p1S=" + p1m + " and game.ws_Id=Wordset.ws_Id", con);
                ad.Fill(ds, "3");
            }
            else
            {
                ad = new SqlDataAdapter("select ws_Name as Wordset,p2 as Player,p2s as Score,gTime as Total_Time, gP2Time as Player_Time from game, Wordset where p2S=" + p2m + " and game.ws_Id=Wordset.ws_Id", con);
                ad.Fill(ds, "3");
            }
            Convert.ToInt16(ds.Tables[2].Rows[0][0].ToString());
            return ds;
        }
        public DataSet highScore1()
        {
            ad = new SqlDataAdapter("SELECT CASE WHEN  Max(p1S) >= Max(p2S) THEN max(p1S) ELSE max(p2S) END AS MostRecentDate from game where ws_id = " + 1 + "", con);
            ds = new DataSet();
            ad.Fill(ds, "1");
            ad = new SqlDataAdapter("Select Max(p1S) from game where ws_Id="+1+"", con);
            ad.Fill(ds,"Fisrt Table");
            ad = new SqlDataAdapter("Select Max(p2S) from game where ws_Id="+1+"", con);
            ad.Fill(ds,"Second Table");
            int p1m = Convert.ToInt16(ds.Tables[1].Rows[0][0].ToString());
            int p2m = Convert.ToInt16(ds.Tables[2].Rows[0][0].ToString());
            if (p1m>p2m)
            {
                ad = new SqlDataAdapter("select ws_Name as Wordset, p1 as Player, p1S as Score,gTime as Total_Time, gP1Time as Player_Time from game,Wordset where p1S="+p1m+" and game.ws_Id=Wordset.ws_Id", con);
                ad.Fill(ds,"3");
            }
            else
            {
                ad = new SqlDataAdapter("select ws_Name as Wordset, p2 as Player,p2s as Score,gTime as Total_Time,gP2Time as Player_Time from game, Wordset where p2S=" + p2m + " and game.ws_Id=Wordset.ws_Id", con);
                ad.Fill(ds, "3");
            }
            Convert.ToInt16(ds.Tables[2].Rows[0][0].ToString());
            return ds;
        }
        public DataTable viewAll()
        {
            ad = new SqlDataAdapter("select w.ws_name as WordSet,e.lan as Language, e.word1, e.word2, e.word3, e.word4, e.word5, e.word6,e.word7,e.word8,e.word9,e.word10,e.word11,e.word12,e.word13,e.word14,e.word15,e.word16,e.word17,e.word18,e.word19,e.word20,e.word21,e.word22,e.word23,e.word24,e.word25,e.word26 from en as e, Wordset as w where e.ws_Id=w.ws_Id", con);
            ds = new DataSet();
            ad.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }
        public int updateWords(string []l1, string[]l2, int id)
        {
            int ret=0;
            SqlCommand cmd2;         

            ad = new SqlDataAdapter("select * from en where ws_Id=" + id + "", con);
            DataSet ds = new DataSet();
            ad.Fill(ds);            
            int id1; int id2;
            id1 = Convert.ToInt16(ds.Tables[0].Rows[0]["id"].ToString());
            id2 = Convert.ToInt16(ds.Tables[0].Rows[1]["id"].ToString());
            cmd = new SqlCommand("update en set lan='" + l1[0] + "', word1='" + l1[1] + "' , word2='" + l1[2] + "', word3='" + l1[3] + "', word4='" + l1[4] + "', word5='" + l1[5] + "', word6='" + l1[6] + "', word7='" + l1[7] + "', word8='" + l1[8] + "', word9='" + l1[9] + "', word10='" + l1[10] + "', word11='" + l1[11] + "', word12='" + l1[12] + "', word13='" + l1[13] + "', word14='" + l1[14] + "', word15='" + l1[15] + "', word16='" + l1[16] + "', word17='" + l1[17] + "', word18='" + l1[18] + "', word19='" + l1[19] + "', word20='" + l1[20] + "', word21='" + l1[21] + "', word22='" + l1[22] + "', word23='" + l1[23] + "', word24='" + l1[24] + "', word25='" + l1[25] + "', word26='" + l1[26] + "' where id=" + id1 + "", con);
            cmd2= new SqlCommand("update en set lan='" + l2[0] + "', word1='" + l2[1] + "' , word2='" + l2[2] + "', word3='" + l2[3] + "', word4='" + l2[4] + "', word5='" + l2[5] + "', word6='" + l2[6] + "', word7='" + l2[7] + "', word8='" + l2[8] + "', word9='" + l2[9] + "', word10='" + l2[10] + "', word11='" + l2[11] + "', word12='" + l2[12] + "', word13='" + l2[13] + "', word14='" + l2[14] + "', word15='" + l2[15] + "', word16='" + l2[16] + "', word17='" + l2[17] + "', word18='" + l2[18] + "', word19='" + l2[19] + "', word20='" + l2[20] + "', word21='" + l2[21] + "', word22='" + l2[22] + "', word23='" + l2[23] + "', word24='" + l2[24] + "', word25='" + l2[25] + "', word26='" + l2[26] + "' where id=" + id2 + "", con);
            try {
                con.Open();
                cmd.ExecuteNonQuery();
                ret=cmd2.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }
        public DataTable selectAllLan(int id)
        {
            ad = new SqlDataAdapter("select * from en where ws_id=" + id + "", con);
            ds = new DataSet();
            ad.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }
    }
}
