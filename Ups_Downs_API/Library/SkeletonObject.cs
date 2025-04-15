using System.Diagnostics.CodeAnalysis;

namespace Library
{
    public class SkeletonObject
    {
        public required string Name { get; set; }
        public required string Password { get; set; }

        public SkeletonObject()
        {
            Name = "test";
            Password = "test";
        }
        [SetsRequiredMembers]
        public SkeletonObject(string name, string password) =>
            (Name, Password) = (name, password);
    }
}
