using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementManager : MonoBehaviour
{
    [SerializeField] private GameObject placementPrefab;
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager raycastManager;    
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        if (Input.touchCount <= 0) return;

        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            // arCameraカメラからrayを照射
            var ray = arCamera.ScreenPointToRay(touch.position);

            // Cubeをタップした場合は削除する
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                var target = hit.collider.gameObject;
                if (target.name.Contains("Cube"))
                {
                    Destroy(target);
                    return;
                }
            }

            // Cubeを配置
            var isHitPlane = raycastManager.Raycast(ray, raycastHits, TrackableType.PlaneWithinPolygon);
            if (isHitPlane)
            {
                // 複数のPlaneがあった場合、最も近いPlaneが0番目に入っている
                Pose pose = raycastHits[0].pose;
                // 配置すべき座標
                Vector3 placePosition = pose.position;
                Instantiate(placementPrefab, placePosition, Quaternion.identity);
            }
        }
    }
}