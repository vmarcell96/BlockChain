using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace BlockChain
{
    public class Block
    {
        public Guid Id { get; }
        public DateTime TimeStamp { get; } = DateTime.Now;
        public string Data { get; set; }
        public string Hash { get; set; }
        public string PreviousHash { get; set; }
        public int Nonce { get; set; }

        public Block(string data, string previousHash="")
        {
            Id = Guid.NewGuid();
            Data = data;
            PreviousHash = previousHash;
            Hash = CalculateHash();
            Nonce = 0;
        }

        public string CalculateHash()
        {
            string dataToHash = $"{Id}{TimeStamp}{PreviousHash}{JsonConvert.SerializeObject(Data)}{Nonce}";
            return SHA256Hasher.ComputeStringToSha256Hash(dataToHash);
        }
    }
}
