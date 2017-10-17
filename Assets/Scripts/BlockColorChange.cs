using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script serves as a way to give the player feedback that the block they are mousing over
/// is a valid teleport location. 
/// </summary>
public class BlockColorChange : MonoBehaviour {
	//The color of the block when the player has the mouse over the block
	public Color teleportableBlockColor;
	public Color nonteleportableBlockColor;
    public Color storedSwapBlockColor;
    //The original color of the block. This is to be set when the player moves the mouse off of the block
    private Color _originalColor;
    //The material for the blcok
    private Material _material;


	private enum BlockColorState
	{
		TELEPORTABLE, NONTELEPORTABLE, STORED, ORIGINAL
	}

	private BlockColorState state;



	private GameObject _player;
	// Use this for initialization
	void Start () 
	{
        _material = GetComponent<MeshRenderer>().material;
		teleportableBlockColor = Color.green;
		nonteleportableBlockColor = Color.red;
        storedSwapBlockColor = Color.cyan;
        _originalColor = _material.color;
	}

	void LateUpdate()
	{
		switch (state) {
			case BlockColorState.NONTELEPORTABLE:
				_material.color = nonteleportableBlockColor;
				break;
			case BlockColorState.TELEPORTABLE:
				_material.color = teleportableBlockColor;
				break;
            case BlockColorState.STORED:
                _material.color = storedSwapBlockColor;
                break;
			case BlockColorState.ORIGINAL:
			default:
				_material.color = _originalColor;
				break;
		}

		state = BlockColorState.ORIGINAL;
	}

	public void setStateToTeleportable()
	{
		state = BlockColorState.TELEPORTABLE;
	}

	public void setStateToNonteleportable()
	{
		state = BlockColorState.NONTELEPORTABLE;
	}
    public void setStateToStored()
    {
        state = BlockColorState.STORED;
    }
}
