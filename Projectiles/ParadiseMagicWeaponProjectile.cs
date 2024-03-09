using Microsoft.Xna.Framework;
using ParadiseMod.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ParadiseMod.Projectiles;

public class ParadiseMagicWeaponProjectile : ModProjectile
{
    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 4;
        ProjectileID.Sets.MinionSacrificable[Projectile.type] =
            true; // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
        ProjectileID.Sets.CultistIsResistantTo[Projectile.type] =
            true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
    }

    public override void SetDefaults()
    {
        Projectile.width = 18;
        Projectile.height = 28;
        Projectile.tileCollide = false; // Makes the minion go through tiles freely
        Projectile.scale = 2f;
        
        Projectile.friendly = true;
        Projectile.ignoreWater = true;

        Projectile.DamageType = DamageClass.Magic;

        Projectile.aiStyle = -1;

        Projectile.penetrate = -1;
    }

    public override void AI()
    {
        Projectile.ai[0]++;
        if (Projectile.ai[0] < 60)
        {
            Projectile.velocity *= 1.01f;
        }
        else
        {
            Projectile.velocity *= 1.05f;
            if (Projectile.ai[0] >= 180)
            {
                Projectile.Kill();
            }
        }

        if (Main.rand.NextBool(2))
        {
            int numToSpawn = Main.rand.Next(3);
            for (int i = 0; i < numToSpawn; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<MagicWeaponDust>(),
                    Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 50, default(Color), 1f);
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.BlueFlare,
                    Projectile.velocity.X * 2f, Projectile.velocity.Y * 2f, Alpha: 128, Scale: 1.2f);
            }
        }

        Visuals();
    }

    private void Visuals()
    {
        // So it will lean slightly towards the direction it's moving
        Projectile.rotation = Projectile.velocity.X * 0.05f;

        // This is a simple "loop through all frames from top to bottom" animation
        int frameSpeed = 5;

        Projectile.frameCounter++;

        if (Projectile.frameCounter >= frameSpeed)
        {
            Projectile.frameCounter = 0;
            Projectile.frame++;

            if (Projectile.frame >= Main.projFrames[Projectile.type])
            {
                Projectile.frame = 0;
            }
        }

        // Some visuals here
        Lighting.AddLight(Projectile.Center, Color.White.ToVector3() * 0.78f);
    }
}