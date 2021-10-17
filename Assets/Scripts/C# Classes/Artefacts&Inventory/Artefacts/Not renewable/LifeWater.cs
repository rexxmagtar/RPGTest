using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;


namespace Artefacts
{
    public class LifeWater : Artefact
    {
        
        private uint ArtefactPwer = 0;
        private bool isRenewable = false;
        public enum size { small, big, middle };
        public size size_;

        public override bool IsRenewable { get { return isRenewable; } }
       

        public LifeWater(size s)
        {
            name_ = "LifeWater";
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
                (ch as Wizard).Hp += ArtefactPower;
            }
            else if (ch.GetType() == typeof(Character))
            { }

            else Debug.Log("LifeWater.SkillEffect wrong target: " + ch.ToString());
        }
    }
}