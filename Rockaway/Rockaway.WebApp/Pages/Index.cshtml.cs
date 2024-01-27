using Rockaway.WebApp.Data;
using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Pages;

public class IndexModel(RockawayDbContext db) : PageModel {

	public List<Show> Shows {
		get;
		set;
	}

	public void OnGet() {
		Shows = db.Shows
			.Include(s => s.Venue)
			.Include(s => s.TicketTypes)
			.Include(s => s.HeadlineArtist)
			.ToList();
	}
}