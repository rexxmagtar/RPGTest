using System;
using Characters;
namespace Spells
{
    public class HealingSpell : Spells
    {
       
        public override bool IsVerbal => true;
        public override bool IsMovement => false;
        public override int ManaCost => 50;
        private int _heal = 30;

        public HealingSpell()
        {
            name = "Healing Spell";
        }

        public override void SkillEffect(object effectedCharacter, int effectPower = 1)
        {
          
            if (effectedCharacter.GetType() == typeof(Wizard))
            {
                var healedCharacter = effectedCharacter as Wizard;
                if (healedCharacter.Mana > ManaCost)
                {
                    _heal *= effectPower;
                    if (healedCharacter.Hp > healedCharacter.MaxHp)
                    {
                        throw new ArgumentException("Здоровье персонажа масимальное!");
                    }

                    if (healedCharacter.Hp +_heal> healedCharacter.MaxHp)
                    {
                        healedCharacter.Hp = healedCharacter.MaxHp;
                        healedCharacter.Mana -= 2*(healedCharacter.MaxHp-healedCharacter.Hp);
                    }
                    else
                    {
                        healedCharacter.Hp += _heal;
                        healedCharacter.Mana -=2*_heal;
                    }
                }
                else
                    throw new ArgumentException("Недостаточно маны!");
            }
            
            else
                throw new ArgumentException("Этот персонаж не владеет магией!");
        }

    }
}