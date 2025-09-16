namespace CustomerDomain
{
    /// <summary>
    /// Encapsulates the result of an operation on a customer entity.  Provides
    /// a uniform pattern for returning either a value or an error message.
    /// </summary>
    public class CustomerResult
    {
        /// <summary>
        /// Indicates whether the operation succeeded.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Contains an error message if the operation failed.
        /// </summary>
        public string? Error { get; }

        protected CustomerResult(bool isSuccess, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        /// <summary>
        /// Creates a successful result.
        /// </summary>
        public static CustomerResult<T> Success<T>(T value) => new CustomerResult<T>(value, true, null);

        /// <summary>
        /// Creates a failed result with the specified error message.
        /// </summary>
        public static CustomerResult<T> Fail<T>(string error) => new CustomerResult<T>(default!, false, error);
    }

    /// <summary>
    /// Generic variant of <see cref="CustomerResult"/> that holds a typed value.
    /// </summary>
    public class CustomerResult<T> : CustomerResult
    {
        /// <summary>
        /// Gets the value associated with a successful result.
        /// </summary>
        public T Value { get; }

        internal CustomerResult(T value, bool isSuccess, string? error) : base(isSuccess, error)
        {
            Value = value;
        }
    }
}