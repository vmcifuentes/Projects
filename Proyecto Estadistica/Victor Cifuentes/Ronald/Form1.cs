using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ronald
{
    public partial class Form1 : Form
    {
        //Arreglos X y Y
        double[] arregloX = new double[1];
        double[] arregloY = new double[1];

        //Variables de posicion
        int posicionX = 0;
        int posicionY = 0;

        //Variables de sumatoria
        double sumatoriaX = 0;
        double sumatoriaY = 0;
        double sumatoriaX2 = 0;
        double sumatoriaY2 = 0;
        double sumatoriaXY = 0;
        double sumatoriaXiXm = 0;
        double sumatoriaYiYm = 0;
        double sumatoriaXiXmYiYm = 0;

        //Sumatorias Cuadradas
        double sumatoria2X = 0;
        double sumatoria2Y = 0;
        double sumatoria2XY = 0;

        //Promedios
        double promedioX = 0;
        double promedioY = 0;

        //Variables R
        double r1 = 0;
        double r2 = 0;
        double r3 = 0;
        double r4 = 0;
        double r5 = 0;
        double r = 0;

        //Variables B
        double b1 = 0;
        double b0 = 0;

        //Variables Predicción y Error
        double yPred = 0;
        double error = 0;
        double vPrediccion = 0;
        double prediccion = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            arregloX[posicionX] = x;
            Array.Resize(ref arregloX, arregloX.Length + 1);
            posicionX += 1;

            double y = Convert.ToDouble(textBox2.Text);
            arregloY[posicionY] = y;
            Array.Resize(ref arregloY, arregloY.Length + 1);
            posicionY += 1;

            textBox1.Text = "";
            textBox2.Text = "";

            dataGridView1.Rows.Add(posicionX,x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //x^2
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {                
                dataGridView1.Rows[i].Cells[5].Value = (arregloX[i]) * (arregloX[i]);
                sumatoriaX2 = sumatoriaX2 + ((arregloX[i]) * (arregloX[i]));
            }

            //y^2
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[6].Value = (arregloY[i]) * (arregloY[i]);
                sumatoriaY2 = sumatoriaY2 + ((arregloY[i]) * (arregloY[i]));
            }

            //x*y
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[7].Value = (arregloX[i]) * (arregloY[i]);
                sumatoriaXY = sumatoriaXY + ((arregloX[i]) * (arregloY[i]));
            }       

            //Sumatoria X
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sumatoriaX = sumatoriaX + arregloX[i];
                label14.Text = Convert.ToString(sumatoriaX);
            }

            //Promedio X
            promedioX = sumatoriaX / (dataGridView1.Rows.Count - 1);

            //Sumatoria Y
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sumatoriaY = sumatoriaY + arregloY[i];
                label15.Text = Convert.ToString(sumatoriaY);
            }

            //Promedio Y
            promedioY = sumatoriaY / (dataGridView1.Rows.Count - 1);

            //Sumatoria X^2                           
            label16.Text = Convert.ToString(sumatoriaX2);            

            //Sumatoria Y^2           
            label17.Text = Convert.ToString(sumatoriaY2);            

            //Sumatoria XY            
            label18.Text = Convert.ToString(sumatoriaXY);            

            //Resultado r
            //r1
            int n = posicionX;
            r1 = n * sumatoriaXY - sumatoriaX * sumatoriaY;
            r2 = (n * sumatoriaX2) - (sumatoriaX * sumatoriaX);
            r3 = (n * sumatoriaY2) - (sumatoriaY * sumatoriaY);
            r4 = Math.Sqrt(r2);
            r5 = Math.Sqrt(r3);
            r = r1 / (r4 * r5);
            label22.Text = Convert.ToString(r);

            //Sumatoria de Cuadrados X
            sumatoria2X = sumatoriaX2 - (sumatoriaX * sumatoriaX) / n;            

            //Sumatoria de Cuadrados Y
            sumatoria2Y = sumatoriaY2 - (sumatoriaY * sumatoriaY) / n;

            //Suma Cruzados X y Y
            sumatoria2XY = sumatoriaXY - (sumatoriaX * sumatoriaY) / n;

            //Resultados de B
            b1 = sumatoria2XY / sumatoria2X;
            label24.Text = Convert.ToString(b1);

            b0 = promedioY - b1 * promedioX;
            label23.Text = Convert.ToString(b0);

            //(Xi-Xm)^2
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[8].Value = (arregloX[i] - promedioX) * (arregloX[i] - promedioX);
                sumatoriaXiXm = sumatoriaXiXm + ((arregloX[i] - promedioX) * (arregloX[i] - promedioX));
            }

            //(Yi-Ym)^2
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[9].Value = (arregloY[i] - promedioY) * (arregloY[i] - promedioY);
                sumatoriaYiYm = sumatoriaYiYm + ((arregloY[i] - promedioY) * (arregloY[i] - promedioY));
            }

            //Sumatoria de (Xi-Xm)^2
            label19.Text = Convert.ToString(sumatoriaXiXm);

            //Sumatoria de (Yi-Ym)^2
            label20.Text = Convert.ToString(sumatoriaYiYm);

            //(Xi-Xm)
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[10].Value = (arregloX[i] - promedioX);                
            }

            //(Yi-Ym)
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[11].Value = (arregloY[i] - promedioY);
            }

            //(Xi-Xm)*(Yi-Ym)
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[12].Value = (arregloX[i] - promedioX) * (arregloY[i] - promedioY);
                sumatoriaXiXmYiYm = sumatoriaXiXmYiYm + (arregloX[i] - promedioX) * (arregloY[i] - promedioY);
            }

            //Sumatoria (Xi-Xm)*(Yi-Ym)
            label21.Text = Convert.ToString(sumatoriaXiXmYiYm);

            //Ypred
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                yPred = b0 + b1 * arregloX[i];
                dataGridView1.Rows[i].Cells[3].Value = yPred;
                
            }

            //Datos Error
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                error = arregloY[i] - yPred;
                dataGridView1.Rows[i].Cells[4].Value = error;
                
            }

            
            vPrediccion = Convert.ToDouble(pred.Text);
            prediccion = b0 + b1 * vPrediccion;

            label8.Text = Convert.ToString(prediccion);
        }

    }
}
