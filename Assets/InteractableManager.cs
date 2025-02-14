using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    [SerializeField] protected MeshRenderer interactableMeshRenderer;
    protected Material firstColor;
    [SerializeField] protected Material selectedColor;


    [SerializeField] GameObject gObject;
    public void OnEnteredHover()
    {
        firstColor = interactableMeshRenderer.material;
        interactableMeshRenderer.material = selectedColor;
    }

    public void OnExitHover()
    {
        interactableMeshRenderer.material = firstColor;
    }

    public void OnSelected()
    {
        interactableMeshRenderer.material = firstColor;
        gObject.SetActive(true);
    }
}
