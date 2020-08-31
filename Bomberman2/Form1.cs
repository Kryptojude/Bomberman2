using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman2
{
    public partial class Form1 : Form
    {
        List<int[,]> levels = new List<int[,]>();
        int[,] activeLevel;
        /// <summary>
        /// tilesize
        /// </summary>
        int ts = 40;
        int framerate = 60;
        Player[] players;

        public Form1()
        {
            InitializeComponent();

            // 0 = empty, 1 = wall, 2 = breakable wall, 3 = item
            levels.Add(new int[15, 23] {
                           { 0,0,2,0,2,2,0,2,0,2,2,2,2,2,0,2,0,2,2,2,0,2,2 },
                           { 0,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,0,1,2,1,0 },
                           { 2,2,0,2,0,2,0,1,0,2,0,2,0,2,0,1,2,0,2,2,0,2,2 },
                           { 0,1,2,1,1,1,1,1,2,1,2,1,2,1,2,1,1,1,1,1,2,1,2 },
                           { 2,0,2,2,0,2,0,2,2,0,0,1,0,2,0,0,2,2,0,2,0,2,0 },
                           { 2,1,0,1,2,1,2,1,0,1,2,1,2,1,2,1,2,1,2,1,2,1,2 },
                           { 2,2,2,1,2,0,2,0,2,2,2,2,2,0,2,2,0,2,0,1,0,2,2 },
                           { 0,1,2,1,2,1,2,1,1,1,2,1,2,1,1,1,2,1,2,1,2,1,0 },
                           { 2,2,0,1,0,2,0,2,2,0,2,2,2,2,2,0,2,0,2,1,2,2,2 },
                           { 2,1,2,1,2,1,2,1,2,1,2,1,2,1,0,1,2,1,2,1,0,1,2 },
                           { 0,2,0,2,0,2,2,0,0,2,0,1,0,0,2,2,0,2,0,2,2,0,2 },
                           { 2,1,2,1,1,1,1,1,2,1,2,1,2,1,2,1,1,1,1,1,2,1,0 },
                           { 2,2,0,2,2,0,2,1,0,2,0,2,0,2,0,1,0,2,0,2,0,2,2 },
                           { 0,1,2,1,0,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,0 },
                           { 2,2,0,2,2,2,0,2,0,2,2,2,2,2,0,2,0,2,2,0,2,0,0 },
            });
            levels.Add(new int[11, 11] {
                           { 0,0,0,2,0,2,0,2,0,0,0 },
                           { 0,1,1,1,2,1,2,1,1,1,0 },
                           { 0,1,0,2,0,0,0,2,0,1,0 },
                           { 2,1,0,1,0,1,0,1,0,1,2 },
                           { 0,2,0,2,0,0,0,2,0,2,0 },
                           { 2,1,0,1,0,1,0,1,0,1,2 },
                           { 0,2,0,2,0,0,0,2,0,2,0 },
                           { 2,1,0,1,0,1,0,1,0,1,2 },
                           { 0,1,0,2,0,0,0,2,0,1,0 },
                           { 0,1,1,1,2,1,2,1,1,1,0 },
                           { 0,0,0,2,0,2,0,2,0,0,0 },
            });
            // Determine active Level
            activeLevel = levels[0];
            // Adjust window size to level
            Size = new Size(activeLevel.GetLength(1) * ts + 16, activeLevel.GetLength(0) * ts + 39);
            // Initialize players at proper location
            players = new Player[] {
                new Player(0, 0, ref ts),
                new Player(activeLevel.GetLength(1) - 1, activeLevel.GetLength(0) - 1, ref ts), };
            Timer timer = new Timer { Enabled = true, Interval = 1000 / framerate };
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw walls and items
            for (int y = 0; y < activeLevel.GetLength(0); y++)
            {
                for (int x = 0; x < activeLevel.GetLength(1); x++)
                {
                    switch (activeLevel[y, x])
                    {
                        case 1:
                            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(x * ts, y*ts, ts, ts));
                            break;
                        case 2:
                            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(x * ts, y * ts, ts, ts));
                            break;
                        case 3:
                            //e.Graphics.DrawImage();
                            break;
                    }
                }
            }
            // Draw Players
            foreach (var player in players)
            {
                e.Graphics.DrawImage(player.getFrame(), player.getAbsoluteLocation());
            }
        }
    }
}
