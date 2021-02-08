using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalmerSezgiselAlgoritma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void PalmerCalc_Click(object sender, EventArgs e)
        {
            var machines = GetList();

            List<int> sirali = new List<int>();

            List<List<int>> matrix = new List<List<int>>();
            for (var j = 0; j < machines[0].Count; j++)
            {
                var total = 0;
                for (var i = 0; i < machines.Count; i++)
                {
                    total += (3 - (2 * (i + 1) - 1)) * machines[i][j];
                }
                matrix.Add(new List<int>()); //Adds new sub List
                matrix[j].Add((j + 1)); //Add values to the sub List at index 0
                matrix[j].Add(((-1) * total));


            }

            for (var i = 0; i < matrix.Count; i++)
            {
                var min = i;
                for (var j = i + 1; j < matrix.Count; j++)
                {
                    if (matrix[min][1] < matrix[j][1])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    var sira = (matrix[min][0]);
                    var lowerValue = matrix[min][1];
                    var lowerValue1 = matrix[min][0];
                    matrix[min][1] = matrix[i][1];
                    matrix[min][0] = matrix[i][0];
                    matrix[i][1] = lowerValue;
                    matrix[i][0] = lowerValue1;
                    sirali.Add(sira);
                }
                else
                {
                    sirali.Add((matrix[i][0]));

                }
            }


            Write(sirali);

        }

        private void Add_Click(object sender, EventArgs e)
        {
            var txtRun = new TextBox();
            int count = this.Controls.OfType<TextBox>().ToList().Count; //Ekranda textbox sayısını buluyor
            txtRun.Location = new System.Drawing.Point(122, 40 * count); //Ekrana yerleştirieceğei konumu ayaralıyo
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
                if (tb.Name != "textBox2" & tb.Name != "textBox1")
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

        public void Write(List<int> result)
        {
            var sonuc = "";
            foreach (var item in result)
            {
                sonuc += "J" + item + " , ";
            }
            label5.Text = sonuc;

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
    }
}
