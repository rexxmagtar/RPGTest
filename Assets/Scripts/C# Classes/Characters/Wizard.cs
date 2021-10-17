using System;
using System.Collections;
using System.Collections.Generic;
using Spells;
using UnityEngine;

namespace Characters
{
    public class Wizard : Character
    {
        public Spells.ArmorSpell Armor_spell;
        public int _mana;
        public GameObject heal_;
        public int mana_regen=2;
     public Wizard() { }
        public GameObject lightning;

       
        public Coroutine cor1;
        public List<Spells.Spells> spellscroll;
        public int Mana
        {
            get => _mana;
            set { _mana = value;
                if (mana_bar != null)
                {
                    mana_bar.value = value;
                }
                menu.GetComponent<canvas_controller>().update_bars();
            }
        }

        public IEnumerator regen_func()
        {
            while (true)
            {
                GetMana(mana_regen);
                Hp += 2;
                yield return new WaitForSeconds(1);
            }
        }




        public new void Start()
        {
            Debug.Log("Привет Я маг");
            health_bar.maxValue = MaxHp;
            MovingAble = true;
            health_bar.value = Hp;
            mana_bar.maxValue = max_Mana;
            mana_bar.value = Mana;
            cor1 = StartCoroutine(regen_func());
            
          
        }

        
        public void LearnSpell(Spells.Spells spell)
        {
            spellscroll.Add(spell);
            
        }

        public void UseSpell(string speellname, Character target)
        {
            foreach(var spell in spellscroll)
                if (spell.name == name)
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
        public int max_Mana;
        
        public Wizard(string aName, Race aRace, Gender aGender, int aAge) : base(aName, aRace, aGender, aAge)
        {
            Intellegency = 100;
            Power = 10;
            Agility = 20;
            Armor = 15;
            Mana = max_Mana;
        }

        public void  Wizard_get_save(Wizard_save_data saved) 
        {

            get_save(saved);
            Mana = saved.Mana;
            max_Mana = saved.max_Mana;
            mana_regen = saved.mana_regen;
        }



        public void UseHealingSpell()
        {
            var spell = new HealingSpell();
            spell.SkillEffect(this, this.Intellegency);

        }
        public void UseCureSpell()
        {
            var spell = new CureSpell();
            spell.SkillEffect(this, this.Intellegency);

        }
        public void UseAntidoteSpell()
        {
            var spell = new AntidoteSpell();
            spell.SkillEffect(this, this.Intellegency);

        }

        public void UseReviveSpell()
        {
            var spell = new ReviveSpell();
            spell.SkillEffect(this, this.Intellegency);

        }

        public void UseArmorSpell()
        {
            var spell = new ArmorSpell();
            spell.SkillEffect(this, this.Intellegency);
        }

        public void DoFireBall(object atackedCharacter)
        {
            var currentFireball = new FireBall();
            if (this.Mana >= currentFireball.ManaCost)
            {
                currentFireball.SkillEffect(atackedCharacter, Intellegency);
                
            }

        }
    }
}