using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChangeScript : MonoBehaviour
{
    Texture2D mColorSwapTex;
    Color[] mSpriteColors;

    SpriteRenderer mSpriteRenderer;

    private void Awake()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InitColorSwapTex();
        SwapColor(SwapIndex.Gun, new Color(0, 232, 216));
        mColorSwapTex.Apply();
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
        Cloth =252,
    }

    public void SwapColor(SwapIndex index, Color color)
    {
        mSpriteColors[(int)index] = color;
        mColorSwapTex.SetPixel((int)index, 0, color);
    }

    public void InitialColors()
    {
        SwapColor(SwapIndex.Armor, new Color(216,40,0));
        SwapColor(SwapIndex.Gun, new Color(0,148,0));
        SwapColor(SwapIndex.Cloth, new Color(252,152,56));
        mColorSwapTex.Apply();
    }

    public void NormalGravity()
    {
        SwapColor(SwapIndex.Armor, new Color(216, 40, 0));
        SwapColor(SwapIndex.Cloth, new Color(252, 152, 56));
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

    public void Normalbullet ()
    {
        SwapColor(SwapIndex.Gun, new Color(0, 148, 0));
        mColorSwapTex.Apply();
    }
}
