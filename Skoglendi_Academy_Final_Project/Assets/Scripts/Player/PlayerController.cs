using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Player Stats
    public SimpleHealthBar healthBar;
    public SimpleHealthBar staminaBar;
    public Light light;
    public int light_illumination;
    private Animator animator;
    public static float maxPlayerHealth = 100f;
    public static float currentPlayerHealth = 100f;
    public static float maxStamina = 100f;
    public static float currentStamina = 100f;
    public float sprintNum = 100f;

    public static Dictionary<string, bool> abilities;

    // First puzzle of game
    //public static bool haveKey = false;


    // For the last puzzle of the game
    //public static bool hasMasterKey = false;

    private LineRenderer line;
    private CharacterController cc;
    private Rigidbody rb;

    private bool debounce;
    private bool addingforce;
    private int increment;
    private bool jumpable;
    private bool illuminated;
    // Start is called before the first frame update
    void Start()
    {
        illuminated = false;
        currentStamina = 100;
        currentPlayerHealth = 100;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        line = GetComponent<LineRenderer>();
        debounce = false;
        addingforce = false;
        jumpable = false;
        increment = 0;

        line.material = new Material(Shader.Find("Custom/ShinOutline"));
        line.useWorldSpace = true;
        line.startColor = Color.yellow;
        line.endColor = Color.gray;
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        line.enabled = false;
        animator = GetComponent<Animator>();
        abilities = new Dictionary<string, bool>()
        {
            {"JUMP", false},
            {"ILLUMINATE", false}
        };
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Players health: " + currentPlayerHealth);

        if (Input.GetKeyDown(KeyCode.G))
        {
            currentPlayerHealth = 0;
        }
        if (Input.GetKey(KeyCode.Q) && abilities["ILLUMINATE"] && illuminated == false)
        {
            print("illuminate!");
            animator.SetTrigger("Spell");
            illuminated = true;
            light.range += light_illumination;
            GameObject lightorb = GameObject.FindWithTag("lightorb");
            lightorb.transform.localScale += new Vector3(10f,10f,10f);
            StartCoroutine(waiterLighter(3));
            
        }
        if (Input.GetKey(KeyCode.R) && abilities["JUMP"]) 
        {
            cc.enabled = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width /2, Screen.height/2, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                // Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow, Time.deltaTime);
                if (hit.distance > 5) 
                {
                    Vector3 p0 = ray.origin + new Vector3(0,0.5f,0);
                    Vector3 p2 = ray.origin + ray.direction * hit.distance;
                    Vector3 p1 = (p0 + p2)/2 + new Vector3(0, 1.25f, 0);
                    quadBezierCurve(p0,p1,p2);
                    line.enabled = true;
                    jumpable = true;
                }
                else 
                {
                    jumpable = false;
                    line.enabled = false;
                }
            }
            else
            {
                // Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, Time.deltaTime);
                line.enabled = false;
                jumpable = false;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.R) && abilities["JUMP"])
        {
           cc.enabled = true;
           line.enabled = false;
        }

        staminaBar.UpdateBar(currentStamina, maxStamina);
        // print("ST: " + currentStamina + " max: " + maxStamina);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R) && abilities["JUMP"] && Input.GetMouseButtonDown(0) && currentStamina > 50 || addingforce)
            {
                addingforce = true;
                //rb.isKinematic = false;
                cc.enabled = true;
                Debug.Log("Launch " + increment);
                Vector3 direction = (line.GetPosition(increment)-transform.position);
                float factor = Time.deltaTime * 8.0f;
                //cc.transform.position = line.GetPosition(increment);
                cc.Move(new Vector3(direction.x * factor, direction.y, direction.z * factor)); 
                // rb.velocity = (line.GetPosition(increment)-transform.position) * 10f;
                // rb.AddForce((line.GetPosition(increment)-transform.position), ForceMode.Impulse);
                increment += 1;
                if (increment >= line.positionCount) 
                {
                    increment = 0;
                    //rb.isKinematic = true;
                    addingforce = false;
                    currentStamina -= 50;
                }
            }
    }
    public void PlayerTakeDamage(float damage, float maxHealth)
    {
        // The damage that will player take. Can later be recovered using Health Scrolls
        currentPlayerHealth -= damage;

        // The health cap for player when taken hard hits that will no longer recover the lost health.
        maxPlayerHealth = maxHealth;

        healthBar.UpdateBar(currentPlayerHealth, maxPlayerHealth);
    }

    private void quadBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2) 
    {
        line.positionCount = 25;
        float t = 0f;
        Vector3 B = new Vector3(0,0,0);
        for (int i = 0; i < line.positionCount; i++) 
        {
            B = (1-t) * (1-t) * p0 + 2 * (1-t) * t * p1 + t*t*p2;
            line.SetPosition(i, B);
            t += 1/ (float)line.positionCount;
        }
    }

    IEnumerator waiterLighter(int secs)
    {
        yield return new WaitForSeconds(secs);
        GameObject lightorb = GameObject.FindWithTag("lightorb");
        lightorb.transform.localScale -= new Vector3(10f,10f,10f);
        light.range -= light_illumination;
        illuminated = false;
        
    }
}