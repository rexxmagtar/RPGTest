using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;
namespace Artefacts
{
    public class poisoned : Artefact
    {
        private int ArtefactPwer = 0;
        private bool isRenewable = true;

        public GameObject poison;
        Coroutine cor;

        public override bool IsRenewable { get { return isRenewable; } }


        public poisoned(int power)
        {
            name_ = "Poison";
            ArtefactPwer = power;
           

        }
        public void poison_func(object ch)
        {
            Debug.Log("выполняем отравление");
                (ch as Character).CurrentCondition = Character.Condition.Poisoned;
            cor = StartCoroutine(got_poisoned(3, ch));
            

        }
        public override void SkillEffect(object ch)
        {
            poison = (ch as Wizard).Poison_prefab;
            poison.GetComponent<poison_parametrs>().poison = this;
            poison.GetComponent<poison_parametrs>().atacker = (ch as Wizard).gameObject;
            Vector3 pos_ = (ch as Wizard).gameObject.transform.position;
            Instantiate(poison, new Vector3(pos_.x,pos_.y+2,pos_.z),new Quaternion());
           
        }

        public  IEnumerator got_poisoned(float time, object ch)
        {
            for(int i = 0; i < time; i++)
            {
                yield return new WaitForSeconds(1);
                (ch as Wizard).Hp -= ArtefactPower / 20;
                ArtefactPwer -= ArtefactPwer / 20;
            }
        }
    }
}
