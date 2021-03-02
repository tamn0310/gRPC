using Dapper.FluentMap.Mapping;

namespace Grpc.Services.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public long CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public long UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class UserMap : EntityMap<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMap"/> class.
        /// </summary>
        public UserMap()
        {
            Map(c => c.Id).ToColumn("id");
            Map(c => c.FirstName).ToColumn("first_name");
            Map(c => c.LastName).ToColumn("last_name");
            Map(c => c.Phone).ToColumn("phone");
            Map(c => c.Email).ToColumn("email");
            Map(c => c.CreatedBy).ToColumn("created_by");
            Map(c => c.CreatedAt).ToColumn("created_at");
            Map(c => c.UpdatedAt).ToColumn("updated_at");
            Map(c => c.UpdatedBy).ToColumn("updated_by");
            Map(c => c.IsDeleted).ToColumn("is_deleted");
        }
    }
}