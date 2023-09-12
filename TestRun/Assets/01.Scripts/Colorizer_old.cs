using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Colorizer_old : MonoBehaviour
{
    // ����Ʈ���μ�������.�÷��׷��̵�

    ColorGrading colorGrading = default;
    public float hueShiftSpeed = 10;

    void Start()
    {
        var postProcessVolume = FindObjectOfType<PostProcessVolume>();
        colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();
    }

    void Update()
    {
        colorGrading.hueShift.value += hueShiftSpeed * Time.deltaTime;
    }
}