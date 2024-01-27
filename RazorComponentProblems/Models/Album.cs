using NodaTime;

public class Album(string title, string artist, LocalDate releaseDate) {
	public string Title { get; set; } = title;
	public string Artist { get; set; } = artist;
	public LocalDate ReleaseDate { get; set; } = releaseDate;
}