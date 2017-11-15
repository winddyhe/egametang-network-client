using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct SessionFrameMessage
    {
        public NetworkSession   Session;
        public FrameMessage     FrameMessage;
    }

    public class ClientFrameComponent
    {
        public long Id;
        public int Frame;

        public EQueue<SessionFrameMessage> Queue = new EQueue<SessionFrameMessage>();

        public int count = 1;

        public int waitTime;

        public const int maxWaitTime = 40;

        public void Start()
        {
            UpdateAsync();
        }

        public void Add(ASession session, FrameMessage frameMessage)
        {
            this.Queue.Enqueue(new SessionFrameMessage() { Session = session as NetworkSession, FrameMessage = frameMessage });
        }

        public async void UpdateAsync()
        {
            //TimerComponent timerComponent = Game.Scene.GetComponent<TimerComponent>();
            //while (true)
            //{
            //    // 如果队列中消息多于4个，则加速跑帧
            //    this.waitTime = maxWaitTime;
            //    if (this.Queue.Count > 4)
            //    {
            //        this.waitTime = maxWaitTime - (this.Queue.Count - 4) * 2;
            //    }
            //    // 最快加速一倍
            //    if (this.waitTime < 20)
            //    {
            //        this.waitTime = 20;
            //    }

            //    await timerComponent.WaitAsync(waitTime);

            //    if (this.Id == 0)
            //    {
            //        return;
            //    }

            //    this.UpdateFrame();
            //}
        }

        private void UpdateFrame()
        {
            //if (this.Queue.Count == 0)
            //{
            //    return;
            //}
            //SessionFrameMessage sessionFrameMessage = this.Queue.Dequeue();
            //this.Frame = sessionFrameMessage.FrameMessage.Frame;

            //for (int i = 0; i < sessionFrameMessage.FrameMessage.Messages.Count; ++i)
            //{
            //    AFrameMessage message = sessionFrameMessage.FrameMessage.Messages[i];
            //    ushort opcode =  NetworkOpcodeType.Instance.GetOpcode(message.GetType());
            //    Game.Scene.GetComponent<MessageDispatherComponent>().Handle(sessionFrameMessage.Session, new MessageInfo() { Opcode = opcode, Message = message });
            //}
        }
    }
}
