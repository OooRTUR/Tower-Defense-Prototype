using UnityEngine;

class DamageSender : MonoBehaviour
{
    // init values
    [SerializeField]
    private float rpmInitValue = 10;
    [SerializeField]
    private float rpmPerLevelValue = 10;

    [SerializeField]
    private int damageInitValue = 10;
    [SerializeField]
    private int damagePerLevelValue = 1;    

    [SerializeField]
    private GameObject bulletPrefab = null;

    // upgrade values
    UpgradableFloatProperty RPM;
    UpgradableIntProperty damage;

    // runtime values
    private float nextShoot;
    private float fireDelay;
    private GameObject target;

    private void Start()
    {
        RPM = new UpgradableFloatProperty(gameObject, rpmInitValue, rpmPerLevelValue);
        damage = new UpgradableIntProperty(gameObject, damageInitValue, damagePerLevelValue);
        fireDelay = 60.0f / (float)RPM.Value;

        transform.GetComponent<TargetSearch>().TargetFoundEvent.AddListener(delegate (object target)
        {
            this.target = (GameObject)target;
        });
        
    }

    private void Update()
    {
        if(target!=null)
            PerformDamage();
    }


    public void PerformDamage()
    {
        if (nextShoot > Time.time) return;
        Debug.Log("damage: "+ damage.Value);
        Debug.Log("RPM: " + RPM.Value);

        GameObject newBullet = Instantiate(bulletPrefab);
        var newDamageTransmitter = newBullet.GetComponent<BaseDamageTransmitter>();
        newDamageTransmitter.damage = (int)damage.Value;
        newDamageTransmitter.Init((GameObject)target, transform.position);

        ResetAttackTimer();
    }

    private void ResetAttackTimer()
    {
        fireDelay = 60.0f / (float)RPM.Value;
        nextShoot = Time.time + fireDelay;
    }
}