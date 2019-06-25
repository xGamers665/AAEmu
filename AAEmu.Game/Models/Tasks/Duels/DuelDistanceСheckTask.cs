﻿using AAEmu.Game.Core.Managers;
using AAEmu.Game.Core.Network.Connections;
using AAEmu.Game.Models.Game.Duels;

namespace AAEmu.Game.Models.Tasks.Duels
{
    public class DuelDistanceСheckTask : Task
    {
        protected Duel _duel;
        protected uint _challengerId;
        protected uint _challengedId;

        public DuelDistanceСheckTask(Duel duel)
        {
            _duel = duel;
            _challengerId = duel.Challenger.Id;
            _challengedId = duel.Challenged.Id;
        }

        public override void Execute()
        {
            if(_duel.DuelDistanceСheckTask == null)
                return;

            var res = DuelManager.Instance.DuelDistanceСheck(_challengerId);
            if (res == DuelDistance.ChallengerFar)
            {
                DuelManager.Instance.DuelStop(_challengedId, DuelDetType.Surrender, _challengerId);
            }
            else if (res == DuelDistance.ChallengedFar)
            {
                DuelManager.Instance.DuelStop(_challengerId, DuelDetType.Surrender, _challengedId);
            }
        }
    }
}
