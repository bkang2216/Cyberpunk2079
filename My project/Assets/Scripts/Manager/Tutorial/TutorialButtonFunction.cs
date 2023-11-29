using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonFunction : MonoBehaviour
{
    public void CloseApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
