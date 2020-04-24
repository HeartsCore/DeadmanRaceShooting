namespace DeadmanRace
{
    public class InitMyWeapon : IInitializeController
    {
        private readonly GameContext _context;
       
        public InitMyWeapon(GameContext context, Services services)
        {
            _context = context;
        }

        public void Initialize()
        {
            var weaponFactory = new WeaponFactory();
            var poolBulletAmmunition = new PoolObjectAmmunition(AmmunitionType.Bullet);
            var gun = weaponFactory.CreateGun(poolBulletAmmunition);//
            gun.IsVisible = false;
            _context.Weapons[0] = gun;
            var bulletDictionary = poolBulletAmmunition.PoolObjectsAmmunition ;
            _context.BulletContext = bulletDictionary;
            var bulletTiming = poolBulletAmmunition.TimeRemainings;
            _context.BulletTimeRemainings = bulletTiming;
            var bulletAmmunition = poolBulletAmmunition.Ammunitions;
            _context.BulletAmmunitions = bulletAmmunition;

            var poolRpgBulletAmmunition = new PoolObjectAmmunition(AmmunitionType.Rpg);
            var rpgGun = weaponFactory.CreateRpgGun(poolRpgBulletAmmunition);
            rpgGun.IsVisible = false;
            _context.Weapons[1] = rpgGun;
            var bulletRpgDictionary = poolRpgBulletAmmunition.PoolObjectsAmmunition;
            _context.RpgBulletContext = bulletRpgDictionary;
            var bulletRpgTiming = poolRpgBulletAmmunition.TimeRemainings;
            _context.RpgBulletTimeRemainings = bulletRpgTiming;
            var bulletRpgAmmunition = poolRpgBulletAmmunition.Ammunitions;
            _context.RpgBulletAmmunitions = bulletRpgAmmunition;

            //bullets List
            //var bullet = Resources.Load<AmmunitionBehaviour>("Prefabs/Bullet");
            //var gameObject = Object.Instantiate(bullet).gameObject;
            //var bulletList = System.Linq.Enumerable.Repeat(new Bullet(gameObject, poolBulletAmmunition), 50).ToList();

            _context.WeaponController = new WeaponController();
            
        }
        
    }
}
