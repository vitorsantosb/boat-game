using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Image[] lifeBars = new Image[5];

    private Damage dmg;
    private int lifeAmount = 40;

    private void Start()
    {
        dmg = GetComponent<Damage>();
    }

    public void HP_Change()
    {
        if (dmg.GetMyHP() <= lifeAmount)
        {
            for (int i = 0; i < lifeBars.Length; i++)
            {
                print(dmg.GetMyHP());
                if (i * 10 == dmg.GetMyHP())
                {
                    lifeBars[i].GetComponent<SpriteChange>().ChangeSprite();
                }
            }
            lifeAmount -= 10;
        }
    }

    private void Update()
    {
        HP_Change();
    }
}
