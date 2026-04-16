using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private ScoreZone[] _scoreZone;

    private void Awake()
    {
        foreach (var zone in _scoreZone)
        {
            zone.OnLeftPointScored += CreateBall;
            zone.OnRightPointScored += CreateBall;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateBall();
    }

    private void CreateBall()
    {
        Instantiate(_ball);
    }
}
