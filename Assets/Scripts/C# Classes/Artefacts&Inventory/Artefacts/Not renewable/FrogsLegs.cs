using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Artefacts;
using Characters;

namespace Artefacts
{


    public class FrogsLegs : Artefact
    {
        
        public bool isRenewable = false;

        public override bool IsRenewable { get { return isRenewable; } }


        public FrogsLegs()
        {
            name_ = "FrogsLegs";
        }

        public override void SkillEffect(object ch)
        {

            if (ch.GetType() == typeof(Wizard))
            {
                if ((ch as Character).IsSick)
                {
                    (ch as Character).IsSick = false;
                }
            }

        }
    }
}