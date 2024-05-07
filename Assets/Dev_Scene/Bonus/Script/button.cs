using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject activeGameObject;
    public void ActivaGameObject()
    {
        if(activeGameObject.activeSelf != true)
        {
            activeGameObject.SetActive(true);
        }
        else
        {
            activeGameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        activeGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
