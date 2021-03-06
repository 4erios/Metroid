﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChangeScript : MonoBehaviour
{
    Texture2D mColorSwapTex;
    Texture2D baseColor;
    Color[] mSpriteColors;

    SpriteRenderer mSpriteRenderer;
    private IEnumerator coroutine;
    

    private void Awake()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InitColorSwapTex();
        //SwapColor(SwapIndex.Gun, new Color(0, 232, 216));
        //mColorSwapTex.Apply();
    }

    public void InitColorSwapTex()
    {
        Texture2D colorSwapTex = new Texture2D(256, 1, TextureFormat.RGBA32, false, false);
        colorSwapTex.filterMode = FilterMode.Point;

        for (int i = 0; i < colorSwapTex.width; ++i)
            colorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));

        colorSwapTex.Apply();



        mSpriteRenderer.material.SetTexture("_SwapTex", colorSwapTex);

        mSpriteColors = new Color[colorSwapTex.width];
        mColorSwapTex = colorSwapTex;
    }


    public enum SwapIndex
    {
        Armor = 216,
        Gun = 0,
        Cloth = 252,
    }

    private void SwapColor(SwapIndex index, Color color)
    {
        mSpriteColors[(int)index] = color;
        mColorSwapTex.SetPixel((int)index, 0, color);
    }

    public void InitialColors()
    {
        SwapColor(SwapIndex.Armor, new Color(216, 40, 0));
        SwapColor(SwapIndex.Gun, new Color(0, 148, 0));
        SwapColor(SwapIndex.Cloth, new Color(252, 152, 56));
        mColorSwapTex.Apply();
    }

    public void NormalGravity()
    {
        ClearColor(SwapIndex.Armor);
        ClearColor(SwapIndex.Cloth);
        mColorSwapTex.Apply();
    }

    public void InverseGravity()
    {
        SwapColor(SwapIndex.Armor, new Color(228, 0, 88));
        SwapColor(SwapIndex.Cloth, new Color(252, 228, 160));
        mColorSwapTex.Apply();
    }

    public void MissileColors()
    {
        SwapColor(SwapIndex.Gun, new Color(0, 232, 216));
        mColorSwapTex.Apply();
    }

    public void NormalBullet()
    {
        ClearColor(SwapIndex.Gun);
        mColorSwapTex.Apply();
    }

    private IEnumerator HitEffect(float time, float flashTime)
    {
        for (float f = time; f >= 0; f -= (2*flashTime))
        {
            SwapAllSpritesColorsTemporarily(Color.white);
            yield return new WaitForSeconds(flashTime);
            ResetAllSpritesColors();
            yield return new WaitForSeconds(flashTime);
        }
        ResetAllSpritesColors();
    }

    //UTILITY
    private void ResetAllSpritesColors()
    {
        for (int i = 0; i < mColorSwapTex.width; ++i)
            mColorSwapTex.SetPixel(i, 0, mSpriteColors[i]);
        mColorSwapTex.Apply();
    }

    private void ClearColor(SwapIndex index)
    {
        Color c = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        mSpriteColors[(int)index] = c;
        mColorSwapTex.SetPixel((int)index, 0, c);
        mColorSwapTex.Apply();
    }

    private void SwapAllSpritesColorsTemporarily(Color color)
    {
        for (int i = 0; i < mColorSwapTex.width; ++i)
            mColorSwapTex.SetPixel(i, 0, color);
        mColorSwapTex.Apply();
    }

    private void ClearAllSpritesColors()
    {
        for (int i = 0; i < mColorSwapTex.width; ++i)
        {
            mColorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));
            mSpriteColors[i] = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        mColorSwapTex.Apply();
    }

    

    public void StartHitEffect(float time , float flashTime =0.1f)
    {
        coroutine = HitEffect(time, flashTime);
        StartCoroutine(coroutine);
    }

    public void Update()
    {
      

        if (Input.GetKeyDown(KeyCode.Y))
        {
            StartHitEffect(2f);
        }
    }
}
    
