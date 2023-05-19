using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; // 사망시 재생할 오디오클립
    public float jumpForce = 700f; // 점프 힘

    private int jumpCount = 0; // 누적점프수(다단점프용)
    private bool isGrounded = false; // 접지 여부
    private bool isDead = false; // 사망 여부

    // 사용할 컴포넌트의 변수
    private Rigidbody2D playerRigidbody; // 리지드바디
    private Animator animator; // 애니메이터
    private AudioSource playerAudio; // 오디오소스

    private void Start() // 초기화
    {
        // 게임 오브젝트로부터 사용할 컴포넌트들을 가져와서 변수에 할당
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update() // 입력감지 점프처리
    {
        if(isDead)
        {
            return; // 사망시 더이상 처리를 진행하지 않고 종료
        }
        if (Input.GetMouseButtonDown(0) && jumpCount < 2) // 왼클릭 && 최대점프횟수 미만이면
        {
            jumpCount++; // 점프수 증가
            playerRigidbody.velocity = Vector2.zero; // 점프직전 순간속도를 0으로 변경
            playerRigidbody.AddForce(new Vector2(0, jumpForce)); // 리지드바디에 상방향 힘 주기
            playerAudio.Play(); // 오디오소스 재생
        }
        else if (Input.GetMouseButtonUp(0)&&playerRigidbody.velocity.y>0)
        { // 마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y값이 양수 (상승중) 라면
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f; // 속도를 절반으로 변경
        }

        animator.SetBool("Grounded", isGrounded);
        // 애니메이터의 Gronded 파라미터를 isGrounded 값으로 갱신
    }

    private void Die() // 사망 처리
    {
        animator.SetTrigger("Die"); // 애니메이터의 Die 트리거 파라미터를 셋
        // 트리거 타입의 파라미터는 셋하는 즉시 true가 되었다가 곧바로 false가 되기에 별도의값 지정X
        playerAudio.clip = deathClip; // 오디오 소스에 할당된 오디오 클립을 deathClip으로 변경
        playerAudio.Play(); // 사망효과음 재생

        playerRigidbody.velocity = Vector2.zero; // 속도를 0으로 변경
        isDead = true; // 사망여부 트루

        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D other) // 장애물 충돌 감지
    {
        if (other.tag == "Dead" && !isDead)
        { // 충돌한 상대의 태그가 Dead && 아직 안죽었으면(사망여부 폴스) Die()실행
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // 접지O 감지 처리
    {
        if (collision.contacts[0].normal.y > 0.7f)
        { // 어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있으면
            isGrounded = true;
            jumpCount = 0;
            // 접지여부 트루, 점프카운트 리셋
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // 접지X 감지 처리
    { // 어떤 콜라이더와 떨어진 경우 접지여부 폴스
        isGrounded = false;
    }
}