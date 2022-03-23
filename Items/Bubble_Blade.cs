using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Elemental_Swords.Items
{
	public class Bubble_Blade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bubble Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The basic aqua sword.");
		}

		public override void SetDefaults() 
		{
			item.damage = 25;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = ProjectileID.Bubble;
			item.shootSpeed = 5f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBar, 12);
			recipe.AddIngredient(ItemID.Coral, 5);
			recipe.AddIngredient(ItemID.Sapphire, 7);
			recipe.AddIngredient(ItemID.WaterBucket, 1);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.PlatinumBar, 12);
			recipe2.AddIngredient(ItemID.Coral, 5);
			recipe2.AddIngredient(ItemID.Sapphire, 7);
			recipe2.AddIngredient(ItemID.WaterBucket, 1);
			recipe2.AddTile(16);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
			
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}


	}
}