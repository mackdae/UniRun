using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; // ����� ����� �����Ŭ��
    public float jumpForce = 700f; // ���� ��

    private int jumpCount = 0; // ����������(�ٴ�������)
    private bool isGrounded = false; // ���� ����
    private bool isDead = false; // ��� ����

    // ������Ʈ
    private Rigidbody2D playerRigidbody; // ������ٵ�
    private Animator animator; // �ִϸ�����
    private AudioSource playerAudio; // ������ҽ�

    private void Start() // �ʱ�ȭ
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update() // �Է°��� ����ó��
    {
        if(isDead)
        {
            return; // ����� ���̻� ó���� �������� �ʰ� ����
        }
        if (Input.GetMouseButtonDown(0) && jumpCount < 2) // ��Ŭ�� && �ִ�����Ƚ�� �̸��̸�
        {
            jumpCount++; // ������ ����
            playerRigidbody.velocity = Vector2.zero; // �������� �����ӵ��� 0���� ����
            playerRigidbody.AddForce(new Vector2(0, jumpForce)); // ������ٵ� ����� �� �ֱ�
            playerAudio.Play(); // ������ҽ� ���
        }
        else if (Input.GetMouseButtonUp(0)&&playerRigidbody.velocity.y>0)
        { // ���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y���� ��� (�����) ���
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f; // �ӵ��� �������� ����
        }

        animator.SetBool("Grounded", isGrounded);
        // �ִϸ������� Gronded �Ķ���͸� isGrounded ������ ����
    }

    private void Die() // ��� ó��
    {
        animator.SetTrigger("Die"); // �ִϸ������� Die Ʈ���� �Ķ���͸� ��
        // Ʈ���� Ÿ���� �Ķ���ʹ� ���ϴ� ��� true�� �Ǿ��ٰ� ��ٷ� false�� �Ǳ⿡ �����ǰ� ����X
        playerAudio.clip = deathClip; // ����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.Play(); // ���ȿ���� ���

        playerRigidbody.velocity = Vector2.zero; // �ӵ��� 0���� ����
        isDead = true; // ������� Ʈ��
    }

    private void OnTriggerEnter2D(Collider2D other) // ��ֹ� �浹 ����
    {
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // ����O ���� ó��
    {
        isGrounded = true;
        jumpCount = 0;
    }

    private void OnCollisionExit2D(Collision2D collision) // ����X ���� ó��
    {        

    }
}
