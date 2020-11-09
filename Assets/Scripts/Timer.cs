using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    private int _highscoreMinutes = PlayerPrefs.GetInt("Minutes");
    private int _highscoreSecondes = PlayerPrefs.GetInt("Seconds");
    private int _highscoreMilisecondes = PlayerPrefs.GetInt("Miliseconds");

    private float _timerTime;
    private int _minutes;
    private int _seconds;
    private int _milliseconds;


    private void Update()
    {
        _timerTime = Time.time - 0f;
        TimeManagement();
        timer.text = $"{_minutes:00}:{_seconds:00}:{_milliseconds:00}";
        CheckHighScorePassed();
    }

    private void TimeManagement()
    {
        _minutes = ((int) _timerTime / 60);
        _seconds = ((int) _timerTime % 60);
        _milliseconds = ((int) (_timerTime * 100)) % 100;
    }

    private void CheckHighScorePassed()
    {
        if (_minutes > _highscoreMinutes)
        {
            NewHighScore();
        }
        else if (_minutes == _highscoreMinutes)
        {
            if (_seconds > _highscoreMinutes)
            {
                NewHighScore();
            }

            if (_seconds == _highscoreSecondes)
            {
                if (_milliseconds > _highscoreMilisecondes)
                {
                    NewHighScore();
                }
                else
                {
                    return;
                }
            }
        }
    }

    private void NewHighScore()
    {
        PlayerPrefs.SetInt("Minutes", _minutes);
        PlayerPrefs.SetInt("Seconds", _seconds);
        PlayerPrefs.SetInt("Miliseconds", _milliseconds);
    }
}