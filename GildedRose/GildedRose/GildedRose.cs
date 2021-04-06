using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
	class GildedRose
	{
		IList<Item> Items;
		public GildedRose(IList<Item> Items)
		{
			this.Items = Items;
		}
/*
		public void UpdateQuality()
		{
			for (var i = 0; i < Items.Count; i++)
			{
				if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
				{
					if (Items[i].Quality > 0)
					{
						if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
						{
							Items[i].Quality = Items[i].Quality - 1;
						}
					}
				}
				else
				{
					if (Items[i].Quality < 50)
					{
						Items[i].Quality = Items[i].Quality + 1;

						if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
						{
							if (Items[i].SellIn < 11)
							{
								if (Items[i].Quality < 50)
								{
									Items[i].Quality = Items[i].Quality + 1;
								}
							}

							if (Items[i].SellIn < 6)
							{
								if (Items[i].Quality < 50)
								{
									Items[i].Quality = Items[i].Quality + 1;
								}
							}
						}
					}
				}

				if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
				{
					Items[i].SellIn = Items[i].SellIn - 1;
				}

				if (Items[i].SellIn < 0)
				{
					if (Items[i].Name != "Aged Brie")
					{
						if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
						{
							if (Items[i].Quality > 0)
							{
								if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
								{
									Items[i].Quality = Items[i].Quality - 1;
								}
							}
						}
						else
						{
							Items[i].Quality = Items[i].Quality - Items[i].Quality;
						}
					}
					else
					{
						if (Items[i].Quality < 50)
						{
							Items[i].Quality = Items[i].Quality + 1;
						}
					}
				}
			}
		}
*/
		public void UpdateQuality()
        {
			for(var i = 0; i < Items.Count; i++)
            {
				if (Items[i].Quality < 50)
                {
					if(Items[i].Name == "Aged Brie")
                    {
						Items[i].Quality += 1;
					}
					else if(Items[i].Name == "Conjured Mana Cake")
                    {
						Items[i].Quality -= 2;

					}
					else if(Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        HandleBackstage(i);
                    }
                    else
                    {
						if(Items[i].SellIn <= 0)
                        {
							Items[i].Quality -= 2;
							if(Items[i].Quality < 0)
                            {
								Items[i].Quality = 0;
                            }
                        }
						else
                        {
							Items[i].Quality--;
						}
                    }

					if (Items[i].Quality > 50)
					{
						Items[i].Quality = 50;
					}
					Items[i].SellIn--;
				}
            }
        }

        private void HandleBackstage(int i)
        {
            if (Items[i].SellIn > 10)
            {
                Items[i].Quality += 1;
            }
            else if (Items[i].SellIn > 5)
            {
                Items[i].Quality += 2;
            }
            else if (Items[i].SellIn > 0)
            {
                Items[i].Quality += 3;
            }
            else
            {
                Items[i].Quality = 0;
            }
        }
    }

	public class Item
	{
		public string Name { get; set; }

		public int SellIn { get; set; }

		public int Quality { get; set; }
	}
}
