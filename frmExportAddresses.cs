using NBitcoin;
using NBitcoin.Altcoins;
using PBWalletExporter.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static PBWalletExporter.lib.crypto;

namespace PBWalletExporter
{
    public partial class frmExportAddresses : Form
    {
        public String Mnemonic { get; set; }

        public frmExportAddresses()
        {
            InitializeComponent();

            foreach (var co in crypto.GetOptions())
            {
                cmbCurrency.Items.Add(co);
            }


        }

        private void bnClose_Click(object sender, EventArgs e)
        {
            this.Close();



        }

        public List<String> GenerateAddresses(int count)
        {
            List<String> addresses = new List<String>();

            if (Mnemonic == null)
                return addresses;

            Mnemonic _mn;

            try
            {
                _mn = new Mnemonic(Mnemonic);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Words.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return addresses;
            }

            var key = _mn.DeriveExtKey();

            ExtPubKey xpub;

            int pathIndex = 0;
            String s = "";

            switch (cmbCurrency.SelectedItem?.ToString() ?? "bitcoin")
            {
                case "Bitcoin":

                    key = key.Derive(new KeyPath($"m/44'/0'/{pathIndex}'/0"));

                    //key = DeriveKey(key, 44, 0, pathIndex, 0);

                    xpub = key.Neuter();

                    for (uint i = 0; i < count; i++)
                    {
                        addresses.Add(GetAddressFromPubKey(xpub, i, Network.Main).ToString());
                    }

                    break;

                case "Ethereum (Metamask)":

                    key = key.Derive(new KeyPath($"m/44'/60'/{pathIndex}/0"));

                    xpub = key.Neuter();


                    for (uint i = 0; i < count; i++)
                    {
                        addresses.Add(GetETHMetamaskAddress(xpub, i, false));
                    }

                    break;

                case "Ethereum (Ledger)":

                    for (int i = 0; i < count; i++)
                    {
                        var pk = key.Derive(new KeyPath($"44'/60'/{i}'/0/0"));

                        addresses.Add(GetETHLedgerAddress(pk.Neuter(), i));
                    }

                    break;

                case "Litecoin":
                case "Litecoin (Ltub)":


                    key = key.Derive(new KeyPath($"m/44'/2'/{pathIndex}'/0"));

                    xpub = key.Neuter();

                    for (uint i = 0; i < count; i++)
                    {
                        addresses.Add(GetAddressFromPubKey(xpub, i, Litecoin.Instance.Mainnet).ToString());
                    }

                    break;

                case "DASH":
                case "DASH (drkp)":


                    key = key.Derive(new KeyPath($"m/44'/5'/{pathIndex}'/0")); ;

                    xpub = key.Neuter();

                    for (uint i = 0; i < count; i++)
                    {
                        addresses.Add(GetAddressFromPubKey(xpub, i, Dash.Instance.Mainnet).ToString());

                    }

                    break;

            }

            return addresses;

        }

        public void PreviewAddresses()
        {
            if (Mnemonic == null)
                return;


            List<string> addresses = GenerateAddresses(25);

            txtAddresses.Text = "";

            String s = "";

            foreach (var a in addresses)
            {
                s += a + "\r\n";
            }

            txtAddresses.Text = s;

        }

        private void nudAddressCount_ValueChanged(object sender, EventArgs e)
        {
            PreviewAddresses();
        }

        private void bnExport_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                if (File.Exists(sfd.FileName))
                    File.Delete(sfd.FileName);
            }
            catch
            {
                return;
            }

            var addresses = GenerateAddresses((int)nudAddressCount.Value);

            String s = "";
            int i = 0;
            foreach (var a in addresses)
            {
                if (chkAddIndexColumn.Checked)
                {
                    s += $"{i};";
                    i++;
                }

                s += a + "\r\n";

            }
            try
            {
                File.WriteAllText(sfd.FileName, s);

                MessageBox.Show("Addresses exported!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }
        }

        private void frmExportAddresses_Load(object sender, EventArgs e)
        {
            PreviewAddresses();
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreviewAddresses();
        }
    }
}
