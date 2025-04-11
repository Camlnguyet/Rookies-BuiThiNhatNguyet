using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IAddressRepository
{
    //  Lấy entity theo ID
    Task<Address?> GetByIdAsync(int id);
    // Lấy tất cả entity
    Task<IEnumerable<Address>> GetAddresses();
    // Thêm entity mới
    Task AddAsync(Address address);
    // Cập nhập entity
    void Update(Address address);
    // Xóa entity
    void Delete(Address address);

}