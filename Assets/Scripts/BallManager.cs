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
        CreateBall(Team.Left);
    }

    private void CreateBall(Team e)
    {
        GameObject ballInstance = Instantiate(_ball);
        //Ball ball = ballInstance.TryGetComponent<Ball>(out Ball ball);
        if (ballInstance.TryGetComponent<Ball>(out Ball ball))
        {
            ball.ToPlayerTwo = (int)e;
        }
    }
}
