using TMPro;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [HideInInspector] public int speed, distance;
    [SerializeField] private TextMeshPro cubeText;
    private int distanceRemain;

    void Update()
    {
        Moving();
        DistanceCheck();
        TextUpdate();
    }

    private void Moving()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
    }

    private void DistanceCheck()
    {
        distanceRemain = distance - (int)transform.position.z;
        if (distanceRemain <= 0) Destroy(gameObject);
    }

    private void TextUpdate()
    {
        cubeText.text = $"Speed:\n{speed}\nDistance:\n{distanceRemain}";
    }
}
