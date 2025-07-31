using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    int _index = 0;
    
    public void OnStartButton()
    {
        ++_index; // ��ư�� ������ _index�� 1�� ��
        SceneManager.LoadScene(_index); // �ε����� 1�� �� ���� �̵���
    }

    public void OnQuitButton()
    {
        Application.Quit(); // ��ư�� ������ ������
    }
}
