using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Artefacts;
using Characters;

namespace Artefacts
{

    public class DeadWater : Artefact
    {
     
        public bool isRenewable = true;
        public enum size { small, big, middle };
        public size size_;
       
        
        public override bool IsRenewable { get { return isRenewable; } }

        public DeadWater(size s)
        {
            icon = Resources.Load("Mana_water") as Sprite;
            name_ = "DeadWater";
            size_ = s;
            if (size_ == size.small)
                ArtefactPower = 10;
            if (size_ == size.middle)
                ArtefactPower = 25;
            if (size_ == size.big)
                ArtefactPower = 50;

        }

        public override void SkillEffect(object ch)
        {
            if (ch.GetType() == typeof(Wizard))
            {
                Debug.Log("Мана восстановлена на  " + ArtefactPower);
                (ch as Wizard).Mana += ArtefactPower;
            }
            else if (ch.GetType() == typeof(Character))
            { }

            else Debug.Log("DeadWater.SkillEffect wrong target: " + ch.ToString());
        }
    }
}