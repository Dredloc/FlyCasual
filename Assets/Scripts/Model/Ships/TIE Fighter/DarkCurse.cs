﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    namespace TIEFighter
    {
        public class DarkCurse : TIEFighter
        {
            public DarkCurse() : base()
            {
                PilotName = "\"Dark Curse\"";
                ImageUrl = "https://vignette1.wikia.nocookie.net/xwing-miniatures/images/4/49/Dark_Curse.png";
                isUnique = true;
                PilotSkill = 6;
                Cost = 16;
            }

            public override void InitializePilot()
            {
                base.InitializePilot();
                OnAttack += AddDarkCursePilotAbility;
                OnDefence += RemoveDarkCursePilotAbility;
            }

            public void AddDarkCursePilotAbility()
            {
                if ((Combat.AttackStep == CombatStep.Attack) && (Combat.Defender.PilotName == PilotName)) {
                    //Game.UI.ShowError("Dark Curse: Debuf On");
                    Combat.Attacker.OnTrySpendFocus += UseDarkCurseFocusRestriction;
                    Combat.Attacker.OnTryReroll += UseDarkCurseRerollRestriction;
                }
            }

            private void UseDarkCurseFocusRestriction(ref bool result)
            {
                Game.UI.ShowError("Dark Curse: Cannot spend focus");
                result = false;
            }

            private void UseDarkCurseRerollRestriction(ref bool result)
            {
                Game.UI.ShowError("Dark Curse: Cannot reroll");
                result = false;
            }

            public void RemoveDarkCursePilotAbility()
            {
                if ((Combat.AttackStep == CombatStep.Defence) && (Combat.Defender.PilotName == PilotName))
                {
                    //Game.UI.ShowInfo("Dark Curse: Debuf Off");
                    Combat.Attacker.OnTrySpendFocus -= UseDarkCurseFocusRestriction;
                    Combat.Attacker.OnTryReroll -= UseDarkCurseRerollRestriction;
                }
            }

        }
    }
}