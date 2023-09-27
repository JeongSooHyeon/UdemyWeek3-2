using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText;   // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트
    public Text revivalText;    // 부활 텍스트
    public GameObject InvincibleText; // 무적 모드 텍스트

    public GameObject player;

    private float surviveTime;  // 생존 시간
    private bool isGameover;    // 게임오버 상태

    public int revival;    // 부활 가능 수

    void Start()
    {
        // 생존 시간과 게임오버 상태 초기화
        // surviveTime = 0;
        isGameover = false;

/*        PlayerPrefs.SetFloat("BestTime", 0f);
        PlayerPrefs.SetInt("RevivalCnt", 0);*/

        revival = PlayerPrefs.GetInt("RevivalCnt");
    }

    void Update()
    {
        // 게임오버가 아닌 동안
        if (!isGameover)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시 
            timeText.text = "Time : " + (int)surviveTime;
        }
        else
        {
            // 게임오버 상태에서 R 키를 누른 경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
        revivalText.text = "부활 : " + revival;
    }

    // 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameover = true;
        // 게임오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        // BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            revival++;   // 부활권 1개 추가
            PlayerPrefs.SetInt("RevivalCnt", revival);

            // 최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            // 변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        recordText.text = "Best Time : " + (int)bestTime;
    }

    public void RevivalGame()
    {
        if (revival > 0)
        {
            player.SetActive(true);
            RestartGame();
            revival--;
            PlayerPrefs.SetInt("RevivalCnt", revival);
        }
    }

    private void RestartGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameover = false;
        // 게임오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(false);
        player.GetComponent<PlayerController>().isInvincible = true;    // 플레이어 무적 상태
        StartCoroutine("InvincibleMode");
    }

    IEnumerator InvincibleMode()
    {
        InvincibleText.SetActive(true);
        yield return new WaitForSeconds(3.0f);  // 3초 쉬고 
        player.GetComponent<PlayerController>().isInvincible = false;   // 무적 상태 해제
        InvincibleText.SetActive(false);
    }
}
