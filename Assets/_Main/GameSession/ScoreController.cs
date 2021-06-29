using EdwinGameDev.Events;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{    
    public ScriptableEvent<int> onScoreChange;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {         
        onScoreChange.Attach(UpdateScore);
    }

    private void UpdateScore(int points)
    {
        scoreText.text = $"SCORE: {points}";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
