using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{

    public bool update = false;
    public bool cleanable = false;
    public Vector2 screenPosition = new Vector2();

    GameObject target;

    void Update() {

        if (update) {

            update = false;
            updateCleanable();

        }

    }

    void Start() {

        target = Camera.main.GetComponent<DirtSpawner>().target;
        updateCleanable();

    }


    void updateCleanable() {

        RaycastHit hit;
        Physics.Linecast(Camera.main.transform.position, transform.position, out hit);
        Debug.DrawLine(Camera.main.transform.position, transform.position, Color.black, 1);
        if (hit.collider != null && hit.collider.transform.parent.gameObject != target) {

            cleanable = true;
            updatePosition();

        }
        else {

            cleanable = false;

        }

    }

    void updatePosition() {

        screenPosition = Camera.main.WorldToScreenPoint(transform.position);

    }

}
