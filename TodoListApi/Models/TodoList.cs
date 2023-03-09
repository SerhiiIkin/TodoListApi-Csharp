namespace TodoListApi.Models {
    public class TodoList {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
