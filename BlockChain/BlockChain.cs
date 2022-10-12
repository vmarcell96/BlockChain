namespace BlockChain
{
    public class BlockChain
    {
        private readonly List<Block> _chain;
        private readonly int _difficulty;

        public BlockChain(int difficulty)
        {
            _chain = new List<Block>() { CreateGenesisBlock() };
            _difficulty = difficulty;
        }

        private Block CreateGenesisBlock()
        {
            return new Block("Genesis Block", "0000");
        }

        public Block GetLatestBlock()
        {
            return _chain[_chain.Count-1];
        }

        //Proof of work implementation
        //Repeat hashing until the result hash's first [difficulty] character is "0";
        private void MineBlock(Block block)
        {
            Console.WriteLine($"Press any key to start mining Block: #{block.Id}");
            Console.ReadKey();
            string zeros = String.Join("", new int[_difficulty]);
            while (block.Hash.Substring(0, _difficulty) != zeros)
            {
                //changing the Nonce number creates an completely new hash
                block.Nonce++;
                block.Hash = block.CalculateHash();
                Console.WriteLine(block.Hash);
                System.Threading.Thread.Sleep(200);
            }
            Console.WriteLine("");
            Console.WriteLine($"Finished mining Block: #{block.Id}");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void AddNewBlock(Block newBlock)
        {
            newBlock.PreviousHash = GetLatestBlock().Hash;
            newBlock.Hash = newBlock.CalculateHash();
            MineBlock(newBlock);
            _chain.Add(newBlock);
        }

        public Block this[int index]
        {
            get => _chain[index];
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
