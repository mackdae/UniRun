using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles; // 장애물 오브젝트들
    private bool stepped = false; // 밟음 여부

    private void OnEnable() // 컴포넌트가 활성화될 때마다 실행하는 메서드 // 오브젝트 활성화시에도 발동
    { // 발판 리셋처리
        stepped = false; // 밟힘 리셋
        for (int i = 0; i < obstacles.Length; i++) // 장애물 수만큼 루프
        {
            if (Random.Range(0,3)==0) // 현재 순번의 장애물을 1/3확률로 활성화
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { // 플레이어 캐릭터가 자신을 밟았을 때 점수 추가 처리
        if(collision.collider.tag == "Player" && !stepped)
        { // 충돌한 상대의 태그가 플레이어이고 이전에 밟지 않았다면
            stepped = true;
            GameManager.instance.AddScore(1);
            // 점수를 추가하고 밟힘여부 트루
        }
    }
}