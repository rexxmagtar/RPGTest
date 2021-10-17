using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Spells
{
    public abstract class Spells : MonoBehaviour, ISkill
    {
        public Coroutine cor;
        public string name;
        public bool is_learned=false;
        
        public abstract int ManaCost { get; }
        public abstract void SkillEffect(object effectedCharacter, int effectPower = 1);
        

        public abstract bool IsVerbal { get; }
        public abstract bool IsMovement { get; }
        
    }
}