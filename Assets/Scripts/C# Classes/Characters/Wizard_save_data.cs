using System;
using System.Collections.Generic;
using Spells;
using UnityEngine;

namespace Characters
{
    [Serializable]
    public class Wizard_save_data : Character_save_data
    {
        public int _mana;
        public int mana_regen;
        public Wizard_save_data() { }
        public List<Spells.Spells> spellscroll;
        public int Mana
        {
            get => _mana;
            set => _mana = value;
        }
        public void LearnSpell(Spells.Spells spell)
        {
            spellscroll.Add(spell);
        }

        public void UseSpell(string speellname, Character target)
        {
            foreach (var spell in spellscroll)
                if (spell.name == Name)
                {
                    spell.SkillEffect(target);
                    break;
                }
        }
        public void ForgetSpell(string name)
        {
            foreach (var spell in spellscroll)
            {
                if (spell.name == name)
                    spellscroll.Remove(spell);
            }
        }
        public void GetMana(int plusMana)
        {
            this.Mana += plusMana;
            if (Mana > max_Mana) Mana = max_Mana;
        }
        public  int max_Mana = 100;

        public Wizard_save_data(string aName, Race aRace, Gender aGender, int aAge) : base(aName, aRace, aGender, aAge)
        {
            Intellegency = 100;
            Power = 10;
            Agility = 20;
            Armor = 15;
            Mana = max_Mana;
        }
        public Wizard_save_data(Wizard saved) : base(saved)
        {
          
            Mana = saved.Mana;
            max_Mana = saved.max_Mana;
            mana_regen = saved.mana_regen;
        }







        //        public void UseHealingSpell()
        //        {
        //            var spell = new HealingSpell();
        //            spell.SkillEffect(this, this.Intellegency);
        //            
        //        }
        //        public void UseCureSpell()
        //        {
        //            var spell = new CureSpell();
        //            spell.SkillEffect(this, this.Intellegency);
        //         
        //        }
        //        public void UseAntidoteSpell()
        //        {
        //            var spell = new AntidoteSpell();
        //            spell.SkillEffect(this, this.Intellegency);
        //          
        //        }
        //        public void UseArmorSpell()
        //        {
        //            var spell = new ReviveSpell();
        //            spell.SkillEffect(this, this.Intellegency);
        //        
        //        }
        //
        public void DoFireBall(object atackedCharacter)
        {
            var currentFireball = new FireBall();
            if (this.Mana >= currentFireball.ManaCost)
            {
                currentFireball.SkillEffect(atackedCharacter, Intellegency);
            }
            else throw new ArgumentException("Недостаточно маны!");
        }
    }
}