using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public int RotationSpeed = 100;
    private Transform _itemTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _itemTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _itemTransform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
    }
}
