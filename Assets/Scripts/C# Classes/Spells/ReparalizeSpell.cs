using Characters;
using System;
namespace Spells
{
    public class ReparalizeSpell : Spells
    {
        public override int ManaCost => 85;
        public override bool IsVerbal => false;
        public override bool IsMovement => false;

        ReparalizeSpell()
        {
            name = "Reparalize Spell";
        }
        public override void SkillEffect(object effectedCharacter, int effectPower = 1)
        {
            if (effectedCharacter.GetType() == typeof(Wizard))
            {
                var reparalizedCharacter = effectedCharacter as Wizard;
                if (reparalizedCharacter.Mana >= ManaCost)
                {
                    if (reparalizedCharacter.IsParalized == true)
                    {
                        reparalizedCharacter.IsParalized = false;
                        reparalizedCharacter.Hp = 1;
                        reparalizedCharacter.Mana -= ManaCost;

                    }
                    else throw new ArgumentException("Этот персонаж не парализован!");

                }
                else
                    throw new ArgumentException("Недостаточно маны!");
            }
            else
                throw new ArgumentException("Этот персонаж не владеет магией!");
        }
    }
}