


using System.Data;

namespace LexingtonPreschoolAcademy_API.DTO;


public class ListResponse<T>
{
    public T[] Dataset { get; set; } = Array.Empty<T>();
    public int Total { get; set; } = 0;
}