using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Elemental_Swords.Items
{
	public class Lightning_Blade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lightning Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The basic lightning sword.");
		}

		public override void SetDefaults() 
		{
			item.damage = 20;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Topaz, 7);
			recipe.AddIngredient(ItemID.Cloud, 25);
			recipe.AddIngredient(ItemID.SunplateBlock, 25);
			recipe.AddTile(TileID.SkyMill);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
											
public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
								
		int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 226, 0f, 0f, 100, default(Color), 2f);
					Main.dust[dust].noGravity = true;
				
			}
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			
				target.AddBuff(mod.BuffType("Holy_Flames"), 60);
			
		}

	}
}