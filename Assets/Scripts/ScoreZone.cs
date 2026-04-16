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


    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (team)
        {
            case Team.Left:
                Debug.Log("Team Two Score");
                return;
            case Team.Right:
                Debug.Log("Team One Score");
                return;
        }
    }
}
