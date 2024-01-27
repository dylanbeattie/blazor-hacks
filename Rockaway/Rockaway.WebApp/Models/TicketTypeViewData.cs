using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Models;

public class TicketTypeViewData {

	public static TicketTypeViewData FromTicketType(TicketType tt) => new() {
		Name = tt.Name,
		Price = tt.Price,
		Id = tt.Id
	};

	public string Name { get; private set; };
	public decimal Price { get; private set; };
	public Guid Id { get; private set; };
}
