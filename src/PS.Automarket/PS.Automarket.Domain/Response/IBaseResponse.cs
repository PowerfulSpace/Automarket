using PS.Automarket.Domain.Enums;

namespace PS.Automarket.Domain.Response
{
    public interface IBaseResponse<T>
    {
        public StatusCode StatusCode { get;}
        public T Data { get;}
    }

}
