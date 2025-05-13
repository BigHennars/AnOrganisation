using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DroppedItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    bool autoStart;

    [SerializeField]
    float enabledPickupDelay = 3.0f;

    [Header("State")]
    public Item item;
    public bool pickedUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (autoStart && item != null)
        {
            Initialize(item);
        }
    }
    public void Initialize(Item item)
    {
        this.item = item;
        var droppedItem = Instantiate(item.prefab, transform);
        droppedItem.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        StartCoroutine(EnablePickup(enabledPickupDelay));
    }

    IEnumerator EnablePickup(float dealy)
    {
        yield return new WaitForSeconds(dealy);
        GetComponent<Collider>().enabled = true;
    }
}
