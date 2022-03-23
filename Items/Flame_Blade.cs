using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Elemental_Swords.Items
{
	public class Flame_Blade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Flame Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The basic Fire sword.");
		}

		public override void SetDefaults() 
		{
			item.damage = 32;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = ProjectileID.BallofFire;
			item.shootSpeed = 5f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			//recipe.AddIngredient(ItemID.Coral, 5);
			//recipe.AddIngredient(ItemID.Sapphire, 7);
			//recipe.AddIngredient(ItemID.WaterBucket, 1);
			//recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();

			
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{


			Vector2 speed = new Vector2(speedX, speedY);

			// Change the damage since it is based off the weapons damage and is too high
			damage = (int)(damage * .75f);
			speedX = speed.X;
			speedY = speed.Y;
			return true;
		}


	}
}