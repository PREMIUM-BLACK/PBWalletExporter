using NBitcoin;
using NBitcoin.Altcoins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBWalletExporter.lib
{
    public static class crypto
    {
        public static BitcoinAddress GetAddressFromPubKey(ExtPubKey key, uint index, Network net, ScriptPubKeyType pubkeytype = ScriptPubKeyType.Legacy)
        {
            return key.Derive(index).PubKey.GetAddress(pubkeytype, net);
        }

        /// <summary>
        /// xpub = 0488b21e
        /// 
        /// </summary>
        /// <param name="xpubkey"></param>
        /// <param name="newFormat"></param>
        /// <returns></returns>
        public static string ParseNewxPubFormats(string xpubkey, string newFormat = "xpub")
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

        public static String GetETHAddress(ExtPubKey pubkey, uint index, bool derive = true)
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


        public static String GetXPub(ExtKey key, String currency, int pathIndex)
        {
            BitcoinExtPubKey xpub;

            switch (currency)
            {
                case "Bitcoin":

                    key = DeriveKey(key, 44, 0, pathIndex, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                    return xpub.ToString();

                case "Ethereum":

                    key = DeriveKey(key, 44, 60, pathIndex, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                    return xpub.ToString();

                case "Litecoin":


                    key = DeriveKey(key, 44, 2, pathIndex, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                    var ltc = Litecoin.Instance.Mainnet.CreateBitcoinExtPubKey(xpub);

                    return xpub.ToString();

                case "Litecoin (Ltub)":


                    key = DeriveKey(key, 44, 2, pathIndex, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                    //Ltub : 019DA462
                    var x = ParseNewxPubFormats(xpub.ToString(), "019DA462");

                    return x;

                case "DASH":


                    key = DeriveKey(key, 44, 5, pathIndex, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                   return xpub.ToString();

                case "DASH (drkp)":


                    key = DeriveKey(key, 44, 5, pathIndex, 0);

                    xpub = key.Neuter().GetWif(Network.Main);

                    //drkp : 02FE52CC
                    var x2 = ParseNewxPubFormats(xpub.ToString(), "02FE52CC");

                    return x2.ToString();

            }

            return null;
        }

        public static ExtKey DeriveKey(ExtKey key, int purpose = 44, int coin = 0, int account = 0, uint externalInternal = 0)
        {
            if (key.Depth > 0)
                throw new Exception("key is not the master key");

            return key.Derive(purpose, true).Derive(coin, true).Derive(account, true).Derive(externalInternal);
        }


    }
}
