using UnityEngine;
using System.Collections;

public class ProductManager : MonoBehaviour
{
    [Header("Productos")]
    public GameObject[] products;

    [Header("Aparicion")]
    public Transform spawnPoint;
    public float spawnDelay = 3f;

    private int currentIndex = 0;
    private GameObject currentProduct;
    private bool waitingForNext = false;

    void Start()
    {
        SpawnNextProduct();
    }

    void SpawnNextProduct()
    {
        if (currentIndex >= products.Length)
        {
            Debug.Log("Todos los productos han salido.");
            return;
        }

        currentProduct = Instantiate(
            products[currentIndex],
            spawnPoint.position,
            spawnPoint.rotation
        );

        currentIndex++;
        waitingForNext = false;

        Debug.Log("Producto " + currentIndex + " generado.");
    }

    public void ProductPlacedInInspection(GameObject product)
    {
        if (product != currentProduct || waitingForNext)
            return;

        waitingForNext = true;

        Debug.Log("Producto colocado en la mesa de inspeccion.");

        StartCoroutine(WaitAndSpawnNext());
    }

    IEnumerator WaitAndSpawnNext()
    {
        yield return new WaitForSeconds(spawnDelay);

        currentProduct = null;
        SpawnNextProduct();
    }
}
