using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DifficultyButton : MonoBehaviour
{
    private GameManager gm;
    Button button;

    public int difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    void SetDifficulty()
    {
        gm.StartGame(difficulty);
    }
}
