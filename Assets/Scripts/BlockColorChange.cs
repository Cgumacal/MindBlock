using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script serves as a way to give the player feedback that the block they are mousing over
/// is a valid teleport location. 
/// </summary>
public class BlockColorChange : MonoBehaviour {
    //The color of the block when the player has the mouse over the block
    public Color mouseOverColor;
    //The original color of the block. This is to be set when the player moves the mouse off of the block
    private Color _originalColor;
    //The material for the blcok
    private Material _material;
	// Use this for initialization
	void Start () {
        _material = GetComponent<MeshRenderer>().material;
        _originalColor = _material.color;
	}
    //Changes color of the block when the player mouses over the block
    private void OnMouseEnter()
    {
        _material.color = mouseOverColor;
    }
    //Resets the color of the block back to what it originally was
    private void OnMouseExit()
    {
        _material.color = _originalColor;
    }
}
