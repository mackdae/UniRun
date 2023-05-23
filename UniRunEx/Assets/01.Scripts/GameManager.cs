using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //���ӿ��� ���¸� ǥ���ϰ� ���������� UI�� �����ϴ� ���ӸŴ���
    //������ �� �ϳ��� ���� �Ŵ����� ������ �� ����
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����

    public bool isGameover = false; // ���ӿ��� ���� = ����
    public TextMeshProUGUI scoreText; // ������ ����� UI �ؽ�Ʈ
    public GameObject gameoverUI; // ���ӿ����� Ȱ��ȭ�� UI ���� ������Ʈ

    private int score = 0; // ��������
    
    void Awake()
    { //���� ���۰� ���ÿ� �̱��� ����
        if (instance == null)
        { // �̱��� ������ ��������� �ڽ��� �Ҵ�
            instance = this;
            Debug.LogWarning("���ӸŴ��� �Ҵ�");
        }
        else
        { // �ƴϸ� �ı�
            Debug.LogWarning("�ΰ� �̻��� ���ӸŴ��� ����");
            Destroy(this.gameObject); //this ���� ������ �߰��ϸ� ��Ȯ�� ��
        }
    }
    
    void Update()
    { // ���ӿ��� �� ����� ó��
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    { // �������� �޼���
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