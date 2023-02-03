using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OkButton : MonoBehaviour
{
    public GameObject obj;
    public void OnClickStartButton()
    {
        Destroy(obj);
    }
}
