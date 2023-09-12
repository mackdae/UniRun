using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Colorizer_old : MonoBehaviour
{
    // 포스트프로세스볼륨.컬러그레이딩

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