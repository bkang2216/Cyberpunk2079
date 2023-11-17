using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideEditorObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] editorObjects;
    // Start is called before the first frame update
    void Start()
    {
        editorObjects = GameObject.FindGameObjectsWithTag("EditorOnly");

        foreach(GameObject obj in editorObjects)
        {
            obj.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
