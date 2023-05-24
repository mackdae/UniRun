using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // 생성할 발판 프리팹
    public int count = 3; // 발판 생성수

    private float timeBetSpawn; // 다음 배치까지의 시간간격
    public float timeBetSpawnMin = 1.25f; // 최소치
    public float timeBetSpawnMax = 2.25f; // 최대치

    private float xPos = 20f; // 배치할 위치 X
    public float yMin = -3.5f; // 배치할 위치 Y 최소치
    public float yMax = 1.5f; // 배치할 위치 Y 최대치

    private GameObject[] platforms; // 생성한 발판들
    private int currentIndex = 0; // 사용할 현재 순번의 발판

    private Vector2 poolPosition = new Vector2(0, -25); //초반에 생성한 발판을 화면 밖에 숨겨둘 위치
    private float lastSpawnTime; // 마지막 배치 시점

    void Start() // 변수 초기화, 발판 생성
    { 
        platforms = new GameObject[count]; // count만큼의 공간을 가지는 새로운 발판 배열 생성

        for (int i = 0; i < count; i++) // count만큼 루프하며 발판 생성
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
            // platformPrefab의 인스턴스를 poolPosition 위치와 Quaternion 회전으로 복제생성, platform[]배열에 할당
            // Quaternion.identity 쿼터니언 아이덴티티 = 오일러 0,0,0
        }
        lastSpawnTime = 0f; // 마지막 배치 시점 초기화
        timeBetSpawn = 0f; // 다음번 배치까지의 시간간격을 0으로 초기화
    }

    void Update() // 주기적으로 발판 재배치
    {
        if(GameManager.instance.isGameover) // 게임오버 중에는 동작X
            return;

        if (Time.time >= lastSpawnTime + timeBetSpawn) // 마지막 배치 시점에서 timeBetSpawn 이상 시간이 흘렀다면
        {
            lastSpawnTime = Time.time; // 기록된 마지막 배치 시점을 현재 시점으로 갱신
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax); // 다음 배치까지의 시간간격 랜덤설정
            float yPos = Random.Range(yMin, yMax); // 배치할 위치의 높이 랜덤설정

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);
            // 사용할 현재 순번의 발판 게임 오브젝트를 껏다켬 (OnEnable 메서드 실행)

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos); // 현재 순번의 발판을 화면 오른쪽에 재배치
            currentIndex++; // 순번 넘기기

            if(currentIndex >= count) // 마지막 순번에 도달했다면 순번 리셋
                currentIndex = 0;
        }
    }
}