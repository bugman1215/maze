using TMPro;
using UnityEngine;
[RequireComponent(typeof(TMP_Text))]
public class ScoreText : MonoBehaviour
{
    private static TMP_Text scoreText;
    public static ScoreText Singleton;
    private AudioSource[] audioSources;
    private bool firstTimeUpdate = true;
    public static void ScorePoints(int points)
    {

        Singleton.UpdateText(points);
    }
    public int score = 3;

    // Use this for initialization

    void Start()
    {
        Singleton = this;
        scoreText = GetComponent<TMP_Text>();
        UpdateText(3);
        firstTimeUpdate = false;
        audioSources = GetComponents<AudioSource>();
    }
    private void Update()
    {
        audioSources = GetComponents<AudioSource>();
    }

    private void UpdateText(int delta)
    {   if (delta < 0)
        {
            audioSources = GetComponents<AudioSource>();
            audioSources[1].Play();
        }
        if (delta > 0) {
            audioSources = GetComponents<AudioSource>();
            if (!firstTimeUpdate) {
                audioSources[0].Play();
            }
            
        }
        score += delta;
        if (score == 0) {
            GameText.UpdateText("LOSE");
            Time.timeScale = 0;
        }
        scoreText.text = "Health: " + score.ToString();

    }
    private int getScore() {
        return score;
    }
    public static int returnScore()
    {
        return Singleton.getScore();
    }
    
}
