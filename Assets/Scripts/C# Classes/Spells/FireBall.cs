using Interfaces;
using System;
using Characters;
using UnityEngine;
namespace Spells
{
    public class FireBall : Spells
    {
        public override int ManaCost => 50;
        public override bool IsVerbal => true;
        public override bool IsMovement => true;
        public override void SkillEffect(object effectedCharacter, int effectPower = 1)
        {
            Debug.Log("Попытался нанести урон");
            if (effectedCharacter.GetType() == typeof(Characters.Enemy))
            {
                Debug.Log("Нанес урон");
                var atackedCharacter = effectedCharacter as Character;
                atackedCharacter.Hp -= effectPower;
            }

            
        }
   
    }
} 