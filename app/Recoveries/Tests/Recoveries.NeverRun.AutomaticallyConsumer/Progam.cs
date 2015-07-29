namespace Recoveries.NeverRun.AutomaticallyConsumer
{
    public class Progam
    {
        static void Main(string[] args)
        {
            var consumer = new CauseErrorQueueConsumer();
            consumer.Start();
        }
    }
}
