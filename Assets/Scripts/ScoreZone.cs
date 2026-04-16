using System;
using UnityEngine;

public enum Team
{
    Left,
    Right,
}

public class ScoreZone : MonoBehaviour
{
    [SerializeField]
    private Team team;

    public event Action OnLeftPointScored;
    public event Action OnRightPointScored;


    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (team)
        {
            case Team.Left:
                Debug.Log("Team Two Score");
                OnLeftPointScored?.Invoke();
                Destroy(other.gameObject);
                return;
            case Team.Right:
                Debug.Log("Team One Score");
                OnRightPointScored?.Invoke();
                Destroy(other.gameObject);
                return;
        }
    }
}
