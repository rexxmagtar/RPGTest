using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Artefacts;
using Characters;


public class VasiliskEye : Artefact
{
    uint ArtefactPower = 0;
    public bool isRenewable = false;

    public override bool IsRenewable { get { return isRenewable; } }
    public override void SkillEffect(object Character)
    {
        throw new System.NotImplementedException();
    }

    public VasiliskEye(uint ArtefactPower)
    {
        this.ArtefactPower = ArtefactPower;
        name = "VasiliskEye";
    }

    public void SkillEffect(object ch, int skillpower)
    {
        if (ch.GetType() == typeof(Character) || ch.GetType() == typeof(Wizard))
        {
            if((ch as Character).CurrentCondition != Character.Condition.Dead)
            (ch as Character)._isParalized = true;
        }
        else Debug.Log("VasiliskEye.SkillEffect wrong target: " + ch.ToString());
    }
}