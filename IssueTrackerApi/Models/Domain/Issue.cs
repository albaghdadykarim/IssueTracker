using IssueTrackerApi.Enums;
namespace IssueTrackerApi.Models.Domain
{
    public class Issue
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; } = Status.New;
        public PriorityEnum Priority { get; set; }
        public Project Project {  get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
    }
}
