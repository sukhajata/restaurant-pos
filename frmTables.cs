using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS
{
    public partial class frmTables : Form
    {
        public enum mode { save, load, assign }
        private mode _mode;
        private POSOrder _order;

        public frmTables(mode m, POSOrder order)
        {
            InitializeComponent();
            _mode = m;
            _order = order;
            BuildButtons();
        }

        private void BuildButtons()
        {
            tbRooms.Controls.Clear();
            List<POSRoom> rooms = DataHelper.GetRooms();
            foreach (POSRoom room in rooms)
            {
                //tab page for each room
                TabPage tp = new TabPage(room.Rname);
                tp.Font = new Font("Candara", 11);
                //Table Layout Panel for buttons
                TableLayoutPanel tlp = new TableLayoutPanel();
                tlp.ColumnCount = 8;
                tlp.RowCount = 9;
                tlp.AutoSize = true;
                tlp.Margin = new Padding(0);

                //add buttons for tables
                Dictionary<Point, Button> buttons = new Dictionary<Point, Button>();
                List<POSTable> tables = DataHelper.GetTables(room.Rid);
                foreach (POSTable table in tables)
                {
                    Button btn = new Button();
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Dock = DockStyle.Fill;
                    btn.Size = new Size(90, 70);
                    btn.Text = table.Tname;
                    if (_mode == mode.save || _mode == mode.assign)
                    {
                        btn.BackColor = Color.LawnGreen;
                    }
                    else if (_mode == mode.load)
                    {
                        if (table.Hid == 0)
                        {
                            btn.BackColor = Color.LawnGreen;
                            btn.Enabled = false;
                        }
                        else
                        {
                            btn.BackColor = Color.Orange;
                        }
                    }
                    btn.Tag = table;
                    btn.Click += new EventHandler(btn_Click);
                    tlp.Controls.Add(btn, table.X, table.Y);
                    buttons.Add(new Point(table.X, table.Y), btn);
                }

                //fill in spaces with labels to stop panel shrinking
                for (int r = 0; r < 9; r++)
                {
                    for (int c = 0; c < 8; c++)
                    {
                        Point p = new Point(c, r);
                        if (!buttons.Keys.Contains(p))
                        {
                            Label lbl = new Label();
                            lbl.Size = new Size(90, 70);
                            tlp.Controls.Add(lbl, c, r);
                        }
                    }
                }

                tp.Controls.Add(tlp);
                tbRooms.Controls.Add(tp);

            }

            TabPage tbExit = new TabPage("Exit");
            tbExit.Enter += new EventHandler(tbExit_Enter);
            tbRooms.Controls.Add(tbExit);

        }

        void tbExit_Enter(object sender, EventArgs e)
        {
            this.Close();
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            POSTable table = (POSTable)btn.Tag;
            if (_mode == mode.save)
            {
                DataHelper.HoldOrder(Global.CurrentUser.Uid, table.Tid,
                    _order);
            }
            else if (_mode == mode.load)//load a saved order into the till
            {
                List<POSItemTill> tab = DataHelper.GetOrder(table.Hid);
                foreach (POSItemTill item in tab)
                {
                    _order.OrderItems.Add(item);
                }
                DataHelper.RemoveHold(table.Hid);
            }
            else if (_mode == mode.assign)
            {
                _order.Table = table;
            }
            
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
