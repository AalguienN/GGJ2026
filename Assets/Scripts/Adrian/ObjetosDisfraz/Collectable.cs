using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum Type { none, peine, galleta_1, galleta_2, galleta_3, gato, eleftante_juguete, cazo, bicho, flor }

    public Type type = Collectable.Type.none;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (type)
        {
            case Type.peine:
                break;
            case Type.galleta_1:
                break;
            case Type.galleta_2:
                break;
            case Type.galleta_3:
                break;
            case Type.gato:
                break;
            case Type.eleftante_juguete:
                break;
            case Type.cazo:
                break;
            case Type.bicho:
                break;
            case Type.flor:
                break;
        }
    }
}
