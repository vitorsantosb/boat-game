using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    [SerializeField] private Sprite spriteToChange;

    private Image mySourceImage;
    private void Start()
    {
        mySourceImage = GetComponent<Image>();
    }

    public void ChangeSprite()
    {
        mySourceImage.sprite = spriteToChange;
    }
}
