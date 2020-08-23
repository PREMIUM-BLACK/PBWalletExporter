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
                MessageBox.Show("Please fill in your words.");
                return;
            }

            if (cmbCurrency.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose your currency.");
                return;
            }

            var _mn = new Mnemonic(txtWords.Text);

            BitcoinExtPubKey xpub;

            var key = _mn.DeriveExtKey();

            switch (cmbCurrency.SelectedItem)
            {
                case "Bitcoin":



                    key = DeriveKey(key, 44, 0, 0, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                    txtPublicKey.Text = xpub.ToString();

                    lblPath.Text = "Path: m/44'/0'/0'/0";

                    break;

                case "Ethereum":

                    key = DeriveKey(key, 44, 60, 0, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                    txtPublicKey.Text = xpub.ToString();

                    lblPath.Text = "Path: m/44'/60'/0'/0";

                    break;

                case "Litecoin":


                    key = DeriveKey(key, 44, 2, 0, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                    var ltc = Litecoin.Instance.Mainnet.CreateBitcoinExtPubKey(xpub);

                    txtPublicKey.Text = xpub.ToString();

                    lblPath.Text = "Path: m/44'/2'/0'/0";

                    break;

                case "Litecoin (Ltub)":


                    key = DeriveKey(key, 44, 2, 0, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                    //Ltub : 019DA462
                    var x = ParseNewxPubFormats(xpub.ToString(), "019DA462");

                    txtPublicKey.Text = x;

                    lblPath.Text = "Path: m/44'/2'/0'/0";

                    break;

                case "DASH":


                    key = DeriveKey(key, 44, 5, 0, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                    txtPublicKey.Text = xpub.ToString();

                    lblPath.Text = "Path: m/44'/5'/0'/0";

                    break;

                case "DASH (drkp)":


                    key = DeriveKey(key, 44, 5, 0, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                    //drkp : 02FE52CC
                    var x2 = ParseNewxPubFormats(xpub.ToString(), "02FE52CC");

                    txtPublicKey.Text = x2.ToString();

                    lblPath.Text = "Path: m/44'/5'/0'/0";

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


        public static ExtKey DeriveKey(ExtKey key, int purpose = 44, int coin = 0, int account = 0, uint externalInternal = 0)
        {
            if (key.Depth > 0)
                throw new Exception("key is not the master key");

            return key.Derive(purpose, true).Derive(coin, true).Derive(account, true).Derive(externalInternal);
        }

        public static BitcoinAddress GetAddressFromPubKey(ExtPubKey key, uint index, Network net)
        {
            return key.Derive(index).PubKey.GetAddress(ScriptPubKeyType.Legacy, net);
        }

        /// <summary>
        /// xpub = 0488b21e
        /// 
        /// </summary>
        /// <param name="xpubkey"></param>
        /// <param name="newFormat"></param>
        /// <returns></returns>
        public string ParseNewxPubFormats(string xpubkey, string newFormat = "xpub")
        {
            try
            {
                var encoder = new NBitcoin.DataEncoders.Base58CheckEncoder();
                var decoded = encoder.DecodeData(xpubkey);

                var decoded_2 = decoded.Skip(4).ToArray();

                var decoded_3 = StringToByteArray(newFormat).Concat(decoded_2).ToArray();

                var encoded = encoder.EncodeData(decoded_3);

                return encoded;
            }
            catch
            {
                return null;
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private static String GetETHAddress(ExtPubKey pubkey, uint index, bool derive = true)
        {
            var pkd = (derive ? pubkey.Derive(0) : pubkey).Derive(index);

            PubKey ETH_publickKey = pkd.PubKey;

            byte[] byte_ETH_publicKey = ETH_publickKey.Decompress().ToBytes();

            var PubKeyNoPrefix = new byte[byte_ETH_publicKey.Length - 1];

            Array.Copy(byte_ETH_publicKey, 1, PubKeyNoPrefix, 0, PubKeyNoPrefix.Length);

            var initaddr = new Nethereum.Util.Sha3Keccack().CalculateHash(PubKeyNoPrefix);
            var addr = new byte[initaddr.Length - 12];

            Array.Copy(initaddr, 12, addr, 0, initaddr.Length - 12);

            var hex_addr = BitConverter.ToString(addr).Replace("-", "");
            string public_address = new Nethereum.Util.AddressUtil().ConvertToChecksumAddress(hex_addr);

            return public_address;
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

            if(txtWords.Text.Trim() != "" && MessageBox.Show("Replace words with random ones ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var mn = new Mnemonic(Wordlist.English, WordCount.Twelve);

            txtWords.Text = mn.ToString();


        }
    }
}
