using UnityEngine;

public class EndBlock : MonoBehaviour
{
    public bool positive = false;
    // Use this for initialization
    void Start()
    {
        if (!positive)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("Standard", Color.red);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            Debug.Log("Win");
            PlayerScore scorer = col.gameObject.GetComponent<PlayerScore>();
            //this is a positive ending
            if (positive)
            {
                scorer.MakePositiveChoice();
            }
            //a negative ending
            else
            {
                scorer.MakeNegativeChoice();
            }

            //we are a paragon of society
            if (scorer.pScore >= 3)
            {
                AkSoundEngine.PostEvent("PLACEHOLDER_NAME_FOR_POSITIVE_RESPONSES", gameObject);
            }
            //we hate this
            if (scorer.pScore <= -3)
            {
                AkSoundEngine.PostEvent("PLACEHOLDER_NAME_FOR_NEGATIVE_RESPONSES", gameObject);
            }
        }
    }
}