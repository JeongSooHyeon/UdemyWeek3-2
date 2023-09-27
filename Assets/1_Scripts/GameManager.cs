using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText;   // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText; // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text revivalText;    // ��Ȱ �ؽ�Ʈ
    public GameObject InvincibleText; // ���� ��� �ؽ�Ʈ

    public GameObject player;

    private float surviveTime;  // ���� �ð�
    private bool isGameover;    // ���ӿ��� ����

    public int revival;    // ��Ȱ ���� ��

    void Start()
    {
        // ���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        // surviveTime = 0;
        isGameover = false;

/*        PlayerPrefs.SetFloat("BestTime", 0f);
        PlayerPrefs.SetInt("RevivalCnt", 0);*/

        revival = PlayerPrefs.GetInt("RevivalCnt");
    }

    void Update()
    {
        // ���ӿ����� �ƴ� ����
        if (!isGameover)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;
            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ�� 
            timeText.text = "Time : " + (int)surviveTime;
        }
        else
        {
            // ���ӿ��� ���¿��� R Ű�� ���� ���
            if (Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene ���� �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
        revivalText.text = "��Ȱ : " + revival;
    }

    // ���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        // BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviveTime > bestTime)
        {
            revival++;   // ��Ȱ�� 1�� �߰�
            PlayerPrefs.SetInt("RevivalCnt", revival);

            // �ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;
            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // �ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
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
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = false;
        // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(false);
        player.GetComponent<PlayerController>().isInvincible = true;    // �÷��̾� ���� ����
        StartCoroutine("InvincibleMode");
    }

    IEnumerator InvincibleMode()
    {
        InvincibleText.SetActive(true);
        yield return new WaitForSeconds(3.0f);  // 3�� ���� 
        player.GetComponent<PlayerController>().isInvincible = false;   // ���� ���� ����
        InvincibleText.SetActive(false);
    }
}
