namespace WebApplication4.Models
{
	public class FlowerModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public int Amount { get; set; }
						public FlowerModel(int id, string name, int price, int amount)
		{
			Id = id;
			Name = name;
			Price = price;
			Amount = amount;
		}
				public FlowerModel()
		{
			Id = 0;
			Name = "Wow";
			Price = 0;
			Amount = 0;
		}
	}
	
}

