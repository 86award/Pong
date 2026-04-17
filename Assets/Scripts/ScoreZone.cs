using System;
using UnityEngine;

public enum Team
{
    Left = -1,
    Right = 1,
}

public class ScoreZone : MonoBehaviour
{
    [SerializeField]
    private Team team;

    public event Action<Team> OnLeftPointScored;
    public event Action<Team> OnRightPointScored;


    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (team)
        {
            case Team.Left:
                Debug.Log("Team Two Score");
                OnLeftPointScored?.Invoke(Team.Left);
                Destroy(other.gameObject);
                return;
            case Team.Right:
                Debug.Log("Team One Score");
                OnRightPointScored?.Invoke(Team.Right);
                Destroy(other.gameObject);
                return;
        }
    }
}
