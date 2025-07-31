using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    int _index = 0;
    
    public void OnStartButton()
    {
        ++_index; // 버튼을 누르면 _index가 1이 됨
        SceneManager.LoadScene(_index); // 인덱스가 1일 때 씬을 이동함
    }

    public void OnQuitButton()
    {
        Application.Quit(); // 버튼을 누르면 나가기
    }
}
