using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum Type { none, peine, galleta, gato, eleftante_juguete, cazo, bicho, alfombra }

    public Type type = Collectable.Type.none;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        switch (type)
        {
            case Type.peine:
                animator.SetTrigger("peine");
                break;
            case Type.galleta:
                animator.SetTrigger("galletas");
                break;
            case Type.gato:
                animator.SetTrigger("gato");
                break;
            case Type.eleftante_juguete:
                animator.SetTrigger("elefante");
                break;
            case Type.cazo:
                animator.SetTrigger("cazo");
                break;
            case Type.bicho:
                animator.SetTrigger("arana");
                break;
            case Type.alfombra:
                animator.SetTrigger("alfombra");
                break;
        }
    }
}
