using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    [SerializeField] private Sprite spriteToChange;

    private Sprite mySourceImage;
    private void Start()
    {
        mySourceImage = GetComponent<Image>().sprite;
    }

    public void ChangeSprite()
    {
        mySourceImage = spriteToChange;
    }
}
