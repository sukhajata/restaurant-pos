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
    public partial class frmEditTables : Form
    {
        private List<POSRoom> _rooms;

        public frmEditTables()
        {
            InitializeComponent();
            BuildButtons();
        }


        private void BuildButtons()
        {
            tbRooms.Controls.Clear();
            _rooms = DataHelper.GetRooms();
            foreach (POSRoom room in _rooms)
            {
                Dictionary<Point, Button> buttons = new Dictionary<Point, Button>();

                //tab page for each room
                TabPage tp = new TabPage(room.Rname);
                tp.Font = new Font("Candara", 11);
                //Table Layout Panel for buttons
                TableLayoutPanel tlp = new TableLayoutPanel();
                tlp.AutoSize = true;
                tlp.Margin = new Padding(0);

                //create buttons for each existing table
                List<POSTable> tables = DataHelper.GetTables(room.Rid);
                foreach (POSTable table in tables)
                {
                    //tlp.Controls.RemoveAt(table.X + table.Y * 8);
                    Button btn = new Button();
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Dock = DockStyle.Fill;
                    btn.Size = new Size(90, 70);
                    btn.Text = table.Tname;
                    if (table.Hid == 0)
                    {
                        btn.BackColor = Color.LawnGreen;
                    }
                    else //do not allow edits on tables with existing holds
                    {
                        btn.BackColor = Color.Orange;
                        btn.Enabled = false;
                    }
                    btn.Tag = table;
                    btn.Click += new EventHandler(btn_Click);
                    buttons.Add(new Point(table.X, table.Y), btn);
                    tlp.Controls.Add(btn, table.X, table.Y);
                }

                //fill the remaining spaces with blank buttons
                for (int r = 0; r < 9; r++)
                {
                    for (int c = 0; c < 8; c++)
                    {
                        Point p = new Point(c, r);
                        if (!buttons.Keys.Contains(p))
                        {
                            Button btn = new Button();
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.Dock = DockStyle.Fill;
                            btn.Size = new Size(90, 70);
                            btn.BackColor = Color.White;
                            //save info as array {rid, x, y}
                            btn.Tag = new int[] { room.Rid, c, r };
                            btn.Click += new EventHandler(btn_Click);
                            tlp.Controls.Add(btn, c, r);
                        }
                    }
                }
                
                tp.Controls.Add(tlp);
                tbRooms.Controls.Add(tp);
            }

            //for creating a new room
            TabPage tbNew = new TabPage("+");
            tbNew.Enter += new EventHandler(tbNew_Enter);
            tbRooms.Controls.Add(tbNew);

            TabPage tbExit = new TabPage("Exit");
            tbExit.Enter += new EventHandler(tbExit_Enter);
            tbRooms.Controls.Add(tbExit);
        }

        void tbNew_Enter(object sender, EventArgs e)
        {
            Global.KeyboardInput = string.Empty;
            Qwerty qw = new Qwerty(string.Empty);
            qw.ShowDialog();

            if (!Global.KeyboardInput.Equals(string.Empty))
            {
                POSRoom newRoom = new POSRoom(-1, Global.KeyboardInput);
                _rooms.Add(newRoom);
                DataHelper.SaveRooms(_rooms);
                BuildButtons();
            }
            
        }

        void tbExit_Enter(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //see if there is a table already on this button.
            //if not create one
            POSTable table;
            try
            {
                table = (POSTable)btn.Tag;
            }
            catch (Exception)
            {
                int[] data = (int[])btn.Tag;
                table = new POSTable(-1, string.Empty, data[0], data[1], data[2]);
            }
            Global.KeyboardInput = string.Empty;
            Qwerty keyboard = new Qwerty(table.Tname);
            keyboard.ShowDialog();

            if (!Global.KeyboardInput.Equals(string.Empty))
            {
                UpdateTable(table, btn);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void UpdateTable(POSTable table, Button btn)
        {
            if (Global.KeyboardInput.Equals(string.Empty) ||
                Global.KeyboardInput.Equals(Qwerty.DELETE))
            {
                if (table.Tid > 0)
                {
                    //remove from database
                    DataHelper.DeleteTable(table.Tid);
                }
                btn.Text = string.Empty;
                btn.BackColor = Color.White;
                //reset button tag
                btn.Tag = new int[] { table.Rid, table.X, table.Y };
            }
            else
            {
                //update button and save Table to database
                btn.Text = Global.KeyboardInput;
                table.Tname = Global.KeyboardInput;
                btn.BackColor = Color.LawnGreen;
                int tid = DataHelper.SaveTable(table);
                btn.Tag = new POSTable(tid, table.Tname, table.Rid, table.X, table.Y);
            }

        }

    }
}
