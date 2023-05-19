using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //게임오버 상태를 표현하고 게임점수와 UI를 관리하는 게임매니저
    //씬에는 단 하나의 게임 매니저만 존재할 수 있음
    public static GameManager instance; // 싱글턴을 할당할 전역 변수
    public bool isGameover = false; // 게임오버 여부 = 폴스
    public TextMeshProUGUI scoreText; // 점수를 출력할 UI 텍스트
    public GameObject gameoverUI; // 게임오버시 활성화할 UI 게임 오브젝트
    private int score = 0; // 게임점수

    void Awke()
    { //게임 시작과 동시에 싱글턴 구성
        if (instance==null)
        { // 싱글턴 변수가 비어있으면 자신을 할당
            instance = this;
        }
        else
        { // 아니면 파괴
            Debug.LogWarning("두개 이상의 게임매니저 존재");
            Destroy(this.gameObject); //this 빼도 돼지만 추가하면 명확성 업
        }
    }

    void Update()
    { // 게임오버 중 재시작 처리
        if(isGameover && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int newScore)
    { // 점수증가 메서드
        if(!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}