using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// 씬 전환 요청시 씬 전환.
public class Bin_ChangeScene : MonoBehaviour
{
    public void GotoGameScene()
    {
        SceneManager.LoadScene("TowerDefance");
    }
}
