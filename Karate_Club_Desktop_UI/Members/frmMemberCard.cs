using Karate_Club.Members.Controls;
using Karate_Club.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate_Club.Members
{
    public partial class frmMemberCard : Form
    {
        public event Action MemberInfoUpdated;

        protected virtual void OnMemberInfoUpdated()
        {
            MemberInfoUpdated?.Invoke();
        }

        private void _Subscribe(ctrMemberCard memberCard)
        {
            memberCard.MemberInfoUpdated += OnMemberInfoUpdated;
        }

        private int _memberID;
        public frmMemberCard(int memberID)
        {
            InitializeComponent();
            _memberID = memberID;   
        }

        private void frmMemberCard_Load(object sender, EventArgs e)
        {
            _Subscribe(ctrMemberCard1);
            ctrMemberCard1.LoadMemberInfo(_memberID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
