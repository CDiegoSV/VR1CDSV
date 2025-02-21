using System.Collections.Generic;
using UnityEngine;

namespace Dante {
	public class Turret : MonoBehaviour
	{
        #region Knobs

        [SerializeField] protected GameObject bulletPrefab;
        [SerializeField] protected Transform firePoint;
        [SerializeField] protected int poolSize = 10;

        #endregion

        #region RuntimeVariables

        protected List<GameObject> bulletPool;
        protected float fireRate = 1f;
        protected float fireTimer;

        #endregion

        #region UnityMethods

        private void Start()
        {
            bulletPool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, gameObject.transform);
                bullet.SetActive(false);
                bulletPool.Add(bullet);
            }
        }

        private void Update()
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireRate)
            {
                Fire();
                fireTimer = 0f;
            }
        }

        #endregion

        #region PublicMethods



        #endregion

        #region LocalMethods

        protected void Fire()
        {
            GameObject bullet = GetPooledBullet();
            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.SetActive(true);
            }
        }

        protected GameObject GetPooledBullet()
        {
            foreach (GameObject bullet in bulletPool)
            {
                if (!bullet.activeInHierarchy)
                {
                    return bullet;
                }
            }
            return null;
        }

        #endregion

        #region GettersSetters



        #endregion
    }
}
