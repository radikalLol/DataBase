using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication10
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipperSSDataSet.Quality". При необходимости она может быть перемещена или удалена.
            this.qualityTableAdapter.Fill(this.shipperSSDataSet.Quality);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipperSSDataSet.TimeOFDelivery". При необходимости она может быть перемещена или удалена.
            this.timeOFDeliveryTableAdapter.Fill(this.shipperSSDataSet.TimeOFDelivery);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipperSSDataSet.ShipperS". При необходимости она может быть перемещена или удалена.
            this.shipperSTableAdapter.Fill(this.shipperSSDataSet.ShipperS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipperSSDataSet.ReliabilityOfDelivery". При необходимости она может быть перемещена или удалена.
            this.reliabilityOfDeliveryTableAdapter.Fill(this.shipperSSDataSet.ReliabilityOfDelivery);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipperSSDataSet.PriceList". При необходимости она может быть перемещена или удалена.
            this.priceListTableAdapter.Fill(this.shipperSSDataSet.PriceList);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipperSSDataSet.LocationOFSuppliers". При необходимости она может быть перемещена или удалена.
            this.locationOFSuppliersTableAdapter.Fill(this.shipperSSDataSet.LocationOFSuppliers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipperSSDataSet.CriteriasOfChoice". При необходимости она может быть перемещена или удалена.
            this.criteriasOfChoiceTableAdapter.Fill(this.shipperSSDataSet.CriteriasOfChoice);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipperSSDataSet.ShippersPoints". При необходимости она может быть перемещена или удалена.
            this.shippersPointsTableAdapter.Fill(this.shipperSSDataSet.ShippersPoints);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipperSSDataSet.ReferenceData". При необходимости она может быть перемещена или удалена.
            this.referenceDataTableAdapter.Fill(this.shipperSSDataSet.ReferenceData);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void referenceDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.referenceDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.shipperSSDataSet);

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int LocationCheck;
            int PriceCheck;
            int ReliabilityCheck;
            int TimeCheck;
            int QualityCheck;

            if (checkBox1.Checked)
            {
                LocationCheck = 1;
            }

            else
            {
                LocationCheck = 0;
            }

            if (checkBox2.Checked)
            {
                PriceCheck = 1;
            }

            else
            {
                PriceCheck = 0;
            }

            if (checkBox3.Checked)
            {
                ReliabilityCheck = 1;
            }

            else
            {
                ReliabilityCheck = 0;
            }

            if (checkBox4.Checked)
            {
                TimeCheck = 1;
            }

            else
            {
                TimeCheck = 0;
            }

            if (checkBox5.Checked)
            {
                QualityCheck = 1;
            }

            else
            {
                QualityCheck = 0;
            }



            float max1 = 0;
            float max2 = 0;
            float max3 = 0;

            string a1 = "";
            string a2 = "";
            string a3 = "";

            //string LocSup = ""; // цифры для счета 
            string Quality = "";     // но они все в стрингах
                                     // string Price = "";
            string Delivery = "";
            //string Time = "";
            //string ID = "";
            string PrintID = "";
            string ComName = "";

            int[] LocSupPoints = new int[10]; //не знала, как будет удобнее, вот поинты в массивах. За ненадобностью можно удалить
            string[] QualityPoints = { }; //массив представлен так: К примеру, Поинты за цену равны 12345,
            int[] PricePoints = new int[10]; //тогда PricePoints[0] = 1, PricePoints[1] = 2 и т.д.
            string[] DeliveryPoints = { };
            int[] TimePoints = new int[10];
            int[] Shippers_id = new int[10];
            string[] CompanyName = { };

            int i = 0;
            int[] Ppoints = new int[10];
            int[] QPoints = new int[10];
            int[] LPoints = new int[10];
            int[] TPoints = new int[10];
            int[] DPoints = new int[10];

            float[] ShipperPoints = new float[10];
            //подключениек БД, при ошибках подключения на своем компе, первое,что стоит менять!!!!
            //SSPI значит проверка подлинности Windows
            string connectingString = "Data Source = .\\SQLEXPRESS; Initial Catalog = ShipperSS; Integrated Security=SSPI;";
            //Подключение к БД через один из классов С#
            SqlConnection myConnection = new SqlConnection(connectingString);

            //Соединение открывается
            myConnection.Open();

            //выбирается столбик из какой-либо таблицы
            string sqlName = "SELECT CompanyName FROM ReferenceData";

            //    string sql1 = "SELECT Points FROM PriceList ";              // КУЧА ОБЪЯВЛЕНИЙИ СИНТАКСИСОВ

            //  string sql2 = "SELECT HighQuality FROM Quality";
            //string sql22 = "SELECT MediumQuality FROM Quality";   //ВСЕ ПРИНАДЛЕЖИТ ОДНОЙ ТАБЛИЦЕ КВОЛАТЕ
            // string sql222 = "SELECT LowQuality FROM Quality";

            //string sql3 = "SELECT MissionCompleted FROM ReliabilityOfDelivery";    // все принадлежит доставке
            // string sql33 = "SELECT MissionIncompleted FROM ReliabilityOfDelivery";

            //  string sql4 = "SELECT Points FROM TimeOFDelivery";
            string sqlPrice = "SELECT Pricelist FROM ReferenceData";
            string sqlQuality = "SELECT Quality FROM ReferenceData";
            string sqlLocSup = "SELECT LocationOfSuppliers FROM ReferenceData";
            string sqlDelivery = "SELECT ReliabilityOfDelivery FROM ReferenceData";
            string sqlTime = "SELECT TimeOfDelivery FROM ReferenceData";
            string sqlid = "SELECT ID FROM ReferenceData";
            string sqlname = "SELECT FName FROM Shippers";

            //Передаем парамерты в констуктор 
            SqlCommand command = new SqlCommand(sqlName, myConnection);
            SqlCommand commandPrice = new SqlCommand(sqlPrice, myConnection);
            SqlCommand commandQual = new SqlCommand(sqlQuality, myConnection);
            SqlCommand commandLoc = new SqlCommand(sqlLocSup, myConnection);
            SqlCommand commandDelivery = new SqlCommand(sqlDelivery, myConnection);
            SqlCommand commandTime = new SqlCommand(sqlTime, myConnection);

            //  SqlCommand command1 = new SqlCommand(sql1, myConnection);

            // SqlCommand command2 = new SqlCommand(sql2, myConnection);     //передаем параметры в спец класс шарпея
            //  SqlCommand command22 = new SqlCommand(sql22, myConnection);
            //    SqlCommand command222 = new SqlCommand(sql222, myConnection);

            // SqlCommand command3 = new SqlCommand(sql3, myConnection);
            //  SqlCommand command33 = new SqlCommand(sql33, myConnection);

            //   SqlCommand command4 = new SqlCommand(sql4, myConnection);

            SqlCommand commandid = new SqlCommand(sqlid, myConnection);
            SqlCommand commandName = new SqlCommand(sqlname, myConnection);

            //читаем данные из поинтов, благодаря методу из класса ридера 
            SqlDataReader reader = command.ExecuteReader();
            //цикл чтения
            while (reader.Read()) //пока не прочтем данные, продолжаем цикл
                                  //нужен очень,чтобы читал все строчки
            {
                string a = reader[0].ToString();//сохраняем поинты LocationOFSuppliers
                ComName += a + ',';
            }
            CompanyName = ComName.Split(',');// ПРЕОБРАЗОВАНИЕ ИЗ СТРОКИ В МАССИВ, ОНО ТУТ
            reader.Close();                       //КУЧА ЦИКЛОВ НЕТ ВРЕМЕНИ ОПТИМИЗИРОВАТЬ ИЗВИНИ БОГА РАДИ 

            SqlDataReader reader1 = commandPrice.ExecuteReader();
            while (reader1.Read())
            {
                string a = reader1[0].ToString();
                int Price = int.Parse(a);
                PricePoints[i] = Price;
                i++;
            }

            reader1.Close();

            SqlDataReader reader2 = commandQual.ExecuteReader();
            while (reader2.Read())
            {
                string a = reader2[0].ToString();
                Quality += a + ',';
                QualityPoints = Quality.Split(',');
            }
            reader2.Close();

            i = 0;
            SqlDataReader reader3 = commandLoc.ExecuteReader();
            while (reader3.Read())
            {
                string a = reader3[0].ToString();
                a = a.Trim(' ', 'к', 'м');
                int LocSup = int.Parse(a);
                LocSupPoints[i] = LocSup;
                i++;
            }
            reader3.Close();


            SqlDataReader reader4 = commandDelivery.ExecuteReader();
            while (reader4.Read())
            {
                string a = reader4[0].ToString();
                Delivery += a + ',';
                DeliveryPoints = Delivery.Split(',');
            }
            reader4.Close();

            int d = 0;
            SqlDataReader reader5 = commandTime.ExecuteReader();
            while (reader5.Read())
            {
                string a = reader5[0].ToString();
                string[] v = a.Split(' ');
                a = v[0];
                int Time = int.Parse(a);
                TimePoints[d] = Time;
                d++;
            }
            reader5.Close();
            /*     SqlDataReader reader2 = command2.ExecuteReader(); //ЧИТАЕМ СОХРАНЯЕМ СЕБЯ ПОКАЗЫВАЕМ HIGHT QUALITY

                  while (reader2.Read())
                  {
                      string b = reader2[0].ToString();
                      Quality += b;
                  }
                  reader2.Close(); //всегда закрываем ридер



                  SqlDataReader reader22 = command22.ExecuteReader(); // Сохранение Medium кволети
                  while (reader22.Read())
                  {
                      string b = reader22[0].ToString();
                      Quality += b;
                  }
                  reader22.Close();  // функция закрытия ридера,обезательная, всегда закрывать


                  SqlDataReader reader222 = command222.ExecuteReader(); //сохраняет лов кволэти
                  while (reader222.Read())
                  {
                      string b = reader222[0].ToString();
                      Quality += b;
                  }
                  reader222.Close(); //ВСЕГДА!!
                  QualityPoints = (from val in Quality select (int)(val - '0')).ToArray();//конвертирование из стрингов в массив





                  SqlDataReader reader1 = command1.ExecuteReader();  // опять циклсохранения, но уже поинтов на прайс

                  while (reader1.Read())
                  {
                      string c = reader1[0].ToString();
                      Price += c;
                  }
                  reader1.Close();

                  PricePoints = (from val in Price select (int)(val - '0')).ToArray(); //Массив чисел цен чо



                  SqlDataReader reader3 = command3.ExecuteReader();  // Посылка доставлена

                  while (reader3.Read())
                  {
                      string a = reader3[0].ToString();
                      Delivery += a;
                  }
                  reader3.Close();

                  SqlDataReader reader33 = command33.ExecuteReader();  // не доставлена

                  while (reader33.Read())
                  {
                      string c = reader33[0].ToString();
                      Delivery += c;
                  }
                  reader33.Close();

                  DeliveryPoints = (from val in Delivery select (int)(val - '0')).ToArray(); //конверт



                  SqlDataReader reader4 = command4.ExecuteReader();  //цикломарока с доставкой

                  while (reader4.Read())
                  {
                      string c = reader4[0].ToString();
                      Time += c;
                  }
                  reader4.Close();
                  TimePoints = (from val in Time select (int)(val - '0')).ToArray();

                  //Console.WriteLine("ddd"); */
            i = 0;
            SqlDataReader readerid = commandid.ExecuteReader();  //цикломарока с доставкой 

            while (readerid.Read())
            {
                string c = readerid[0].ToString();
                int ID = int.Parse(c);
                Shippers_id[i] = ID;
                i++;
            }
            readerid.Close();


            int comi = CompanyName.Length;

            for (int f = 0; f < comi; f++)
            {

                if (PricePoints[f] <= 5000 & PricePoints[f] >= 1000)
                {
                    Ppoints[f] = 5;
                }

                if (PricePoints[f] <= 10000 & PricePoints[f] > 5000)
                {
                    Ppoints[f] = 4;
                }

                if (PricePoints[f] <= 15000 & PricePoints[f] > 10000)
                {
                    Ppoints[f] = 3;
                }

                if (PricePoints[f] <= 20000 & PricePoints[f] > 15000)
                {
                    Ppoints[f] = 2;
                }

                if (PricePoints[f] <= 25000 & PricePoints[f] > 20000)
                {
                    Ppoints[f] = 1;
                }

                if (QualityPoints[f] == "Высокое")
                {
                    QPoints[f] = 5;
                }

                if (QualityPoints[f] == "Среднее")
                {
                    QPoints[f] = 3;
                }

                if (QualityPoints[f] == "Низкое")
                {
                    QPoints[f] = 1;
                }

                if (LocSupPoints[f] > 0 & LocSupPoints[f] <= 100)
                {
                    LPoints[f] = 5;
                }

                if (LocSupPoints[f] >= 300 & LocSupPoints[f] <= 450)
                {
                    LPoints[f] = 4;
                }

                if (LocSupPoints[f] >= 550 & LocSupPoints[f] <= 600)
                {
                    LPoints[f] = 3;
                }

                if (LocSupPoints[f] >= 1000 & LocSupPoints[f] <= 2500)
                {
                    LPoints[f] = 2;
                }

                if (LocSupPoints[f] >= 3000 & LocSupPoints[f] <= 5000)
                {
                    LPoints[f] = 1;
                }

                if (DeliveryPoints[f] == "Выполнено")
                {
                    DPoints[f] = 5;
                }

                if (DeliveryPoints[f] == "Не выполнено")
                {
                    DPoints[f] = 1;
                }

                if (TimePoints[f] <= 4 & TimePoints[f] >= 3)
                {
                    TPoints[f] = 5;
                }

                if (TimePoints[f] <= 7 & TimePoints[f] > 4)
                {
                    TPoints[f] = 4;
                }

                if (TimePoints[f] <= 10 & TimePoints[f] > 7)
                {
                    TPoints[f] = 3;
                }

                if (TimePoints[f] <= 14 & TimePoints[f] > 10)
                {
                    TPoints[f] = 2;
                }

                if (TimePoints[f] > 14)
                {
                    TPoints[f] = 1;
                }

                ShipperPoints[f] = LocationCheck * LPoints[f] + PriceCheck * Ppoints[f]
                    + ReliabilityCheck * DPoints[f] + TimeCheck * TPoints[f] + QualityCheck * QPoints[f];

                SqlCommand SAVESQL = new SqlCommand("INSERT INTO ShippersPoints (LocationOFSuppliers,PriceList,Quality,"
                + "ReliabilityOfDelivery,TimeOFDelivery,SipperS) VALUES (@LocationOFSuppliers,@PriceList,@Quality,"
                + "@ReliabilityOfDelivery,@TimeOFDelivery,@SipperS)", myConnection);


                SAVESQL.Parameters.Add("@LocationOFSuppliers", SqlDbType.VarChar, 250).Value = LPoints[f].ToString();
                SAVESQL.Parameters.Add("@Quality", SqlDbType.VarChar, 250).Value = QPoints[f].ToString();
                SAVESQL.Parameters.Add("@PriceList", SqlDbType.VarChar, 250).Value = Ppoints[f].ToString();
                SAVESQL.Parameters.Add("@SipperS", SqlDbType.VarChar, 250).Value = CompanyName[f];
                SAVESQL.Parameters.Add("@ReliabilityOfDelivery", SqlDbType.VarChar, 250).Value = DPoints[f].ToString();
                SAVESQL.Parameters.Add("@TimeOFDelivery", SqlDbType.VarChar, 250).Value = TPoints[f].ToString();

                SAVESQL.ExecuteNonQuery();
                if (ShipperPoints[f] > max1)
                {
                    max3 = max2;
                    a3 = a2;
                    max2 = max1;
                    a2 = a1;
                    max1 = ShipperPoints[f];
                    a1 = CompanyName[f];
                }
                else if (ShipperPoints[f] > max2)
                {
                    max3 = max2;
                    a3 = a2;
                    max2 = ShipperPoints[f];
                    a2 = CompanyName[f];
                }
                else if (ShipperPoints[f] > max3)
                {
                    max3 = ShipperPoints[f];
                    a3 = CompanyName[f];
                }
            }

            SqlCommand SAVESQL1 = new SqlCommand("INSERT INTO CriteriasOfChoice(Criterias1,Criterias2,Criterias3)" +
                     "VALUES (@Criterias1,@Criterias2,@Criterias3)", myConnection);


            SAVESQL1.Parameters.Add("@Criterias1", SqlDbType.VarChar, 250).Value = a1 + ": " + max1.ToString();
            SAVESQL1.Parameters.Add("@Criterias2", SqlDbType.VarChar, 250).Value = a2 + ": " + max2.ToString();
            SAVESQL1.Parameters.Add("@Criterias3", SqlDbType.VarChar, 250).Value = a3 + ": " + max3.ToString();


            SAVESQL1.ExecuteNonQuery();

            // Сохранение, или вывод
            // SqlCommand SAVESQL = new SqlCommand("INSERT INTO ShippersPoints (LocationOFSuppliers,PriceList,Quality,"
            //    + "ReliabilityOfDelivery,TimeOFDelivery,SipperS) VALUES (@PriceList,@Quality,@SipperS," +
            //   "@LocationOFSuppliers,@ReliabilityOfDelivery,@TimeOFDelivery)", myConnection); //подлючение к бд,
            // подобное ты могда видеть ранее в коде. Единственное отличие: инсерт и указание на таблицу
            //это сделано онли лени ради,чтобы не расписывать как в начале, переписывать нормально начало
            //тоже лень 



            //здесь передаются параметры. Указывается столбец, тип данные и значение(Value)
            //в данном случае Value = 0
            // SAVESQL.Parameters.Add("@LocationOFSuppliers", SqlDbType.VarChar, 250).Value = 0;
            // SAVESQL.Parameters.Add("@Quality", SqlDbType.VarChar, 250).Value = 0;
            //  SAVESQL.Parameters.Add("@SipperS", SqlDbType.VarChar, 250).Value = 0;
            //  SAVESQL.Parameters.Add("@PriceList", SqlDbType.VarChar, 250).Value = 0;
            //  SAVESQL.Parameters.Add("@ReliabilityOfDelivery", SqlDbType.VarChar, 250).Value = 0;
            //  SAVESQL.Parameters.Add("@TimeOFDelivery", SqlDbType.VarChar, 250).Value = 0;

            //  SAVESQL.ExecuteNonQuery(); //хз для чего, без этого не робит

            myConnection.Close();
        }
    }
}
