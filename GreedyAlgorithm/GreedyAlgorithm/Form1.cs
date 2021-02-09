using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreedyAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GreedyAlgorithm(GetList());
        }


        private void GreedyAlgorithm(List<List<int>> activity)
        {
            List<int> s = new List<int> { 0, 1, 2, 3, 4, 5 };
            activity.Add(s);

            List<int> ss = new List<int>();
            for (var i = 0; i < activity[0].Count; i++)
            {
                var total = activity[0][i] + activity[1][i];
                for (var j = i; j < (activity[0].Count - 1); j++)
                {
                    var total2 = activity[0][j] + activity[1][j];
                    if (total > total2)
                    {
                        var temp1 = activity[0][i];
                        var temp2 = activity[1][i];
                        var temp3 = activity[2][i];
                        activity[0][i] = activity[0][j];
                        activity[1][i] = activity[1][j];
                        activity[2][i] = activity[2][j];
                        activity[0][j] = temp1;
                        activity[1][j] = temp2;
                        activity[2][j] = temp3;

                    }
                }

            }
            List<int> sonuc = new List<int>();
            sonuc.Add(0);
            List<List<int>> vs = new List<List<int>>();
            vs.Add(new List<int>());
            vs[0].Add(activity[0][0]);
            vs[0].Add(activity[1][0]);
            for (var j = 1; j < activity[0].Count; j++)
            {
                if (activity[0][j] >= vs[(vs.Count - 1)][1])
                {
                    var t1 = activity[0][j];
                    var t2 = activity[1][j];
                    sonuc.Add(activity[2][j]);
                    List<int> ls = new List<int>();
                    ls.Add(t1);
                    ls.Add(t2);
                    vs.Add(ls);
                }

            }


            Write(sonuc);
        }

        public List<List<int>> GetList()
        {
            List<List<int>> machines = new List<List<int>>();

            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                if (!String.IsNullOrEmpty(tb.Text))
                {
                    var list1 = tb.Text.Split(',');
                    List<int> m1 = new List<int>();

                    foreach (var item in list1)
                    {
                        m1.Add(int.Parse(item));
                    }
                    machines.Add(m1);
                }
            }
            return machines;
        }

        public void Write(List<int> result)
        {
            var sonuc = "";
            foreach (var item in result)
            {
                sonuc += "J" + item + " , ";
            }
            label4.Text = sonuc;

        }
    }
}
