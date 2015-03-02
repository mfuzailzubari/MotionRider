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
    public partial class frmMotionRide : Form
    {
        MotionRiderDBDataContext _db = new MotionRiderDBDataContext();
        string _type;
        int _id;
        frmMain _parent;

        // Constructor for edit.
        public frmMotionRide(int id_, string type_, frmMain parent_)
        {
            InitializeComponent();
            _type = type_;
            _id = id_;
            _parent = parent_;
        }

        //public frmMotionRide(int id_, string type_)
        //{
        //    InitializeComponent();
        //    _type = type_;
        //    _id = id_;
        //}

        public frmMotionRide(string type_, frmMain parent_)
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

        private void On_btnSubmit_Click(object sender, EventArgs e)
        {
            if (_type == "Add")
            {
                if (txtName.Text != string.Empty && txtCharges.Text != string.Empty)
                {
                    motion_ride mtn = new motion_ride();
                    mtn.motion_name = txtName.Text;
                    mtn.motion_charges = Convert.ToDecimal(txtCharges.Text);
                    _db.motion_rides.InsertOnSubmit(mtn);
                    _db.SubmitChanges();

                    _parent.Load_Motion_Ride_Data();
                    _parent.LoadMotionDataGrid();

                    this.Close();
                }
            }
            else if (_type == "Edit")
            {
                if (txtName.Text != string.Empty && txtCharges.Text != string.Empty)
                {
                    motion_ride mtn = _db.motion_rides.Single(cat => cat.motion_id == _id);
                    mtn.motion_name = txtName.Text;
                    mtn.motion_charges = Convert.ToDecimal(txtCharges.Text);
                    _db.SubmitChanges();

                    _parent.Load_Motion_Ride_Data();
                    _parent.LoadMotionDataGrid();

                    this.Close();
                }
            }
        }

        private void On_frmMotionRide_Load(object sender, EventArgs e)
        {
            if (_type == "Edit")
            {
                StyleChange();
            }
        }

        private void StyleChange()
        {
            this.Text = "Edit Motion Ride";
            lblAddMotionRIde.Text = "Edit Motion Ride";
            btnSubmit.Text = "Update";

            motion_ride mtn = _db.motion_rides.First(cat => cat.motion_id == _id);
            txtName.Text = mtn.motion_name;
            txtCharges.Text = Convert.ToString(mtn.motion_charges);
        }
    }
}
