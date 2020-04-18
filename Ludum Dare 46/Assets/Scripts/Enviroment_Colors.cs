using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment_Colors : MonoBehaviour
{
    [Tooltip("Add renderers for the script to change the colors.")]
    [SerializeField] List<Renderer> Meshes = new List<Renderer>();
    [Tooltip("Set the colors that all the meshes will change to.")]
    [SerializeField] List<Color> colors = new List<Color>();

    private void Start()
    {
        //Color pickedColor = colors[Random.Range(0, colors.Count)];

        //sets the colors based on the meshses selected.
        foreach (var obj in Meshes)
        {
            try
            {
                obj.material.SetColor("_Color", colors[Random.Range(0, colors.Count)]);
            }
            catch
            {
                Debug.LogError("Could not change colors, mesh or colors not set");
            }
        }
    }
}
