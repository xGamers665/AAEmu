﻿using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;
using AAEmu.Game.Core.Packets.G2C;

namespace AAEmu.Game.Core.Packets.C2G
{
    public class CSChallengeDuelPacket : GamePacket
    {
        public CSChallengeDuelPacket() : base(0x050, 1)
        {
        }

        public override void Read(PacketStream stream)
        {
            var challengedId = stream.ReadUInt32(); // Id whom challenged to a duel

            var challengerId = Connection.ActiveChar.Id;

            Connection.ActiveChar.BroadcastPacket(new SCDuelChallengedPacket(challengerId), false); // we send only to the enemy

            _log.Warn("ChallengeDuel, challengerId: {0}, challengedId: {0}", challengerId, challengedId);
        }
    }
}
