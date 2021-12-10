using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace VosemNovKA
{
    class TableMay
    {
        Connect con = new Connect();

        string[] si = new string[21];
        string[] np = new string[21];
        string[] st = new string[21];
        string[] sd = new string[21];
        string[] ar = new string[21];
        string[] mt = new string[21];
        string[] mts = new string[21];
        string[] sel = new string[21];

        DataTable DtList = new DataTable();
        DataTable dr;

        public  TableMay()
        {
            DtList.TableName = "NewTab";
            DtList.Columns.Add("id", typeof(int));
            DtList.Columns.Add("Image", typeof(string));
            DtList.Columns.Add("title", typeof(string));
            DtList.Columns.Add("Description", typeof(string));
            DtList.Columns.Add("MinCostForAgent", typeof(string));
            DtList.Columns.Add("ProductTypeID", typeof(string));
            DtList.Columns.Add("NameMaterial", typeof(string));
           
        }

        public DataTable ForList(int min1, int max1)
        {
            DtList.Clear();

            int j = 0;
            for (int i = min1; i < max1; i++)
            {

                si[j] = "SELECT Image from products_k_import where id='" + i + "'";
                np[j] = "SELECT title from products_k_import where id='" + i + "'";
                sd[j] = "SELECT Description from products_k_import where id='" + i + "'";
                st[j] = "SELECT MinCostForAgent from products_k_import where id='" + i + "'";

                
              //  int value;
              //  int.TryParse(string.Join("", con.SEL(st[j]).Where(c => char.IsDigit(c))), out value);//первый способ
                string result = Regex.Match(con.SEL(st[j]), @"\d+\.*\d").Value;//второй способ (регулярное выражение) с плавающей запятой
              //  string numericPhone = new String(con.SEL(st[j]).Where(Char.IsDigit).ToArray());//третий

                ar[j] = "SELECT ProductTypeID from products_k_import where id='" + i + "'";

                mt[j] = "SELECT pm.NameMaterial from products_k_import p, productmaterial_k_import pm " +
                    "where p.id='" + i + "' and pm.Prodykt=p.Title";

                dr = con.ConDT(mt[j]);
                foreach (DataRow dr1 in dr.Rows) mts[j] = mts[j] + "; " + dr1[0];

                //   DtList.Rows.Add(j + 1, con.SEL(si[j]), con.SEL(sd[j]), con.SEL(np[j]), con.SEL(st[j]), con.SEL(ar[j]), mts[j]);
                DtList.Rows.Add(j + 1, con.SEL(si[j]), con.SEL(sd[j]), con.SEL(np[j]), result, con.SEL(ar[j]), mts[j]);
                j++;
            }

            return DtList;
        }
    }
}
