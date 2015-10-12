using UnityEngine;
using System.Collections;
public enum AwardsType
{
    Gun, Rapier
}
public class AwardsItems : MonoBehaviour {



    private bool isGetAwards;
    public float minDist;
    public float speed;
    public AwardsType type;
    private GameObject player;
	// Use this for initialization
	void Start () {
        rigidbody.velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        player = GameObject.FindWithTag(Consts.PlayerTag);
	}


    void Update()
    {
        if (isGetAwards)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position+Vector3.up, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.transform.position) < minDist)
            {
                player.GetComponent<PlayerGetAwards>().GetAwards(type);
                isGetAwards = false;
                Destroy(gameObject);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Consts.GroundTag)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.isKinematic = true;
            Collider collider = GetComponent<Collider>();
            collider.isTrigger = true;
            SphereCollider sc = collider as SphereCollider;
            sc.radius = 2;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Consts.PlayerTag)
        {
            isGetAwards = true;
        }
    }
	
    
}
