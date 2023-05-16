using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    //왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트

    float width; // 배경의 가로길이

    // Awake() 스크립트 활성화 전 한번 호출. 스크립트간의 실행순서 보장 없음
    // 변수 초기화, 컴포넌트 참조 설정, 리소스 로드, 싱글톤 인스턴스 설정 등과 같은 초기 설정 작업에 사용
    // Start() 스크립트 활성화 후 한번 호출. 스크립츠간의 실행순서 설정 가능
    // 초기화된 값에 대한 추가적인 처리나 게임 시작 준비 작업에 사용

    // 유니티 이벤트함수의 실행순서: 라이프사이클 //버전마다 변동이 생기므로 체크

    private void Awake() // 가로길이 측정 처리
    {
        //BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        //width = backgroundCollider.size.x;
        width = GetComponent<BoxCollider2D>().size.x;
        // 박스콜라이더2D 컴포넌트의 Size필드의 x값을 가로 길이로 사용
    }

    private void Update()
    {
        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했으면 위치 재배치
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    private void Reposition() // 위치 재배치 메서드
    {
        // 현재 위치에서 오른쪽으로 가로길이 *2만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}