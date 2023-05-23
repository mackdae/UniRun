using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles; // ��ֹ� ������Ʈ��
    private bool stepped = false; // ���� ����

    private void OnEnable() // ������Ʈ�� Ȱ��ȭ�� ������ �����ϴ� �޼��� // ������Ʈ Ȱ��ȭ�ÿ��� �ߵ�
    { // ���� ����ó��
        stepped = false; // ���� ����
        for (int i = 0; i < obstacles.Length; i++) // ��ֹ� ����ŭ ����
        {
            if (Random.Range(0,3)==0) // ���� ������ ��ֹ��� 1/3Ȯ���� Ȱ��ȭ
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
    { // �÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ���� �߰� ó��
        if(collision.collider.tag == "Player" && !stepped)
        { // �浹�� ����� �±װ� �÷��̾��̰� ������ ���� �ʾҴٸ�
            stepped = true;
            GameManager.instance.AddScore(1);
            // ������ �߰��ϰ� �������� Ʈ��
        }
    }
}