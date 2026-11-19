using UnityEngine;

public class CorrectCube : Interactable
{
    public override bool Interact()
    {
        GetComponent<Renderer>().material.color = Color.white;
        return true;
    }
    
}
