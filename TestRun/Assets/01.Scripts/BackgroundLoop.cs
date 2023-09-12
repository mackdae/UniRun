using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 10f; // 이동속도
    public float width = 40.96f; // 배경의 가로길이

    //private void Awake() // 가로길이 측정
    //{ width = GetComponent<BoxCollider2D>().size.x; }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        // 초당 speed의 속도로 왼쪽으로 평행이동

        if (transform.position.x <= -width) { Reposition(); }
        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동하면 위치 재배치
    }

    private void Reposition() // 위치 재배치 메서드
    {
        // 현재 위치에서 오른쪽으로 가로길이 *2만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}