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

namespace drawing_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Vertices = new List<TestLineBasedVertice>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TestLineBasedVertice v = new TestLineBasedVertice(new Point(50, 50), Math.PI / 3);
            //TestLineBasedVertice v2 = new TestLineBasedVertice(new Point(40, 10, 0));

            this.Vertices.Add(v);
            //this.Vertices.Add(v2);
        }

        private void form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach(TestLineBasedVertice v in Vertices)
            {
                v.OnPaint(g);
            }
        }

        private void form1_Click(object sender, EventArgs e)
        {
            MouseEventArgs args;

            if(e.GetType() != typeof(MouseEventArgs))
            {
                return;
            }

            args = (MouseEventArgs)e;

            foreach (TestLineBasedVertice v in Vertices)
            {
                if (v.TestMousePos(args.X, args.Y)) v.OnClick();
            }

            Refresh();
        }

        private List<TestLineBasedVertice> Vertices;
    }
}
