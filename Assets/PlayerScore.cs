using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {
    [SerializeField] private int score = 0;
	
    public int pScore {
        get { return score; }
        private set { }
    }

    public void MakePositiveChoice() {
        score++;
    }

    public void MakeNegativeChoice() {
        score--;
    }
}
