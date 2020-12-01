using NBitcoin;
using NBitcoin.Altcoins;
using Nethereum.HdWallet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PBWalletExporter.lib.crypto;

namespace PBWalletExporter
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {


            if (MessageBox.Show("DISCLAIMER: Please use this tool on your own RISK.\r\nIt can help you, to get your Public Key (xPub) for your wallet to use with PREMIUM BLACK or other services. This tool will be provided \"as-is\" without any warranty about its functionality. But at any time prove the given public key and compare with the one you'll receive from your wallet.\r\nWhen you press on OK you agree with that.", "DISCLAIMER", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                this.Close();
                return;
            }

            cmbCurrency.SelectedIndex = 0;
#if NETCOREAPP3_1
            txtWords.PlaceholderText = "my mnemonic words to keep my wallet safe";

            txtPublicKey.PlaceholderText = "xPub123456789....";
#endif
        }
        private void bnShow_MouseDown(object sender, MouseEventArgs e)
        {
            txtWords.PasswordChar = new char();
        }

        private void bnShow_MouseUp(object sender, MouseEventArgs e)
        {
            txtWords.PasswordChar = '#';
        }

        private void bnGetPublicKey_Click(object sender, EventArgs e)
        {
            if (txtWords.Text.Trim() == "")
            {
                if (sender != null)
                    MessageBox.Show("Please fill in your words.");

                return;
            }

            if (cmbCurrency.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose your currency.");
                return;
            }

            if (txtWords.Text.Contains("\r\n"))
            {
                txtWords.Text = txtWords.Text.Replace("\r\n", " ");
            }

            Mnemonic _mn;
            try
            {
                _mn = new Mnemonic(txtWords.Text);

            }
            catch(FormatException ex)
            {
                int c = txtWords.Text.Split(' ').Count();
                MessageBox.Show("Error: " + ex.Message + "\r\nWordcount: " + c, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid Words.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BitcoinExtPubKey xpub;

            var key = _mn.DeriveExtKey();


            txtPublicKey.Text = GetXPub(key, cmbCurrency.SelectedItem.ToString(), (int)nudWalletIndex.Value);

            switch (cmbCurrency.SelectedItem)
            {
                case "Bitcoin":

                    lblPath.Text = $"Path: m/44'/0'/{nudWalletIndex.Value.ToString("0")}'/0";

                    break;

                case "Ethereum":

                    lblPath.Text = $"Path: m/44'/60'/{nudWalletIndex.Value.ToString("0")}'/0";

                    break;

                case "Litecoin":

                    lblPath.Text = $"Path: m/44'/2'/{nudWalletIndex.Value.ToString("0")}'/0";

                    break;

                case "Litecoin (Ltub)":

                    lblPath.Text = $"Path: m/44'/2'/{nudWalletIndex.Value.ToString("0")}'/0";

                    break;

                case "DASH":

                    lblPath.Text = $"Path: m/44'/5'/{nudWalletIndex.Value.ToString("0")}'/0";

                    break;

                case "DASH (drkp)":

                    lblPath.Text = $"Path: m/44'/5'/{nudWalletIndex.Value.ToString("0")}'/0";

                    break;

            }




        }



        private void bnShowAdresses_Click(object sender, EventArgs e)
        {
            if (txtWords.Text.Trim() == "")
            {
                MessageBox.Show("Please fill in your words.");
                return;
            }

            if (cmbCurrency.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose your currency.");
                return;
            }

            if (txtPublicKey.Text.Trim() == "")
            {
                MessageBox.Show("Please generate your public key first.");
                return;
            }



            var s = "";

            var normalizeKey = ParseNewxPubFormats(txtPublicKey.Text, "0488b21e"); //xpub

            var key = new BitcoinExtPubKey(normalizeKey);

            switch (cmbCurrency.SelectedItem)
            {
                case "Bitcoin":


                    for (uint i = 0; i < 25; i++)
                    {
                        s += GetAddressFromPubKey(key, i, Network.Main).ToString() + "\r\n";


                    }


                    break;
                case "Ethereum":

                    for (uint i = 0; i < 25; i++)
                    {
                        s += GetETHAddress(key, i, false) + "\r\n";


                    }

                    break;

                case "Litecoin":
                case "Litecoin (Ltub)":

                    for (uint i = 0; i < 25; i++)
                    {
                        s += GetAddressFromPubKey(key, i, Litecoin.Instance.Mainnet).ToString() + "\r\n";


                    }



                    break;

                case "DASH":
                case "DASH (drkp)":

                    for (uint i = 0; i < 25; i++)
                    {
                        s += GetAddressFromPubKey(key, i, Dash.Instance.Mainnet).ToString() + "\r\n";


                    }


                    break;
            }




            frmAddresses frm = new frmAddresses();
            frm.txtAddresses.Text = s;
            frm.ShowDialog();

        }





        private void llLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://premium.black");
        }

        static void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    var p = Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });

                    Thread.Sleep(1000);

                    p.Close();
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void bnRandom_Click(object sender, EventArgs e)
        {

            if (txtWords.Text.Trim() != "" && MessageBox.Show("Replace words with random ones ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var mn = new Mnemonic(Wordlist.English, WordCount.Twelve);

            txtWords.Text = mn.ToString();


        }

        private void bnShow_Click(object sender, EventArgs e)
        {

        }

        private void nudWalletIndex_ValueChanged(object sender, EventArgs e)
        {
            bnGetPublicKey_Click(null, null);
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            bnGetPublicKey_Click(null, null);
        }

        private void bnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In the case of not knowing the path of your HD wallet, but having one address, you can use this search feature. It will try multiple pathes.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmSearch frm = new frmSearch();
            frm.Currency = cmbCurrency.SelectedItem.ToString();
            frm.SecretPhrase = txtWords.Text;
            frm.ShowDialog();

            if (frm.PathIndex == null)
                return;


            nudWalletIndex.Value = frm.PathIndex.Value;

            MessageBox.Show("Path imported!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
