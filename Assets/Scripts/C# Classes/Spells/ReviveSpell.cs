using System;
using System.Data;
using Characters;
using static Characters.Wizard;

namespace Spells
{
    public class ReviveSpell : Spells
    {
        
        public override int ManaCost => 150;
        public override bool IsVerbal => false;
        public override bool IsMovement => false;

      public  ReviveSpell()
        {
            name = "Revive Spell";
        }
        public override void SkillEffect(object effectedCharacter, int effectPower = 1)
        {
            if (effectedCharacter.GetType() == typeof(Wizard))
            {
                var revivedCharacter = effectedCharacter as Wizard;
                if (revivedCharacter.Mana >= ManaCost)
                {
                    if (revivedCharacter.CurrentCondition == Character.Condition.Dead)
                    {
                        revivedCharacter.CurrentCondition = Character.Condition.Normal;
                        revivedCharacter.Hp = revivedCharacter.MaxHp;
                        revivedCharacter.Mana -= ManaCost;
                    }
                    

                    
                }
             
            }
         
        }
    }
}