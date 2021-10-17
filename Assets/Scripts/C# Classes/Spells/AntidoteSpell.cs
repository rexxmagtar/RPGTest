using System;
using Characters;
namespace Spells
{
    public class AntidoteSpell : Spells
    {
        public override int ManaCost => 30;

        public override bool IsVerbal => true;
        public override bool IsMovement => false;

       public  AntidoteSpell()
        {
            name = "Antidote Spell";
        }
        public override void SkillEffect(object effectedCharacter, int effectPower = 1)
        {
            if (effectedCharacter.GetType() == typeof(Wizard))
            {
                var poisonedCharacter = effectedCharacter as Wizard;
                if (poisonedCharacter.Mana >= ManaCost)
                {
                    if (poisonedCharacter.IsSick == true)
                    {
                        poisonedCharacter.IsSick = false;
                        poisonedCharacter.Mana -= ManaCost;
                    }
                   
                }
                
            }
       

        }
    }


}
