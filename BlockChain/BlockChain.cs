using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class BlockChain
    {
        private readonly List<Block> _chain;
        private readonly int _difficulty;

        public BlockChain()
        {
            _chain = new List<Block>() { CreateGenesisBlock() };
            _difficulty = 2;
        }

        private Block CreateGenesisBlock()
        {
            return new Block("Genesis Block", "0000");
        }

        public Block GetLatestBlock()
        {
            DateTime latest = _chain.Max(b => b.TimeStamp);
            return _chain.FirstOrDefault(b => b.TimeStamp == latest);
        }

        private void MineBlock(Block block)
        {
            Console.WriteLine("Started mining");
            string zeros = String.Join("", new int[_difficulty]);
            while (block.Hash.Substring(0, _difficulty) != zeros)
            {
                block.Nonce++;
                block.Hash = block.CalculateHash();
            }
            Console.WriteLine("Finished mining");
        }

        public void AddNewBlock(Block newBlock)
        {
            newBlock.PreviousHash = GetLatestBlock().Hash;
            newBlock.Hash = newBlock.CalculateHash();
            MineBlock(newBlock);
            _chain.Add(newBlock);
        }

        public bool IsValidChain()
        {
            
            for (int i = 1; i < _chain.Count; i++)
            {
                Block currentBlock = _chain[i];
                Block previousBlock = _chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if (previousBlock.Hash != currentBlock.PreviousHash)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
