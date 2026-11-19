using UnityEngine;
using System.Collections;
public class WrongCube : Interactable
{
    private Renderer cubeRenderer;
    private Color originalColor;

    private bool isFlashing = false;
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color;
    }

    public override bool Interact()
    {
        if (!isFlashing)
        {
            StartCoroutine(Flash());
        }

        return false;
    }

    IEnumerator Flash()
    {
        isFlashing = true;

        cubeRenderer.material.color = Color.red;
        
        yield return new WaitForSeconds(0.5f);
        
        cubeRenderer.material.color = originalColor;

        isFlashing = false;
    }
}
