using HomeWorkk.Models;

namespace HomeWorkk.Endpoints
{
    public static class UserEndPoints
    {
        private static readonly List<User> Users =
        [
            new User(1, "John", "john@example.com"),
            new User(2, "Jane", "jane@example.com")
        ];

        public static void MapUserEndpoints(this WebApplication app)
        {
            var users = app.MapGroup("/users");

            users.MapGet("/", GetUsers);

            users.MapGet("/{id}", GetUser);

            users.MapPost("/", CreateUser);

            users.MapDelete("/{id}", DeleteUser);
        }

        private static IResult GetUsers()
        {
            return Results.Ok(Users);
        }

        private static IResult GetUser(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);

            if (user is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(user);
        }

        private static IResult CreateUser(CreateUserRequest request)
        {
            var newId = Users.Max(x => x.Id) + 1;

            var user = new User(
                newId,
                request.Name,
                request.Email
            );

            Users.Add(user);

            return Results.Created($"/users/{user.Id}", user);
        }

        private static IResult DeleteUser(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);

            if (user is null)
            {
                return Results.NotFound();
            }

            Users.Remove(user);

            return Results.NoContent();
        }
    }
}
