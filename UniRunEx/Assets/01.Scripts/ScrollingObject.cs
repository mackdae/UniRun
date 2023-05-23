using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public static GameManager temp;
    public float speed = 10f; // 이동속도

    void Update()
    {
        //Debug.Log(temp);
        //temp = GameManager.instance;
        //Debug.Log(temp);
        //Debug.Log(temp.isGameover);
        //if(!temp.isGameover)

        if(!GameManager.instance.isGameover) // 게임오버가 아니면
        transform.Translate(Vector3.left * speed * Time.deltaTime); // 초당 speed의 속도로 왼쪽으로 평행이동
    }
}