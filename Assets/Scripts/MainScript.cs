using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField timeInputField, speedInputField, distanceInputField;
    [SerializeField] private Transform cubeSpawner;
    [SerializeField] private GameObject cubePrefab;
    private int time, speed, distance;

    public void digitsToAbs(TMP_InputField field)
    {
        if (field.text.Contains("-")) field.text = null;
    }

    public void CubeSpawn()
    {
        if (CheckFields())
        {
            time = Convert.ToInt32(timeInputField.text); speed = Convert.ToInt32(speedInputField.text); distance = Convert.ToInt32(distanceInputField.text);
            StartCoroutine(cubeWait());
            IEnumerator cubeWait()
            {
                yield return new WaitForSeconds(time);
                var newCube = Instantiate(cubePrefab, cubeSpawner);
                var script = newCube.GetComponent<CubeScript>();
                script.speed = speed;
                script.distance = distance;
            }
        }
    }

    private bool CheckFields()
    {
        bool ok = false;
        if (timeInputField.text.Length == 0) timeInputField.ActivateInputField(); 
        else if (speedInputField.text.Length == 0) speedInputField.ActivateInputField();
        else if (distanceInputField.text.Length == 0) distanceInputField.ActivateInputField();
        else ok = true;
        return ok;
    }
}
