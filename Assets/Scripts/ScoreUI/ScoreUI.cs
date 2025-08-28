using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image scoreFillImage;
    [SerializeField] private int maxScore = 100;

   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Vibe: " + GameFlow.score;

        float progress = (float)GameFlow.score / maxScore;
        progress = Mathf.Clamp01(progress);
        scoreFillImage.fillAmount = progress;
    }

    
}
