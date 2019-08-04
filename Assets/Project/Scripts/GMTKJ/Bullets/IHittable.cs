namespace GMTKJ.Bullets
{
    public interface IHittable
    {
        void OnHitBy(Bullet bullet);
    }
}