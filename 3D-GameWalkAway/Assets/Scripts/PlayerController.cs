using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool jump = false;
    public bool slide = false;
    public Animator anim;
    public float score = 0;
    public Text ScoreText;
    public Text BestScoreText;

    public bool boost = false;
    public Rigidbody rbody;
    public CapsuleCollider myCollider;
    public Image gameOverImg;
    public Image startGameImg;
    public float lastScore;
    public bool death = false;
    public bool gamestart = false;


    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();

        lastScore = PlayerPrefs.GetFloat("MyScore");
    }

    public void PlayAgain(){
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayGame(){
        startGameImg.gameObject.SetActive(false);
        gamestart = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if(gamestart==false){
            transform.Translate(0, 0, 0);
        }else{
            if ((score >= 20 && score<30)&& death==false){
                transform.Translate(0, 0, 0.02f);
            }else if ( score>=30 && death==false){
                transform.Translate(0, 0, 0.03f);
            }else if (death==false){
                transform.Translate(0, 0, 0.01f);
            }else{
                transform.Translate(0, 0, 0);
            }
        }
        if (score > lastScore){
            BestScoreText.text = "Best Score : " + score.ToString();
        }else{
            BestScoreText.text = "Your Score : " + score.ToString();
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
            transform.Translate(0, 0.06f, 0);
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
        if (other.gameObject.tag == "Fish"){
            Destroy(other.gameObject);
            score += 1;
            ScoreText.text = score.ToString();
        }
        if (other.gameObject.tag == "Deathpoint"){
            gameOverImg.gameObject.SetActive(true);
            if(score> lastScore){
                PlayerPrefs.SetFloat("MyScore", score);
            }
            death = true;
        }
        if (other.gameObject.tag == "Updeathpoint"){
            if(slide==false){
                gameOverImg.gameObject.SetActive(true);
                if(score> lastScore){
                    PlayerPrefs.SetFloat("MyScore", score);
                }
                death = true;
            }
        }

    
    }

    IEnumerator BoostController()
    {
        boost = true;
        yield return new WaitForSeconds(3);
        boost = false;
    }
}
