using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ����� ��� ���������� ������
    private const string SAVED_LEVEL_KEY = "SavedLevel";
    private const string SAVED_LIVES_KEY = "SavedLives";
    private const string SAVED_SCORE_KEY = "SavedScore";

    // ����� ��� ������ "����� ����"
    public void StartNewGame()
    {
        // ������� ��� ����������
        PlayerPrefs.DeleteAll();

        // ������������� ��������� ��������
        PlayerPrefs.SetInt(SAVED_LEVEL_KEY, 1); // �������� � 1 ������
        PlayerPrefs.SetInt(SAVED_LIVES_KEY, 3); // 3 �����
        PlayerPrefs.SetInt(SAVED_SCORE_KEY, 0); // ���� 0

        // ��������� ����� � �����
        SceneManager.LoadScene("GameScene");
    }

    // ����� ��� ������ "����������"
    public void ContinueGame()
    {
        // ���������, ���� �� ����������
        if (PlayerPrefs.HasKey(SAVED_LEVEL_KEY))
        {
            // ��������� ����� � �����
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.Log("��� ����������� ����!");
            // ����� �������� ��������� ������
        }
    }

    // ����� ��� ���������� ����
    public static void SaveGame(int level, int lives, int score)
    {
        PlayerPrefs.SetInt(SAVED_LEVEL_KEY, level);
        PlayerPrefs.SetInt(SAVED_LIVES_KEY, lives);
        PlayerPrefs.SetInt(SAVED_SCORE_KEY, score);
        PlayerPrefs.Save(); // ����� ������� Save()
    }
}