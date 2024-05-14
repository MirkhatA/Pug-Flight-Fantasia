using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadLeaderScene()
    {
        SceneManager.LoadScene("Leaderboard");
    }

   /* IEnumerator LoadGameSceneCoroutine()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
        transitionAnim.SetTrigger("Start");
    }*/
}
