using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; // 이동속도

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // 초당 speed의 속도로 왼쪽으로 평행이동
    }
}