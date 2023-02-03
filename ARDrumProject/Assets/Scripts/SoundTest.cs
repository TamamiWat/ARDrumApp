using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class SoundTest : MonoBehaviour
{
    //AudioSourceコンポーネント保存用変数
    private AudioSource audioSource;

    public TrackableType type;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        audioSource = GetComponent<AudioSource>();

        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (raycastManager.Raycast(Input.GetTouch(0).position, hitResults, TrackableType.All))
            {
                //audioSourceのClipを再生する
                audioSource.PlayOneShot(audioSource.clip);
            }
            
        }
    }
}
