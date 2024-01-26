public class Person {
	public Guid Id { get; set; }
	public string Name { get; set; } = "Bob";
	public List<Pet> Pets { get; set; } = [];
}

public class Pet : Person { }