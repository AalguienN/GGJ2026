using NUnit.Framework.Constraints;
using System;
using Unity.VisualScripting;
using UnityEngine;


public class InteractUiScaler : MonoBehaviour
{
    public static InteractUiScaler Instance;    

    private Camera myMainCamera;
    private Transform objectivePhotoObj;
    private Transform MaskUiObj;

    public enum Interaction { Dragging, NoInteraction}
    private Interaction interacting = Interaction.NoInteraction;

    [Header("Interacting")]
    public Interaction Interacting
    {
        get => interacting;
        set { interacting = value; Debug.Log(value);  HandleInteractionPositions(value); }
    }
    [Header("Offsets")]
    public Vector3 offsetNormal;
    public Vector3 offsetInteracting;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null) Destroy(this);
        else Instance = this;

        //Cacheando
        myMainCamera = Camera.main;
        objectivePhotoObj = gameObject.GetComponentInChildren<ObjectivePhotoScr>().transform;
        MaskUiObj = gameObject.GetComponentInChildren<MaskUiScr>().transform;
        Interacting = Interaction.NoInteraction;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void HandleInteractionPositions(Interaction int_state)
    {        
        Vector3 esquina_0_0 = myMainCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 esquina_1_0 = myMainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        Vector3 esquina_1_1 = myMainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        esquina_0_0.z = esquina_0_0.z + 1;
        esquina_1_0.z = esquina_1_0.z + 1;

        switch (int_state)
        {
            case Interaction.Dragging:
                //Esta guarrada para que no me lo pase como referencia (creo, a chuparla)
                Vector3 offsetInteractingScaled = new Vector3(offsetInteracting.x, offsetInteracting.y, offsetInteracting.z);
                offsetInteractingScaled.Scale(esquina_1_1-esquina_0_0);
                Vector3 offsetInteractingScaledFlippedX = new Vector3(-offsetInteractingScaled.x, offsetInteractingScaled.y, offsetInteractingScaled.z);
                objectivePhotoObj.position = esquina_0_0 + offsetInteractingScaled;
                MaskUiObj.position = esquina_1_0 + offsetInteractingScaledFlippedX;
                break;
            case Interaction.NoInteraction:
                //Otra guarrada
                Vector3 offsetNormalScaled = new Vector3(offsetNormal.x, offsetNormal.y, offsetNormal.z);
                offsetNormalScaled.Scale(esquina_1_1-esquina_0_0);
                Vector3 offsetNormalScaledFlippedX = new Vector3(-offsetNormalScaled.x, offsetNormalScaled.y, offsetNormalScaled.z);
                objectivePhotoObj.position = esquina_0_0 + offsetNormalScaled;
                MaskUiObj.position = esquina_1_0 + offsetNormalScaledFlippedX;
                break;
        }
    }
}
