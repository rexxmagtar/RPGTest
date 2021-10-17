using UnityEngine;
using Characters;
using System;
using System.Threading;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
namespace Spells
{
    public class ArmorSpell : Spells
    {


        

        public override int ManaCost => 100;
        public override bool IsVerbal => false;
        public override bool IsMovement => false;
        public Coroutine cor1;
        public Thread thread_cast;
        public int secs_dur=10;
        public Wizard revivedCharacter;

        public ArmorSpell()
        {
            name = "Armor Spell";
        }

        public  void casting()
        {
            
            Debug.Log("Вы бессмертны");
            int hp_start=revivedCharacter.Hp;
            int max_hp = revivedCharacter.MaxHp;
            float prop =1.0f*hp_start / max_hp;
            revivedCharacter.MaxHp = 999999;
            revivedCharacter.Hp = 999999;
            
                Thread.Sleep(secs_dur * 1000);
            
            Debug.Log("Вы снова обычный человек");
            revivedCharacter.MaxHp = max_hp;
            revivedCharacter.Hp = hp_start;
            
        }

        public override void SkillEffect(object effectedCharacter, int effectPower = 1)
        {
            if (effectedCharacter.GetType() == typeof(Wizard))
            {
                Wizard revivedCharacter = effectedCharacter as Wizard;
                if (revivedCharacter.Mana >= ManaCost)
                {
                    Debug.Log("Оживленный герой"+revivedCharacter);
                   
                    revivedCharacter.Mana -= ManaCost;
                   
                   



                }
                
                
            }
           
        }
    }
}