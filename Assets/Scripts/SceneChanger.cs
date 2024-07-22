using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Oyunu kapatma metodu
    public void ExitGame()
    {
        // Editor'de �al���rken oyunu durdurmak i�in
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Build edilen oyunu kapatmak i�in
        Application.Quit();
#endif
    }
}
