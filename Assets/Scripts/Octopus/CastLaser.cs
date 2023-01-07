using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastLaser : MonoBehaviour
{
    public GameObject foxy;
    public float shootFrequency = 0.4f;

    private float lastShootTime = 0;
    private Transform shootpoint;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        shootpoint = transform.Find("Shootpoint");
        lineRenderer = transform.Find("Laser").gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if(Time.time - lastShootTime >= shootFrequency) {
            StartCoroutine(shoot());
            lastShootTime = Time.time;
        }
    }

    IEnumerator shoot() {
        Vector3 shootDirection = shootpoint.right;
        shootDirection.x *= -1;
        RaycastHit2D hitInfo = Physics2D.Raycast(shootpoint.position, shootDirection);

        if(hitInfo && hitInfo.transform.name == "Foxy with claw") {
            print(hitInfo.transform.name);
            lineRenderer.SetPosition(0, shootpoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            FoxyDeath foxyDeath = foxy.GetComponent<FoxyDeath>();
            foxyDeath.Die();
        }
        else {
            lineRenderer.SetPosition(0, shootpoint.position);
            lineRenderer.SetPosition(1, shootpoint.position + shootDirection*100);
        }

        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.2f); // wait one frame
        lineRenderer.enabled = false;
    }
}
