using System;
using Characters;
using UnityEngine;
namespace Spells
{
    public class CureSpell : Spells
    {
        
        public override bool IsVerbal => true;
        public override bool IsMovement => false;
        public override int ManaCost => 20;

       public CureSpell()
        {
            name = "Cure Spell";
        }
        
        public override void SkillEffect(object effectedCharacter, int effectPower = 1)
        {
            if (effectedCharacter.GetType() == typeof(Wizard))
            {
                var curedCharacter = effectedCharacter as Wizard;
                if (curedCharacter.Mana >= ManaCost)
                {
                    if (curedCharacter.CurrentCondition == Character.Condition.Weak )
                    {
                        curedCharacter.CurrentCondition = Character.Condition.Normal;
                        curedCharacter.Mana -= ManaCost;
                    }  
                    

                }
                
                
            }
            
            
        }

    }
}