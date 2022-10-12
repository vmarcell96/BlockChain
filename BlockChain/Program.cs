
namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var testCoin = new BlockChain(1);
                Block testBlock1 = new Block(" Amount : 20 ");
                Block testBlock2 = new Block(" Amount : 30 ");
                testCoin.AddNewBlock(testBlock1);
                testCoin.AddNewBlock(testBlock2);
                Console.Clear();
                Console.WriteLine("All blocks are added");
                if (!testCoin.IsValidChain())
                {
                    throw new Exception("The blockchain is invalid.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}


