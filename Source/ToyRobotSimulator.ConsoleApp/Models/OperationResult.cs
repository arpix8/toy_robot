namespace ToyRobotSimulator
{
    public class OperationResult
    {
        public bool HasErrors { get; set; }
        public string Message { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }
    }
}
