using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippableModel : MonoBehaviour{

    public string Side;
    public Vector3 rotationForSlot = new Vector3();
    public Vector3 offsetForSlot = new Vector3();

    public void OrientForSlot()
    {
        transform.Rotate(rotationForSlot, Space.Self);
        transform.Translate(offsetForSlot);
    }

    public void OrientForBag()
    {
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localPosition = Vector3.zero;
    }
}
