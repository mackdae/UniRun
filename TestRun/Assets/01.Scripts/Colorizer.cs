using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Colorizer : MonoBehaviour
{
    // ��������Ʈ������.�÷�

    public float colorSpeed = 10;

    SpriteRenderer spriteRenderer;
    float colorH;
    float colorS;
    float colorV;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Color.RGBToHSV(spriteRenderer.color, out colorH, out colorS, out colorV);
        colorH = colorH * 360;
}
    void Update()
    {
        colorH += colorSpeed * Time.deltaTime;
        spriteRenderer.color = Color.HSVToRGB(colorH % 360 / 360, colorS, colorV);
    }
}