using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    [TestFixture()]
    public class GildedRoseTest
    {
		[TestCase]
		public void TestName()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual("foo", Items[0].Name);
		}

		//tests the lowering of the SellIn value
		[TestCase]
		public void TestSellIn()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 7, Quality = 5 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual(6, Items[0].SellIn);
		}

		//tests the lowering of the Quality value
		[TestCase]
		public void TestQuality()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 7, Quality = 5 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual(4, Items[0].Quality);
		}

		//tests if quality degrades twice as fast if the sell by date has passed
		[TestCase]
		public void TestQualityTwice()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 5 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual(3, Items[0].Quality);
		}

		//tests that the quality of an item is never negative
		[TestCase]
		public void TestQualityNegative()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.GreaterOrEqual(0, Items[0].Quality);
		}

		//tests if quality increases in "Aged Brie" the older it gets
		[TestCase]
		public void TestQualityAgedBrie()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 9 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual(10, Items[0].Quality);
		}

		//tests that the quality of an item is never more than 50
		[TestCase]
		public void TestQualityTooMuch()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 7, Quality = 50 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual(50, Items[0].Quality);
		}

		//tests that the quality of "Sulfuras, Hand of Ragnaros" does not decrease
		[TestCase]
		public void TestQualitySulfuras()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 7, Quality = 40 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual(40, Items[0].Quality);
		}

		//tests that the SellIn value of "Sulfuras, Hand of Ragnaros" does not decrease
		[TestCase]
		public void TestSellInSulfuras()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 40 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual(10, Items[0].SellIn);
		}

		//tests quality of backstage passes if more than 10 days to go
		[TestCase]
		public void TestBackstageFirst()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 40 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual(41, Items[0].Quality);
		}

		//tests quality of backstage passes if less than 10 days to go
		[TestCase]
		public void TestBackstageSecond()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 40 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual(42, Items[0].Quality);
		}

		//tests quality of backstage passes if less than 5 days to go
		[TestCase]
		public void TestBackstageThird()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 40 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual(43, Items[0].Quality);
		}

		//tests quality of backstage passes if the concert has passed
		[TestCase]
		public void TestBackstageFourth()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 40 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual(0, Items[0].Quality);
		}
	}
}
