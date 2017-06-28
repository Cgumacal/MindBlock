using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalBubbleBlock : MonoBehaviour {
    private List<GameObject> BlocksMoved = new List<GameObject>();
    private Vector3 currentPosition;
    private Vector3 lastPosition;
	// Use this for initialization
	void Start () {
        currentPosition = transform.position;
        lastPosition = currentPosition;
        pushBlocks();
	}
	
	// Update is called once per frame
	void Update () {
        currentPosition = transform.position;
		if(currentPosition != lastPosition)
        {
            returnBlocks();
            pushBlocks();
            lastPosition = currentPosition;
        }
	}

    private void pushBlocks()
    {
        
        TeleportTo[] inArea = GameObject.FindObjectsOfType<TeleportTo>();
        foreach (TeleportTo x in inArea)
        {
            if (x.gameObject != this.gameObject)
            {
                if (Vector3.Distance(x.transform.position, transform.position) <= 0.5)
                {
                    BlocksMoved.Add(x.gameObject);
                    Vector3 dir = x.transform.position - transform.position;
                    StartCoroutine(push(x.gameObject, x.transform.position + (dir.normalized * 0.5f)));

                }
            }
        }
    }

    private void returnBlocks()
    {
        foreach(GameObject x in BlocksMoved)
        {
            Vector3 dir = x.transform.position - lastPosition;
            StartCoroutine(push(x, x.transform.position - (dir.normalized * 0.5f)));

        }
        BlocksMoved.Clear();
    }

    IEnumerator push(GameObject block, Vector3 End)
    {
        while(block.transform.position != End)
        {
            block.transform.position = Vector3.MoveTowards(block.transform.position, End, 0.5f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}
