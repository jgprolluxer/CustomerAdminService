using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prollux.CustomerAdmin.Test.ProlluxCustomerAdminService;

namespace Prollux.CustomerAdmin.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var clientId = int.Parse(textBox1.Text);
            ResultData result;

            using (var service = new ProlluxCustomerAdminClient())
            {
                var clientData = new ClientData
                {
                    ClientId = clientId,
                    UserName = "jgarza"
                };

                result = service.IsValidClient(clientData);
            }

            MessageBox.Show(result.Valid + " - " + result.Error);
        }
    }
}
