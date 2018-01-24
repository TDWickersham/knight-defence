using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, idamageable {

    Animator anim;
    public Rigidbody rb;
    public float speed;
    public Camera turn;
    public float rotspeed;
    public int Maxhealth;
    public int currentHealth;
    public ParticleSystem effect;
    // Use this for initialization
    void Start()
    {
        currentHealth = Maxhealth;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseRatioX = Input.mousePosition.x / Screen.width;
        float mouseRatioY = Input.mousePosition.y / Screen.height;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        rb.AddForce(move * speed * Time.deltaTime);
        anim.SetFloat("speed", rb.velocity.magnitude);
        Ray ray = turn.ViewportPointToRay(new Vector3(mouseRatioX, mouseRatioY));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetDir = hit.point - transform.position;
            float rot = rotspeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rot, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            if (Input.GetMouseButton(0))
            {
                spawnParticle(hit.point);
            }
        }
    }

    void spawnParticle(Vector3 pos)
    {
        GameObject spawnPart = Instantiate(effect.gameObject);
        spawnPart.transform.position = pos + Vector3.up;
        spawnPart.GetComponent<ParticleSystem>().Play();
        Destroy(spawnPart, .8f);
    }
    public void takedamage(int damagetaken)
    {
        currentHealth -= damagetaken;
        die();

    }
    public void die()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("dead");
            SceneManager.LoadScene("End Mene");
        }
    }
}
