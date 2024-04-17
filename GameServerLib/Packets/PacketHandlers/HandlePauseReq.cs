using GameServerCore.Packets.Handlers;
using GameServerCore.Packets.PacketDefinitions.Requests;

namespace LeagueSandbox.GameServer.Packets.PacketHandlers
{
    public class HandlePauseReq : PacketHandlerBase<PauseRequest>
    {
        private readonly Game _game;

        public HandlePauseReq(Game game)
        {
            _game = game;
        }

        public override bool HandlePacket(int userId, PauseRequest req)
        {
            //_game.Pause();
            _game.ChatCommandManager.SendDebugMsgFormatted(Chatbox.DebugMsgType.INFO, "Due to people exploiting it, the pause feature was indefinitely disabled.");
            _game.ChatCommandManager.SendDebugMsgFormatted(Chatbox.DebugMsgType.INFO, "由于玩家滥用暂停功能，暂停功能已被永久禁用.");
            return true;
        }
    }
}