using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    public Animator anim;
    public float time = 1;

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            LoadNextLevel();
        }

    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int lvl)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(lvl);
    }
}
