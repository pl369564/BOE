using UnityEngine;
using System.Collections;

public class PlayerDir : MonoBehaviour
{
    public GameObject effect_click_prefab;
    public GameObject UIRoot;
    private bool isMoving = false;
    public Vector3 targetPosition = Vector3.zero;
    private PlayerMove pm;
    private PlayerStatus ps;
    private PlayerAnimationS pa;
    Transform target;
    RaycastHit hitInfo;

    // Use this for initialization
    void Start()
    {
        targetPosition = transform.position;
        pm = this.GetComponent<PlayerMove>();
        ps = this.GetComponent<PlayerStatus>();
        pa = this.GetComponent<PlayerAnimationS>();
        ps.resetPosition = this.transform.position;
        UIRoot = GameObject.Find("UIRoot");
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.state == PlayerState.Death)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(UICamera.hoveredObject);
        }
        if (Input.GetMouseButtonDown(0) && (UICamera.hoveredObject == null|| UICamera.hoveredObject == UIRoot))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            target = hitInfo.collider.transform;
            Debug.Log("hitInfoTags:" + hitInfo.collider.tag);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
            {
                ps.state = PlayerState.Moving;
                pa.attackTime = 0;
                pa.attacking = false;
                targetPosition = Vector3.zero;
                isMoving = true;
                ShowClickEffect(hitInfo.point);
                LookAtTarget(hitInfo.point);
            }
            if (isCollider && hitInfo.collider.tag == Tags.enemy)
            {
                if (ps.state != PlayerState.Attack)
                {
                    pa.attackTime = 0;
                    ps.state = PlayerState.Follow;
                }
                transform.LookAt(target.position);
            }
        }
        if (ps.state == PlayerState.Follow || ps.state == PlayerState.Attack)
        {
            targetPosition = hitInfo.collider.transform.position;
            pa.isHalfHP = hitInfo.collider.GetComponent<WolfBaby>().isLowHp;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }
        if (isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
            {
                LookAtTarget(hitInfo.point);
            }
        }
        else if (pm.isMoving)
        {
            LookAtTarget(targetPosition);
        }
    }
    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
        GameObject.Instantiate(effect_click_prefab, hitPoint, Quaternion.identity);
    }
    void LookAtTarget(Vector3 hitPoint)
    {
        targetPosition = hitPoint;
        targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        this.transform.LookAt(targetPosition);
    }
    public void DealDamage(int damage, int random)
    {
        if (random == 0)
        {
            damage += damage;
        }
        if (hitInfo.collider.tag == Tags.enemy)
        {
            hitInfo.collider.GetComponent<WolfBaby>().TakeDamage(damage);
        }
    }
}
