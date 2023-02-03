using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassController : MonoBehaviour
{
    [SerializeField] AudioClip bassSE;
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
        //this.transform.localScale = initScale*1.2;

        
        animator.SetTrigger("bassAnimTrigger");
        
        //GameObject g = Instantiate(effect, transform.position+new Vector3(0, 0.04f, 0), effect.transform.rotation);
        Debug.Log("bass music play");
        //audioSourceのClipを再生する
        audioSource.PlayOneShot(bassSE);

    }

}
