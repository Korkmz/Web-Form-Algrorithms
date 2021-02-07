using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithms
{
    public partial class JohnsonAlgorithm : Form
    {
        public JohnsonAlgorithm()
        {
            InitializeComponent();
        }

        private void JohnsonCal_Click(object sender, EventArgs e)
        {
            var machines = GetList();  //Ekranda Girilen İnput lar iş parcacikları liste olar döndürür.

            List<int> result = JohnsonAlgrithm(machines); //Johnson alg. hesaplar sonucu döndürür.

            Write(result);  //sonucu ekrana yazdırırç
        }


        public List<List<int>> GetList() //Ekranda Girilen İnput lar iş parcacikları listeye ekler
        {
            List<List<int>> machines = new List<List<int>>();

            foreach (TextBox tb in this.Controls.OfType<TextBox>()) //Ekrandaki Tüm inputları for döngüsüne koyar
            {
                if (!String.IsNullOrEmpty(tb.Text))
                {
                    var list1 = tb.Text.Split(',');//input lardaki virgüllerle ayrılımış iş parcacıklarını alır.
                    List<int> m1 = new List<int>();

                    foreach (var item in list1)
                    {
                        m1.Add(int.Parse(item)); //Makineye ekler
                    }
                    machines.Add(m1);
                }
            }
            return machines;//Alınan makineyi geri döndürür.
        }


        public List<int> JohnsonAlgrithm(List<List<int>> machines)
        {
            #region İki Makineye indirgeme yapıyor
            List<int> AA = new List<int>();
            for (var y = 0; y < machines[0].Count; y++)
            {
                var total = 0;
                for (var t = 0; t < machines.Count() - 1; t++)
                {
                    total += machines[t][y];   //machines[0][0]  machines[1][0]
                }
                AA.Add(total);
            }
            List<int> BB = new List<int>();
            for (var t = 0; t < machines[0].Count(); t++)
            {
                var total = 0;
                for (var y = 1; y < machines.Count; y++)
                {
                    total += machines[y][t];
                }
                BB.Add(total);

            }
            #endregion


            var listCount = AA.Count;

            List<int> L1 = new List<int>();
            List<int> L2 = new List<int>();


            List<int> m11 = new List<int>(AA);
            List<int> m22 = new List<int>(BB);

            for (var x = 0; x < listCount; x++)
            {
                var newList2 = L1.Concat(L2);
                var makine1 = m11.Min(); //Makine 1 deki en küçük değer
                var makine2 = m22.Min(); //Makine 2 deki en küçük değer
                if (makine1 < makine2)   
                {
                    var indexNo = m11.IndexOf(makine1);
                    var pNo = AA.IndexOf(makine1);
                    m11.RemoveAt(indexNo);
                    m22.RemoveAt(indexNo);
                    #region Eger Diziye eklenmişse bu sayı 
                    var sayac = 0;
                    foreach (var item in newList2)
                    {
                        if (item == (pNo + 1))
                        {
                            sayac++;
                        }
                    }
                    if (sayac != 0) pNo = AA.IndexOf(makine1, (pNo + 1));
                    #endregion
                    L1.Add((pNo + 1)); //makine1
                }
                else
                {
                    var indexNo = m22.IndexOf(makine2);
                    var pNo = BB.IndexOf(makine2);
                    m11.RemoveAt(indexNo);
                    m22.RemoveAt(indexNo);
                    #region Eger Diziye eklenmişse bu sayı 
                    var sayac = 0;
                    foreach (var item in newList2)
                    {
                        if (item == (pNo + 1))
                        {
                            sayac++;
                        }
                    }
                    if (sayac != 0) pNo = BB.IndexOf(makine2, (pNo + 1));
                    #endregion
                    L2.Insert(0, (pNo + 1));//makine2

                }
            }

            L1.AddRange(L2); //L1 makinesinde birleştiriyor
            return L1;


        }


        public void Write(List<int> result)
        {
            var sonuc = "";
            foreach (var item in result)
            {
                sonuc += "J" + item + " , ";
            }

            label4.Text = sonuc; //Sonucu Ekrana Yazdırır.
        }
     
        
        private void Add_Click(object sender, EventArgs e) //Satır ekleme yapıyor(input ekliyor)
        {
            var txtRun = new TextBox();
            int count = this.Controls.OfType<TextBox>().ToList().Count; //Ekranda textbox sayısını buluyor
            txtRun.Location = new System.Drawing.Point(122, 40 * count); //Ekrana yerleştirieceğei konumu ayaralıyor
            txtRun.Size = new System.Drawing.Size(128, 22);    //Textbox boyutunu ayarlıyor 


            var lblRun = new Label();
            lblRun.Text = (count + 1) + ". Machine";
            lblRun.Name = "machine";
            lblRun.Location = new System.Drawing.Point(50, 40 * count);

            this.Controls.Add(txtRun);
            this.Controls.Add(lblRun);
        }


        private void Clear_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                if (tb.Name != "textBox2" & tb.Name != "textBox1") //İlk 2 makine (input) silinemez!
                {
                    tb.Clear();
                    this.Controls.Remove(tb);
                    tb.Dispose();
                }

            }
            textBox1.Text = "";
            textBox2.Text = "";
            foreach (Label tb in this.Controls.OfType<Label>())
            {
                if (tb.Name == "machine")
                {
                    this.Controls.Remove(tb);
                    tb.Dispose();
                }

            }
        }



    }
}
