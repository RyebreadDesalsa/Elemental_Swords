using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Elemental_Swords.Items
{
	public class Hydro_Blade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Hydro Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("an upgraded aqua sword capable of shooting weak typhoons.");
		}

		public override void SetDefaults() 
		{
			item.damage = 55;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileID.Typhoon;
			item.shootSpeed = 5f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Bubble_Blade"), 1);
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddIngredient(ItemID.Sapphire, 7);
			recipe.AddIngredient(549, 7);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			
			
			Vector2 speed = new Vector2(speedX, speedY);
			
			// Change the damage since it is based off the weapons damage and is too high
			damage = (int)(damage * .35f);
			speedX = speed.X;
			speedY = speed.Y;
			return true;
		}


	}
}