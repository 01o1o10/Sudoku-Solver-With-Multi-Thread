using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form2 : Form
    {
        FileStream dosya = new FileStream("Çözümler/çözüm1.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr;

        public Form2()
        {
            InitializeComponent();
        }

        void sudokuYazdır(String sudo)
        {
            label1.Text = sudo[0].ToString();
            label2.Text = sudo[1].ToString();
            label3.Text = sudo[2].ToString();
            label4.Text = sudo[3].ToString();
            label5.Text = sudo[4].ToString();
            label6.Text = sudo[5].ToString();
            label7.Text = sudo[6].ToString();
            label8.Text = sudo[7].ToString();
            label9.Text = sudo[8].ToString();
            label10.Text = sudo[11].ToString();
            label11.Text = sudo[12].ToString();
            label12.Text = sudo[13].ToString();
            label13.Text = sudo[14].ToString();
            label14.Text = sudo[15].ToString();
            label15.Text = sudo[16].ToString();
            label16.Text = sudo[17].ToString();
            label17.Text = sudo[18].ToString();
            label18.Text = sudo[19].ToString();
            label19.Text = sudo[22].ToString();
            label20.Text = sudo[23].ToString();
            label21.Text = sudo[24].ToString();
            label22.Text = sudo[25].ToString();
            label23.Text = sudo[26].ToString();
            label24.Text = sudo[27].ToString();
            label25.Text = sudo[28].ToString();
            label26.Text = sudo[29].ToString();
            label27.Text = sudo[30].ToString();
            label28.Text = sudo[33].ToString();
            label29.Text = sudo[34].ToString();
            label30.Text = sudo[35].ToString();
            label31.Text = sudo[36].ToString();
            label32.Text = sudo[37].ToString();
            label33.Text = sudo[38].ToString();
            label34.Text = sudo[39].ToString();
            label35.Text = sudo[40].ToString();
            label36.Text = sudo[41].ToString();
            label37.Text = sudo[44].ToString();
            label38.Text = sudo[45].ToString();
            label39.Text = sudo[46].ToString();
            label40.Text = sudo[47].ToString();
            label41.Text = sudo[48].ToString();
            label42.Text = sudo[49].ToString();
            label43.Text = sudo[50].ToString();
            label44.Text = sudo[51].ToString();
            label45.Text = sudo[52].ToString();
            label46.Text = sudo[55].ToString();
            label47.Text = sudo[56].ToString();
            label48.Text = sudo[57].ToString();
            label49.Text = sudo[58].ToString();
            label50.Text = sudo[59].ToString();
            label51.Text = sudo[60].ToString();
            label52.Text = sudo[61].ToString();
            label53.Text = sudo[62].ToString();
            label54.Text = sudo[63].ToString();
            label55.Text = sudo[66].ToString();
            label56.Text = sudo[67].ToString();
            label57.Text = sudo[68].ToString();
            label58.Text = sudo[69].ToString();
            label59.Text = sudo[70].ToString();
            label60.Text = sudo[71].ToString();
            label61.Text = sudo[72].ToString();
            label62.Text = sudo[73].ToString();
            label63.Text = sudo[74].ToString();
            label64.Text = sudo[77].ToString();
            label65.Text = sudo[78].ToString();
            label66.Text = sudo[79].ToString();
            label67.Text = sudo[80].ToString();
            label68.Text = sudo[81].ToString();
            label69.Text = sudo[82].ToString();
            label70.Text = sudo[83].ToString();
            label71.Text = sudo[84].ToString();
            label72.Text = sudo[85].ToString();
            label73.Text = sudo[88].ToString();
            label74.Text = sudo[89].ToString();
            label75.Text = sudo[90].ToString();
            label76.Text = sudo[91].ToString();
            label77.Text = sudo[92].ToString();
            label78.Text = sudo[93].ToString();
            label79.Text = sudo[94].ToString();
            label80.Text = sudo[95].ToString();
            label81.Text = sudo[96].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sr = new StreamReader(dosya);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String sudo;

            sudo = sr.ReadLine();
            if (sudo != null)
            {
                sudokuYazdır(sudo);
            }
            else
            {
                timer1.Stop();
            }
        }
    }
}
