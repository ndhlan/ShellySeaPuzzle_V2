using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardDisplay : MonoBehaviour
{

    public Leaderboard leaderboard;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(DisplayLeaderboard());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator DisplayLeaderboard()
    {
        yield return leaderboard.FetchTopHighscoresRoutine();
    }
}
