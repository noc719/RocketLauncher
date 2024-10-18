using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float fuel = 100f;
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    private float currentScore = 0;
    private float highScore = 0;


    // 네임스페이스 추가
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;
    [SerializeField] private Image hpBar ;



    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        _rb2d = GetComponent<Rigidbody2D>();
        

    }
    
    public void Shoot()
    {
       
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel >= 10) 
        {
            fuel = fuel - FUELPERSHOOT;
            
            //fillAmount 는 0부터 1

            _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
            
            

        }
        else
        {

            Debug.Log("연료 소진");
           

            return;
        }
       
        
    }

    public void Update()
    {
        if (fuel < 90)
        {
            fuel += 10f * Time.deltaTime;
        }
        Debug.Log(fuel);
        hpBar.fillAmount = fuel/100;

        

        currentScore =  _rb2d.transform.position.y;
        currentScore = Mathf.FloorToInt(currentScore);
        
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }

        currentScoreTxt.text = $"{currentScore} M";
        highScoreTxt.text = $"High : {highScore} M";


    }
    public void Retry()
    {

        SceneManager.LoadScene("RocketLauncher");
    }
}
