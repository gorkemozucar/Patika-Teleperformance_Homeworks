namespace Hw2_SOLID
{
    public class NewPhone : IVideoCall , ISendMMS
    
    {
        public void MMS()
        {
            Console.WriteLine("New Phone can send MMS.");
        }

        public void VideoCall()
        {
            Console.WriteLine("New Phone can do voicecall...");
        }
    }
}
