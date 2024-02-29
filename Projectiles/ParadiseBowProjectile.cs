using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ParadiseMod.Projectiles;

public class ParadiseBowProjectile : ModProjectile
{
    public override void SetDefaults()
    {
        Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
        Projectile.CloneDefaults(ProjectileID.BeeArrow);
        Projectile.CloneDefaults(ProjectileID.BloodArrow);
        Projectile.CloneDefaults(ProjectileID.BoneArrow);
        Projectile.CloneDefaults(ProjectileID.ChlorophyteArrow);
        Projectile.CloneDefaults(ProjectileID.CursedArrow);
        Projectile.CloneDefaults(ProjectileID.FireArrow);
        Projectile.CloneDefaults(ProjectileID.FlamingArrow);
        Projectile.CloneDefaults(ProjectileID.FrostArrow);
        Projectile.CloneDefaults(ProjectileID.FrostburnArrow);
        Projectile.CloneDefaults(ProjectileID.HellfireArrow);
        Projectile.CloneDefaults(ProjectileID.HolyArrow);
        Projectile.CloneDefaults(ProjectileID.IchorArrow);
        Projectile.CloneDefaults(ProjectileID.JestersArrow);
        Projectile.CloneDefaults(ProjectileID.ShimmerArrow);
        Projectile.CloneDefaults(ProjectileID.UnholyArrow);
        Projectile.CloneDefaults(ProjectileID.VenomArrow);
    }

    public override void AI()
    {
        Projectile.tileCollide = false;
        Lighting.AddLight(Projectile.position, 1f, 1f, 1f);
        Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.ToRadians(90f);
        int DustID27 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 1f),
            Projectile.width + 1, Projectile.height + 1,
            DustID.BlueFlare, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f,
            100, Color.Ivory, 1f);
        Main.dust[DustID27].noGravity = true;

    }
}