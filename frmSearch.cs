using NBitcoin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static PBWalletExporter.lib.crypto;

namespace PBWalletExporter
{
    public partial class frmSearch : Form
    {
        public String Currency { get; set; }

        public String SecretPhrase { get; set; }

        public int? PathIndex { get; set; }

        public frmSearch()
        {
            InitializeComponent();
        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            pgrProgress.Visible = true;

            var _mn = new Mnemonic(SecretPhrase);

            BitcoinExtPubKey xpub;

            var key = _mn.DeriveExtKey();

            String f = txtAddress.Text.Trim();

            for (int i = 0; i < nudPathesToTry.Value; i++)
            {
                var pubkey = GetXPub(key, this.Currency, i);
                var bpubkey = new BitcoinExtPubKey(pubkey, Network.Main);

                for (uint a = 0; a < nudPerPath.Value; a++)
                {
                    String s = GetAddressFromPubKey(bpubkey, a, Network.Main).ToString();
                    System.Diagnostics.Debug.WriteLine($"{i}/{a}: {s}");

                    if (s == f)
                    {
                        pgrProgress.Visible = false;
                        lblResult.Text = $"Path found.\r\nAdress: {f}\r\nPath index: {i},\r\nAddress index: {a}";
                        if (MessageBox.Show($"Path found.\r\nAdress: {f}\r\nPath index: {i},\r\nAddress index: {a}\r\n\r\nWould you like to import to main window?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            this.PathIndex = i;
                            this.Close();
                        }

                        return;
                    }
                }

            }

            lblResult.Text = "No path found.";
            MessageBox.Show("No path found.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            pgrProgress.Visible = false;

        }
    }
}
