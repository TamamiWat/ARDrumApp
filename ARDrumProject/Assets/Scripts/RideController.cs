using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideController : MonoBehaviour
{
    [SerializeField] AudioClip SE;
    //AudioSourceコンポーネント保存用変数
    private AudioSource audioSource;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update(){
        animator = GetComponent<Animator>();

    }
    

    public void Hit(){
        animator.SetTrigger("rideAnimTrigger"); 
        //Debug.Log("bass music play");
        //audioSourceのClipを再生する
        audioSource.PlayOneShot(SE);
    }
}
