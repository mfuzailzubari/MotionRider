using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotionRider
{

    public partial class frmSlush : Form
    {
        MotionRiderDBDataContext _db = new MotionRiderDBDataContext();
        string _type;
        int _id;
        frmMain _parent;

        string oldSlushName = string.Empty;

        public frmSlush(int id_, string type_, frmMain parent_)
        {
            InitializeComponent();
            _type = type_;
            _id = id_;
            _parent = parent_;
        }

        public frmSlush(string type_, frmMain parent_)
        {
            InitializeComponent();
            _type = type_;
            _parent = parent_;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void On_txtCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_type == "Add")
            {
                if (txtName.Text != string.Empty)
                {
                    slush sl = new slush();
                    sl.slush_name = txtName.Text;
                    sl.slush_price = Convert.ToDecimal(txtCharges.Text);
                    _db.slushes.InsertOnSubmit(sl);
                    _db.SubmitChanges();

                    // server save
                    //MotionRider.ServerDB.slush slu = new MotionRider.ServerDB.slush();
                    //slu.slush_name = txtName.Text;
                    //slu.slush_price = Convert.ToDecimal(txtCharges.Text);
                    //_dbServer.slushes.InsertOnSubmit(slu);
                    //_dbServer.SubmitChanges();

                    _parent.LoadSlushDataGrid();
                    _parent.Load_Slush_Data();

                    this.Close();
                }
            }
            else if (_type == "Edit")
            {
                slush sl = _db.slushes.Single(cat => cat.slush_id == _id);
                sl.slush_name = txtName.Text;
                sl.slush_price = Convert.ToDecimal(txtCharges.Text);
                _db.SubmitChanges();

                // server edit
                //MotionRider.ServerDB.slush slu = _dbServer.slushes.Single(cat => cat.slush_id == _id && cat.slush_name == oldSlushName);
                //slu.slush_name = txtName.Text;
                //slu.slush_price = Convert.ToDecimal(txtCharges.Text);
                //_dbServer.SubmitChanges();

                _parent.LoadSlushDataGrid();
                _parent.Load_Slush_Data();
                
                this.Close();
            }
        }

        private void frmSlush_Load(object sender, EventArgs e)
        {
            if (_type == "Edit")
            {
                StyleChange();
            }
        }
        private void StyleChange()
        {
            this.Text = "Edit Slush";
            lblAddMotionRIde.Text = "Edit Slush";
            btnSubmit.Text = "Update";

            slush sl= _db.slushes.First(cat => cat.slush_id == _id);
            txtName.Text = sl.slush_name;
            oldSlushName = sl.slush_name;
            txtCharges.Text = Convert.ToString(sl.slush_price);
        }



    }
}
