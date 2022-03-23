using Microsoft.Xna.Framework;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Elemental_Swords.Items
{
	public class Thunder_Blade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Thunder Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("An advanced lightning sword, has the ability to shoot short ranged sparks.");
		}

		public override void SetDefaults() 
		{
			item.damage = 60;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Spark");
			item.shootSpeed = 5f;

		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Lightning_Blade"), 1);
			recipe.AddIngredient(ItemID.Topaz, 7);
			recipe.AddIngredient(ItemID.HallowedBar, 12);

			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
											
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
								
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 226, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity.X += player.direction * 2f;
				Main.dust[dust].velocity.Y += 0.2f;
			}
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			
			
			// Add random Rotation
			Vector2 speed = new Vector2(speedX, speedY);
			speed = speed.RotatedByRandom(MathHelper.ToRadians(30));
			// Change the damage since it is based off the weapons damage and is too high
			damage = (int)(damage * .9f);
			speedX = speed.X;
			speedY = speed.Y;
			return true;
		}

	}
}