namespace Flubbery.Client.Models;

public class Album(string title, string artist) {
	public string Title { get; set; } = title;
	public string Artist { get; set; } = artist;
}