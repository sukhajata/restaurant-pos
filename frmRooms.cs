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
    public partial class frmRooms : Form
    {
        private List<POSRoom> rooms;
        private int rid; //temp id for new rooms which must be unique

        public frmRooms()
        {
            InitializeComponent();
            this.ControlBox = false;
            rid = -1;
            rooms = DataHelper.GetRooms();
            BuildTable();
        }

        private void BuildTable()
        {
            pnlRooms.Controls.Clear();

            foreach (POSRoom room in rooms)
            {
                TextBox txtName = new TextBox();
                txtName.Text = room.Rname;
                txtName.Width = 245;
                txtName.MaxLength = 50;
                txtName.Tag = room;
                txtName.TextChanged += new EventHandler(txtName_TextChanged);
                pnlRooms.Controls.Add(txtName);

                Button btnDelete = new Button();
                btnDelete.Text = "Delete";
                btnDelete.Tag = room;
                btnDelete.Dock = DockStyle.Fill;
                btnDelete.Click += new EventHandler(btnDelete_Click);
                pnlRooms.Controls.Add(btnDelete);
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            POSRoom room = (POSRoom)btn.Tag;
            //check if tables exist in this room
            if (DataHelper.RoomHasTables(room.Rid))
            {
                MessageBox.Show("This rooms has existing tables so can not be deleted.");
            }
            else
            {
                DataHelper.DeleteRoom(room.Rid);
                rooms.Remove(room);
                BuildTable();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            POSRoom room = (POSRoom)txt.Tag;
            room.Rname = txt.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            POSRoom newRoom = new POSRoom(rid, string.Empty);
            rooms.Add(newRoom);
            rid--;

            TextBox txtName = new TextBox();
            txtName.Width = 245;
            txtName.MaxLength = 50;
            txtName.Tag = newRoom;
            txtName.TextChanged += new EventHandler(txtName_TextChanged);
            pnlRooms.Controls.Add(txtName);

            Button btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.Tag = newRoom;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Click += new EventHandler(btnDelete_Click);
            pnlRooms.Controls.Add(btnDelete);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataHelper.SaveRooms(rooms);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
