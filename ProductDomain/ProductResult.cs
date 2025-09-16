using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDomain
{
    public class ProductResult
    {
        public bool IsSuccess { get; }
        public string Error { get; }

        protected ProductResult(bool isSuccess, string error)
        {
            // Validaciones internas (para no crear resultados inválidos)
            if (isSuccess && !string.IsNullOrEmpty(error))
                throw new InvalidOperationException("Un resultado exitoso no puede tener error.");

            if (!isSuccess && string.IsNullOrEmpty(error))
                throw new InvalidOperationException("Un resultado fallido debe tener mensaje de error.");

            IsSuccess = isSuccess;
            Error = error;
        }

        // Métodos de fábrica (para no usar new directamente)
        public static ProductResult Success() => new ProductResult(true, string.Empty);
        public static ProductResult Fail(string message) => new ProductResult(false, message);

        // Métodos genéricos
        public static ProductResult<T> Success<T>(T value) => new ProductResult<T>(value, true, string.Empty);
        public static ProductResult<T> Fail<T>(string message) => new ProductResult<T>(default, false, message);
    }

    public class ProductResult<T> : ProductResult
    {
        private readonly T? _value;

        internal ProductResult(T? value, bool isSuccess, string error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        public T Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("No hay valor porque el resultado fue fallo.");
    }
}
