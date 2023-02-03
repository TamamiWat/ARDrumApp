using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapManager : MonoBehaviour
{
    [SerializeField] public GameObject placementPrefab;    //ドラムのフルセット
    [SerializeField] public GameObject tappedobj;   //タップされたオブジェクト

    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    [SerializeField] private ARPlaneManager planeManager;


    bool isExist = false;   //ドラムが配置されているか
    //bool dontShow = false;

    void Start(){
        Debug.Log ("HelloWorld");
        planeManager = GetComponent<ARPlaneManager>();
    }

    private void Update()
    {
        if (Input.touchCount <= 0) return;

        var touch = Input.GetTouch(0);

        if(isExist){
            Debug.Log(planeManager.trackables);
            foreach(var plane in planeManager.trackables){
                if(plane.gameObject != null){
                    plane.gameObject.SetActive(false);

                }
                
            }
            Debug.Log ("平面削除");
        }


        if (touch.phase == TouchPhase.Began)
        {
            Debug.Log ("rayを照射");
            // rayを照射 from ARCamera
            var ray = arCamera.ScreenPointToRay(touch.position);
            
            //ドラムの配置
            var isHitPlane = raycastManager.Raycast(ray, raycastHits, TrackableType.PlaneWithinPolygon);

            if ( isHitPlane && !isExist)
            {
                // 複数のPlaneがあった場合、最も近いPlaneが0番目に入っている
                Pose pose = raycastHits[0].pose;
                // 配置すべき座標
                Vector3 placePosition = pose.position;
                Debug.Log("ドラムが設置されました");
                Instantiate(placementPrefab, placePosition, Quaternion.identity);
                isExist = true;
                
            }

                        

            //オブジェクトにヒット⇒音源再生
            RaycastHit hit;
            Debug.Log("raycast呼び出し");
            bool hasHit = Physics.Raycast(ray, out hit);
            Debug.Log("raycast呼び出し完了 ");

            Debug.Log(hasHit);
            if(hasHit){
                Debug.Log(hasHit);
                Debug.Log("Hit");
                tappedobj = hit.collider.gameObject;

                //bass drum    
                if(tappedobj.CompareTag("BassDrum")){
                    tappedobj.GetComponent<BassController>().Hit();
                }
                

                //snare drum
                if(tappedobj.CompareTag("SnareDrum")){
                    tappedobj.GetComponent<SnareController>().Hit();
                }

                //crash cymbal
                if(tappedobj.CompareTag("CrashCymbal")){
                    tappedobj.GetComponent<CrashController>().Hit();
                }

                //floor tom
                if(tappedobj.CompareTag("FloorTom")){
                    tappedobj.GetComponent<FloorController>().Hit();
                }

                //high tom
                if(tappedobj.CompareTag("HighTom")){
                    tappedobj.GetComponent<HightomController>().Hit();
                }

                //hihat
                if(tappedobj.CompareTag("Hihat")){
                    tappedobj.GetComponent<HihatController>().Hit();
                }

                //low tom
                if(tappedobj.CompareTag("LowTom")){
                    tappedobj.GetComponent<LowtomController>().Hit();
                }

                //ride cymbal
                if(tappedobj.CompareTag("RideCymbal")){
                    tappedobj.GetComponent<RideController>().Hit();
                }

            }
            //print(hasHit);
        }
    }

    /*void Awake()
   {
       planeManager = GetComponent<ARPlaneManager>();
   }*/
  
    
}
