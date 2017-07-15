using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script serves as a way to give the player feedback that the block they are mousing over
/// is a valid teleport location. 
/// </summary>
public class BlockColorChange : MonoBehaviour {
	public Color mouseOverTeleportableBlockColor;
	public Color mouseOverNonTeleportableBlockColor;
    //The color of the block when the player has the mouse over the block
    public Color mouseOverColor;
    //The original color of the block. This is to be set when the player moves the mouse off of the block
    private Color _originalColor;
    //The material for the blcok
    private Material _material;


	private GameObject _player;
	// Use this for initialization
	void Start () 
	{
		_player = GameObject.FindGameObjectWithTag ("Player");

        _material = GetComponent<MeshRenderer>().material;
		mouseOverTeleportableBlockColor = Color.green;
		mouseOverNonTeleportableBlockColor = Color.red;
        _originalColor = _material.color;
	}
    //Changes color of the block when the player mouses over the block
    private void OnMouseEnter()
    {
        
		bool TP_Block = GetComponent<TeleportBlock>();
		if (transform.position.y <= _player.transform.position.y + 1 && Vector3.Distance (transform.position, _player.transform.position) <= _player.GetComponent<FPScontroller> ().getMaxTeleport () && _player.transform.parent.GetComponent<TeleportTo> ().getBorderNum () == GetComponent<TeleportTo> ().getBorderNum () || TP_Block) 
		{
			_material.color = mouseOverTeleportableBlockColor;
		} else {
			_material.color = mouseOverNonTeleportableBlockColor;
		}
    }
    //Resets the color of the block back to what it originally was
    private void OnMouseExit()
    {
        _material.color = _originalColor;
    }
}
