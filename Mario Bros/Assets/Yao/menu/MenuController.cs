using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
        Debug.Log("Start Game");
    }

    public void QuitGame()
    {
        // ��ӡ������̨�������ڱ༭���е���
        Debug.Log("Quit Game");

        // �˳���Ϸ
        Application.Quit();
    }
}
