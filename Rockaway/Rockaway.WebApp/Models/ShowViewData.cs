using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Models;

public class ShowViewData(Show? show) { // Show show) {
	public ShowViewData() : this(null) { }

	//public ShowViewData() : this(null) { }
	//public ShowViewData(Show show) {
		// public static ShowViewData FromShow(Show show) => new() {
//		VenueName = show.Venue.Name;
//		ShowDate = show.Date;
//		VenueAddress = show.Venue.FullAddress;
		// 	// HeadlineArtistName = show.HeadlineArtist.Name,
		// 	// CountryCode = show.Venue.CountryCode,
		// 	// CultureName = show.Venue.CultureName,
		// 	// SupportActs = show.SupportSlots.OrderBy(s => s.SlotNumber).Select(s => s.Artist.Name).ToList(),
		// 	// TicketTypes = show.TicketTypes.Select(TicketTypeViewData.FromTicketType).ToList(),
		// 	// RouteData = show.RouteData
//	}

	public string VenueName { get; set; } = show?.Venue?.Name;

	public DateTime ShowDate { get; set; } = show?.Date.ToDateTimeUnspecified() ?? DateTime.MinValue;

	public string VenueAddress { get; set; } = show?.Venue?.FullAddress;

	// public string HeadlineArtistName { get; private set; }
	//
	// public string CountryCode { get; private set; }
	//
	// public string CultureName { get; private set; }
	//
	// public List<string> SupportActs { get; private set; }
	//
	// public List<TicketTypeViewData> TicketTypes { get; private set; }
	//
	// public Dictionary<string, string> RouteData { get; private set; }
}
