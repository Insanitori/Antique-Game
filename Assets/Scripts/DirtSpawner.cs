using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtSpawner : MonoBehaviour
{

    public bool cast = false;
    public GameObject target;
    [Range(0,1000)]
    public int dirtAmount = 0;
    public GameObject dirtPrefab;
    public float squareCleanDistance = 400;

    public void spawnDirt(float amount_) {

        Ray ray;
        RaycastHit hit = new RaycastHit();
        GameObject dirtSpec;
        for (int a = 0; a < amount_; a++) {

            ray = Camera.main.ScreenPointToRay(new Vector3(Random.Range(0,Screen.width), Random.Range(0, Screen.height)));
            Physics.Raycast(ray, out hit);
            if (hit.collider != null && (hit.collider.gameObject == target || hit.collider.gameObject.transform.parent.gameObject == target)) {

                dirtSpec = Instantiate(dirtPrefab, target.transform);
                dirtSpec.transform.position = hit.point;
                Debug.DrawLine(hit.point, Camera.main.transform.position, Color.blue, 1);

            }

        }

    }

    void Update() {

        if (Input.GetMouseButton(0)) {

            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Dirt")) {

                if (g.GetComponent<DirtController>().cleanable && (g.GetComponent<DirtController>().screenPosition - (Vector2)Input.mousePosition).SqrMagnitude() <= squareCleanDistance) {

                    Destroy(g);

                }

            }

        }
        if (cast) {

            cast = false;
            spawnDirt(dirtAmount);

        }


    }

}
