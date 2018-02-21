using System;
using System.Threading;
using System.IO;
using System.Diagnostics;
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
    public partial class SudokuÇöz : Form
    {
        Stopwatch sure = new Stopwatch();
        int[,] sudoku = new int[9, 9];
        int[,] sudoku1 = new int[9, 9];
        int[,] sudoku2 = new int[9, 9];
        int[,] sudoku3 = new int[9, 9];
        Thread tred1;
        Thread tred2;
        Thread tred3;
        
        FileStream dosya1 = new FileStream("Çözümler/çözüm1.txt", FileMode.Create, FileAccess.Write);
        StreamWriter writer1;
        FileStream dosya2 = new FileStream("Çözümler/çözüm2.txt", FileMode.Create, FileAccess.Write);
        StreamWriter writer2;
        FileStream dosya3 = new FileStream("Çözümler/çözüm3.txt", FileMode.Create, FileAccess.Write);
        StreamWriter writer3;

        public SudokuÇöz()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void dosyaAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sudo;
            int sayac = 0;
            int i, j;
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    sudoku[i, j] = 0;
                }
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Dosyası|*.txt";
            ofd.ShowDialog();

            try
            {
                FileStream dosya = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(dosya);
                sudo = reader.ReadToEnd();
                sudo = sudo.Replace('*', ' ');

                for (i = 0; i < 9; i++)
                {
                    for (j = 0; j < 9; j++)
                    {
                        if (sudo[sayac] != ' ')
                        {
                            sudoku[i, j] = (int)Char.GetNumericValue(sudo[sayac]);
                        }
                        sayac++;
                    }
                    sayac += 2;
                }
                dosya.Close();

                sudokuYazdır(sudo);
                sudokuCoz.Enabled = true;

                matrisKopyala(i, sudoku1);
                matrisKopyala(i, sudoku2);
                matrisKopyala(i, sudoku3);
            }
            catch (Exception)
            {
                //bos...
            }
        }
        
        void matrisKopyala(int a, int[,] sudoku)
        {
            int i, j;
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    sudoku[i, j] = this.sudoku[i, j];
                }
            }
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

        private void sudokuCoz_Click(object sender, EventArgs e)
        {
            writer1 = new StreamWriter(dosya1);
            writer2 = new StreamWriter(dosya2);
            writer3 = new StreamWriter(dosya3);

            tred1 = new Thread(work1);
            tred2 = new Thread(work2);
            tred3 = new Thread(work3);

            sure.Start();
            tred1.Start();
            tred2.Start();
            tred3.Start();
        }

        void work1()
        {
            sudokuÇöz1(0, 0);
        }

        void work2()
        {
            sudokuÇöz2(3, 0);
        }

        void work3()
        {
            sudokuÇöz3(6, 0);
        }

        void sudokuÇöz1(int i, int j)
        {
            int a, b, rakam;
            bool durum = true;
            String sudo;

            sudo = stringeAl(sudoku1);
            writer1.WriteLine(sudo);

            for (a = 0; a < 9; a++)
            {
                for (b = 0; b < 9; b++)
                {
                    if (sudoku1[a, b] == 0)
                    {
                        durum = false;
                    }
                }
            }
            if (durum == true)
            {
                sure.Stop();
                tred2.Abort();
                tred3.Abort();
                writer1.Close();
                writer2.Close();
                writer3.Close();
                dosya1.Close();
                dosya2.Close();
                dosya3.Close();
                sudo = stringeAl(sudoku1);
                sudokuTamam(durum, 1, sudo);
                tred1.Abort();
            }
            if (sudoku1[i, j] == 0)
            {
                for (rakam = 1; rakam < 10; rakam++)
                {
                    if (uygunMu(i, j, rakam, sudoku1))
                    {
                        sudoku1[i, j] = rakam;
                        if (j < 8)
                        {
                            sudokuÇöz1(i, j + 1);
                        }
                        else if (i < 8)
                        {
                            sudokuÇöz1(i + 1, 0);
                        }
                        else
                        {
                            sudokuÇöz1(0, 0);
                        }
                        sudoku1[i, j] = 0;
                    }
                }
            }
            else
            {
                if (j < 8)
                {
                    sudokuÇöz1(i, j + 1);
                }
                else if (i < 8)
                {
                    sudokuÇöz1(i + 1, 0);
                }
                else
                {
                    sudokuÇöz1(0, 0);
                }
            }
        }

        void sudokuÇöz2(int i, int j)
        {
            int a, b, rakam;
            bool durum = true;
            String sudo;

            sudo = stringeAl(sudoku2);
             writer2.WriteLine(sudo);

            for (a = 0; a < 9; a++)
            {
                for (b = 0; b < 9; b++)
                {
                    if (sudoku2[a, b] == 0)
                    {
                        durum = false;
                    }
                }
            }
            if (durum == true)
            {
                sure.Stop();
                tred1.Abort();
                tred3.Abort();
                writer1.Close();
                writer2.Close();
                writer3.Close();
                dosya1.Close();
                dosya2.Close();
                dosya3.Close();
                sudo = stringeAl(sudoku2);
                sudokuTamam(durum, 2, sudo);
                tred2.Abort();
            }
            if (sudoku2[i, j] == 0)
            {
                for (rakam = 1; rakam < 10; rakam++)
                {
                    if (uygunMu(i, j, rakam, sudoku2))
                    {
                        sudoku2[i, j] = rakam;
                        if (j < 8)
                        {
                            sudokuÇöz2(i, j + 1);
                        }
                        else if (i < 8)
                        {
                            sudokuÇöz2(i + 1, 0);
                        }
                        else
                        {
                            sudokuÇöz2(0, 0);
                        }
                        sudoku2[i, j] = 0;
                    }
                }
            }
            else
            {
                if (j < 8)
                {
                    sudokuÇöz2(i, j + 1);
                }
                else if (i < 8)
                {
                    sudokuÇöz2(i + 1, 0);
                }
                else
                {
                    sudokuÇöz2(0, 0);
                }
            }
        }
        
        void sudokuÇöz3(int i, int j)
        {
            int a, b, rakam;
            bool durum = true;
            String sudo;

            sudo = stringeAl(sudoku3);
            writer3.WriteLine(sudo);

            for (a = 0; a < 9; a++)
            {
                for (b = 0; b < 9; b++)
                {
                    if (sudoku3[a, b] == 0)
                    {
                        durum = false;
                    }
                }
            }
            if (durum == true)
            {
                sure.Stop();
                tred1.Abort();
                tred2.Abort();
                writer1.Close();
                writer2.Close();
                writer3.Close();
                dosya1.Close();
                dosya2.Close();
                dosya3.Close();
                sudo = stringeAl(sudoku3);
                sudokuTamam(durum, 3, sudo);
                tred3.Abort();
            }
            if (sudoku3[i, j] == 0)
            {
                for (rakam = 1; rakam < 10; rakam++)
                {
                    if (uygunMu(i, j, rakam, sudoku3))
                    {
                        sudoku3[i, j] = rakam;
                        if (j < 8)
                        {
                            sudokuÇöz3(i, j + 1);
                        }
                        else if (i < 8)
                        {
                            sudokuÇöz3(i + 1, 0);
                        }
                        else
                        {
                            sudokuÇöz3(0, 0);
                        }
                        sudoku3[i, j] = 0;
                    }
                }
            }
            else
            {
                if (j < 8)
                {
                    sudokuÇöz3(i, j + 1);
                }
                else if (i < 8)
                {
                    sudokuÇöz3(i + 1, 0);
                }
                else
                {
                    sudokuÇöz3(0, 0);
                }
            }
        }

        bool uygunMu(int i, int j, int rakam, int[,] sudoku)
        {
            bool durum = true;
            int m, n, a, b;
            a = i - (i % 3);
            b = j - (j % 3);
            for (n = 0; n < 9; n++)
            {
                if (sudoku[i, n] == rakam)
                {
                    durum = false;
                    break;
                }
            }
            if (durum == true)
            {
                for (m = 0; m < 9; m++)
                {
                    if (sudoku[m, j] == rakam)
                    {
                        durum = false;
                        break;
                    }
                }
            }
            if (durum == true)
            {
                for (m = a; m < a + 3; m++)
                {
                    for (n = b; n < b + 3; n++)
                    {
                        if (sudoku[m, n] == rakam)
                        {
                            durum = false;
                            break;
                        }
                    }
                    if (durum == false)
                    {
                        break;
                    }
                }
            }
            return durum;
        }

        void sudokuTamam(bool durum, int tredNo, String sudo)
        {
            if (durum == true)
            {
                cs.Text = "Çalışma Süresi: ";
                cs.Text += sure.ElapsedMilliseconds + "ms";
                sudokuYazdır(sudo);
                sonuc.Text = "Thread " + tredNo + "çözüme ulaştı.";
                button2.Enabled = true;
            }
            else
            {
                sonuc.Text = "Bu sudokunun çözümü yok!";
            }
        }

        String stringeAl(int[,] sudoku)
        {
            int i, j;
            String sudo = "";
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    if (sudoku[i, j] != 0)
                    {
                        sudo += sudoku[i, j];
                    }
                    else
                    {
                        sudo += " ";
                    }
                }
                sudo += "  ";
            }
            return sudo;
        }
        
        void sudokularıGöster()
        {
            Form2 f2 = new Form2();
            f2.Show();
            Form3 f3 = new Form3();
            f3.Show();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sudokularıGöster();
        }
    }
}
