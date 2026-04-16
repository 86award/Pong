using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private ScoreZone _scoreZone;
    private TMP_Text _scoreString;
    private int _score;

    private void Awake()
    {
        _score = 0;
        _scoreString = GetComponentInParent<TMP_Text>();
        _scoreZone.OnLeftPointScored += IncrementScore;
        _scoreZone.OnRightPointScored += IncrementScore;

    }

    private void Start()
    {
        _scoreString.text = _score.ToString();
    }

    private void IncrementScore()
    {
        _score++;
        _scoreString.text = _score.ToString();
        Debug.Log(_score);
    }
    // i should have an event in the scorezone that the ui listens for and updates the string
}
