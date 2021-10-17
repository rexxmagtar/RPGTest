using Interfaces;
using UnityEngine.AI;
using UnityEngine;

namespace Artefacts
{
    abstract public class Artefact :MonoBehaviour
    {
        public int count_of_bottles = 0;
        public Sprite icon;

        public int id_;
        public GameObject prefab;
        public int ArtefactPower;
        public abstract bool IsRenewable { get; }
        abstract public void SkillEffect(object Character);
        public string name_;
    }
   
}