using System.Collections.Generic;
using UnityEngine;


namespace DeadmanRace
{
    public sealed class PhysicsService : Service
    {
        #region Fields

        private const int COLLIDEDOBJECTSIZE = 20;

        private readonly Collider2D[] _collidedObjects;
        private readonly Collider[] _collidedObjects3D;
        private readonly RaycastHit2D[] _castBuffer;
        private readonly List<IOnTrigger> _triggeredObjects;
        private readonly List<GameObject> _gameObjects;

        #endregion


        #region ClassLifeCycles

        public PhysicsService(Contexts contexts) : base(contexts)
        {
            _collidedObjects = new Collider2D[COLLIDEDOBJECTSIZE];
            _collidedObjects3D = new Collider[COLLIDEDOBJECTSIZE];
            _castBuffer = new RaycastHit2D[64];
            _triggeredObjects = new List<IOnTrigger>();
            _gameObjects = new List<GameObject>();
        }

        #endregion

        
        #region Methods

        public bool CheckGround(Vector2 position, float distanceRay, out Vector2 hitPoint, int layerMask = LayerManager.DEFAULTLAYER)
        {
            hitPoint = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, distanceRay, layerMask);
            if (hit.collider == null)
            {
                return false;
            }

            hitPoint = hit.point;
            return true;
        }
        public List<IOnTrigger> GetObjectsInRadius3D(Vector2 position, float radius, int layerMask = LayerManager.DEFAULTLAYER)
        {
            _triggeredObjects.Clear();
            IOnTrigger trigger;

            Collider[] collidersCount = Physics.OverlapSphere(position, radius, layerMask);//_collidedObjects3D,
            int i = 0;
            while (i < collidersCount.Length)
            {
                collidersCount[i].SendMessage("Объект найден");
                trigger = _collidedObjects3D[i].GetComponent<IOnTrigger>();

                if (trigger != null && !_triggeredObjects.Contains(trigger))
                {
                    _triggeredObjects.Add(trigger);
                }
                i++;
            }


            return _triggeredObjects;
        }
        //public void ShotingRayCast<T>(HashSet<T> myObject, Transform transform, int maxDistance) where T : Object //HashSet<UnityEngine.Object>
        //{

        //    foreach (var obj in myObject)
        //    {

        //        if (Physics.Raycast(obj.transform.position, obj.Transform.TransformDirection(Vector3.forward),
        //            out var hit, obj.maxDistance))
        //        {
        //            AmmunitionApplyDamage(obj, hit.collider);
        //        }
        //    }
        //}
        //public static bool RaycastMousePos(Collider collider, out RaycastHit hit)
        //{
        //    if (collider == null) { throw new Exception("[UnityHelpers] Collider null"); }
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    return collider.Raycast(ray, out hit, Mathf.Infinity);
        //}

        //public static RaycastHit[] RaycastMousePosAll(int layerMask)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    return Physics.RaycastAll(ray, Mathf.Infinity, layerMask);
        //}

        //public static bool RaycastScreenPointToRay(Vector2 screenPoint, out RaycastHit hit, Camera camera = null)
        //{
        //    camera = camera == null ? Camera.main : camera;
        //    Ray ray = RectTransformUtility.ScreenPointToRay(camera, screenPoint);
        //    return Physics.Raycast(ray, out hit, Mathf.Infinity);
        //}


        public List<IOnTrigger> GetObjectsInRadius(Vector2 position, float radius, int layerMask = LayerManager.DEFAULTLAYER)
        {
            _triggeredObjects.Clear();
            IOnTrigger trigger;

            int collidersCount = Physics2D.OverlapCircleNonAlloc(position, radius, _collidedObjects, layerMask);
            
            for (int i = 0; i < collidersCount; i++)
            {
                trigger = _collidedObjects[i].GetComponent<IOnTrigger>();

                if (trigger != null && !_triggeredObjects.Contains(trigger))
                {
                    _triggeredObjects.Add(trigger);
                }
            }

            return _triggeredObjects;
        }
        
        public HashSet<IOnTrigger> SphereCastObject(Vector2 center, float radius, HashSet<IOnTrigger> outBuffer,
            int layerMask = LayerManager.DEFAULTLAYER)
        {
            outBuffer.Clear();

            int hitCount = Physics2D.CircleCastNonAlloc(center,
                radius,
                Vector2.zero,
                _castBuffer,
                0.0f,
                layerMask);

            for (int i = 0; i < hitCount; i++)
            {
                IOnTrigger carTriggerProvider = _castBuffer[i].collider.GetComponent<IOnTrigger>();
                if (carTriggerProvider != null)
                {
                    outBuffer.Add(carTriggerProvider);
                }
            }


            return outBuffer;
        }
        
        public IOnTrigger GetNearestObject(Vector3 targetPosition, HashSet<IOnTrigger> objectBuffer)
        {
            float nearestDistance = Mathf.Infinity;
            IOnTrigger result = null;

            foreach (IOnTrigger trigger in objectBuffer)
            {
                float objectDistance = (targetPosition - trigger.GameObject.transform.position).sqrMagnitude;
                if (objectDistance >= nearestDistance)
                {
                    continue;
                }

                nearestDistance = objectDistance;
                result = trigger;
            }

            return result;
        }



        //private void AmmunitionApplyDamage(Ammunition ammunition, Collider collision)
        //{
        //    // дописать доп урон
        //    var tempObj = collision.gameObject.GetComponent<ISetDamage>();

        //    if (tempObj != null)
        //    {
        //        tempObj.SetDamage(new InfoCollision(ammunition.CurDamage));
        //    }

        //    ammunition.DestroyAmmunition();
        //}
        

        //public HashSet<IOnTrigger> SphereCastObject3D(Vector2 center, float radius, HashSet<IOnTrigger> outBuffer,
        //    int layerMask = LayerManager.DEFAULTLAYER)
        //{
        //    outBuffer.Clear();

        //    int hitCount = Physics.OverlapSphere(center,
        //        radius,
        //        Vector2.zero,
        //        _castBuffer,
        //        0.0f,
        //        layerMask);

        //    for (int i = 0; i < hitCount; i++)
        //    {
        //        IOnTrigger carTriggerProvider = _castBuffer[i].collider.GetComponent<IOnTrigger>();
        //        if (carTriggerProvider != null)
        //        {
        //            outBuffer.Add(carTriggerProvider);
        //        }
        //    }


        //    return outBuffer;
        //}

        #endregion
    }
}
