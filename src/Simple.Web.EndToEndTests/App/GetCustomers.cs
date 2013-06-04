namespace Simple.Web.EndToEndTests.App
{
    using System.Collections.Generic;
    using Behaviors;

    [UriTemplate("/spaceships")]
    public class GetSpaceships : IGet, IOutput<IEnumerable<Spaceship>>
    {
        public Status Get()
        {
            return 200;
        }

        public IEnumerable<Spaceship> Output
        {
            get
            {
                yield return new Spaceship {Name = "Heart of Gold"};
                yield return new Spaceship {Name = "Bistromath"};
            }
        }
    }

    [UriTemplate("/spaceships")]
    public class AddSpaceship : IPost<Spaceship>
    {
        public Status Post(Spaceship input)
        {
            return 201;
        }
    }

    public class Spaceship
    {
        public string Name { get; set; }
    }
}