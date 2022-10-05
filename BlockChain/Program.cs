

namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var secretKey = SecretKeyGenerator.GenerateSecretKey();
            //Console.WriteLine(secretKey);

            var testCoin = new BlockChain();
            Block testBlock1 = new Block( " Amount : 20 ");
            Block testBlock2 = new Block(" Amount : 30 ");
            testCoin.AddNewBlock(testBlock1);
            testCoin.AddNewBlock(testBlock2);

            //testBlock2.Data = "Amount 50";

            Console.WriteLine(testCoin.IsValidChain());
        }
    }
}


