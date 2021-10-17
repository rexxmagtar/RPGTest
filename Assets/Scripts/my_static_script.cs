using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class my_static_script
{
    public static  GameObject gamecontroller;
    public static bool is_it_new_game = true;
    public static Coroutine cor;
    public static IEnumerator invicsibile(float sec,Characters.Wizard mage)
    {
        Debug.Log("Вы бессмертны");
        int hp_start = mage.Hp;
        int max_hp = mage.MaxHp;
        mage.MaxHp = 999999999;
        mage.Hp = 999999;
        yield return new WaitForSeconds(sec);
        mage.MaxHp = max_hp;
        mage.Hp = hp_start;
    }
   
}
