using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gokart_vanal
{
    public partial class MarkerNameModal : Form
    {
        public string value { get; private set; }

        public MarkerNameModal()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, EventArgs e)
        {
            this.value = markerName.Text;
        }
    }
}
