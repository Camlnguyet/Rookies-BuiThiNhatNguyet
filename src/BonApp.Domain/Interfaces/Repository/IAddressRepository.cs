using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IAddressRepository
{
    IQueryable<Address> Addresses { get; }
    IQueryable<User> Users { get; }
    // Thêm entity mới
    void Add(Address address);
    // Cập nhập entity
    void Update(Address address);
    // Xóa entity
    void Delete(Address address);
}