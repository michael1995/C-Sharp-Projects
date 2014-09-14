using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
// Source: Visual C# 2005 How to Program, 2nd Edition by Deitel and Deitel 
//          ISBN: 0-13-152523-9
namespace Graphics2D
{
    public partial class Form1 : Form
    {

        #region Global Declaration 


        #endregion 
        
        #region Constructor 

        public Form1()
        {
            InitializeComponent();
        }

        #endregion 

        #region Accessor 

        private Graphics graphicsObject(PaintEventArgs e)
        {
            return e.Graphics;
        }

        private Rectangle drawArea(Rectangle pRectangle)
        {
            return pRectangle;
        }

        #endregion 

        #region Mutator


        #endregion 

        #region Control Event

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            LinearGradientBrush linearBrush = new LinearGradientBrush(drawArea(new Rectangle(5, 35, 30, 100)), Color.Yellow, Color.Yellow, LinearGradientMode.ForwardDiagonal);
            graphicsObject(e).FillEllipse(linearBrush, this.Width / 4, 10, 300, 300);

            LinearGradientBrush linearBrush2 = new LinearGradientBrush(drawArea(new Rectangle(5, 35, 30, 100)), Color.Black, Color.Black, LinearGradientMode.Horizontal);
            graphicsObject(e).FillEllipse(linearBrush2, 190, 60, 100, 100);

            LinearGradientBrush linearBrush3 = new LinearGradientBrush(drawArea(new Rectangle(5, 35, 30, 100)), Color.Black, Color.Black, LinearGradientMode.BackwardDiagonal);
            graphicsObject(e).FillEllipse(linearBrush3, 330, 60, 100, 100);

            LinearGradientBrush linearBrush4 = new LinearGradientBrush(drawArea(new Rectangle(5, 35, 30, 100)), Color.Yellow, Color.Yellow, LinearGradientMode.BackwardDiagonal);
            graphicsObject(e).FillEllipse(linearBrush4, 460, 400, 100, 100);

            Bitmap textureBitmap = new Bitmap(10, 10);
            Graphics graphicsObject2 = Graphics.FromImage(textureBitmap);

            SolidBrush solidColorBrush = new SolidBrush(Color.Red);
            Pen coloredPen = new Pen(solidColorBrush);

            TextureBrush texturedBrush = new TextureBrush(textureBitmap);
            graphicsObject(e).FillRectangle(texturedBrush, 155, 30, 75, 100);

            coloredPen.Color = Color.Black;
            coloredPen.Width = 6;
            graphicsObject(e).DrawPie(coloredPen, 205, 220, 205, 10, 100, 100);
        }
        #endregion 

    }
}
