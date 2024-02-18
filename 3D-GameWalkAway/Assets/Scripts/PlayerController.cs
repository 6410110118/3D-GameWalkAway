using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool jump = false;
    public bool slide = false;
    public Animator anim;
    public int score = 0;
    public Text ScoreText;

    public bool boost = false;
    public Rigidbody rbody;
    public CapsuleCollider myCollider;


    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 20 && score<30){
            transform.Translate(0, 0, 0.05f);
        }else if ( score>=30){
            transform.Translate(0, 0, 0.05f);
        }else{
            transform.Translate(0, 0, 0.05f);
        }

        if (boost == true)
        {
            transform.Translate(0, 0, 1f);
            myCollider.enabled = false;
            rbody.isKinematic = true;

        }
        else
        {
            myCollider.enabled = true;
            rbody.isKinematic = false;
        }


        if (Input.GetKey(KeyCode.Space)){
            jump = true;
        }else{
            jump= false;
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            slide = true;
        }else{
            slide = false;
        }

        if (jump==true){
            anim.SetBool("isJump", jump);
            transform.Translate(0, 0.08f, 0);
        }else{
            anim.SetBool("isJump", jump);
        }
        
        if (slide==true){
            anim.SetBool("isSlide", slide);
        }else{
            anim.SetBool("isSlide", slide);
        }
        
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Coin"){
            Destroy(other.gameObject);
            score += 1;
            ScoreText.text = score.ToString();
        }

    
    }

    IEnumerator BoostController()
    {
        boost = true;
        yield return new WaitForSeconds(3);
        boost = false;
    }
}
