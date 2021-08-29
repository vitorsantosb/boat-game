using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    [SerializeField] private Sprite spriteToChange;

    private Sprite oldSprite;
    private Image mySourceImage;
    private void Start()
    {
        mySourceImage = GetComponent<Image>();

        oldSprite = mySourceImage.sprite;
    }

    public void ChangeSprite()
    {
        mySourceImage.sprite = spriteToChange;
    }

    public void InvertChangeSprite()
    {
        mySourceImage.sprite = oldSprite;
    }
}
