using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class socketInspection : MonoBehaviour
{
    [Header("Administrador")]
    public ProductManager productManager;

    [Header("Attach Points")]
    public Transform attachTablet;
    public Transform attachLaptop;
    public Transform attachCelular;
    public Transform attachTeclado;
    public Transform attachNintendo;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    void Awake()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
    }

    void OnEnable()
    {
        socket.selectEntered.AddListener(OnProductPlaced);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnProductPlaced);
    }

    private void OnProductPlaced(SelectEnterEventArgs args)
    {
        GameObject product = args.interactableObject.transform.gameObject;

        productInfo info = product.GetComponent<productInfo>();

        if (info == null)
        {
            Debug.LogWarning("El producto no tiene ProductInfo.");
            return;
        }

        switch (info.productType)
        {
            case productInfo.ProductType.Tablet:
                socket.attachTransform = attachTablet;
                break;

            case productInfo.ProductType.Laptop:
                socket.attachTransform = attachLaptop;
                break;

            case productInfo.ProductType.Celular:
                socket.attachTransform = attachCelular;
                break;

            case productInfo.ProductType.Teclado:
                socket.attachTransform = attachTeclado;
                break;

            case productInfo.ProductType.Nintendo:
                socket.attachTransform = attachNintendo;
                break;
        }

        Debug.Log("Producto colocado: " + info.productType);

        productManager.ProductPlacedInInspection(product);
    }
}
