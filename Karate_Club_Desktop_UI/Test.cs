﻿using Karate_Club_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate_Club
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            ctrMemberCard1.LoadMemberInfo(39); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ctrAddEditPerson1.LoadPersonInfo(1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }
    }
}
