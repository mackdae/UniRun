using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 10f; // �̵��ӵ�
    public float width = 40.96f; // ����� ���α���

    //private void Awake() // ���α��� ����
    //{ width = GetComponent<BoxCollider2D>().size.x; }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        // �ʴ� speed�� �ӵ��� �������� �����̵�

        if (transform.position.x <= -width) { Reposition(); }
        // ���� ��ġ�� �������� �������� width �̻� �̵��ϸ� ��ġ ���ġ
    }

    private void Reposition() // ��ġ ���ġ �޼���
    {
        // ���� ��ġ���� ���������� ���α��� *2��ŭ �̵�
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}