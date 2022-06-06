namespace Hw2_SOLID
{
    public class PhoneManager
    {
        private readonly IVideoCall _videocall;
        private readonly IVoiceCall _voicecall;
        private readonly ISendMMS _sendmms;

        public PhoneManager(IVideoCall videocall, IVoiceCall voicecall, ISendMMS sendmms)
        {
            _videocall = videocall;
            _voicecall = voicecall;
            _sendmms = sendmms;
        }
        public void SendMMS()
        {
            _sendmms.MMS();
        }
        public void VoiceCall()
        {
            _voicecall.Call();
        }
        public void VideoCall()
        {
            _videocall.VideoCall();
        }
    }

}
