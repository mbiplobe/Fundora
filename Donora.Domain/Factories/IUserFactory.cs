// using Donora.Domain.Consts;

// public interface IUserFactory
// {
//     UserEntity Create(string firstName, string middleName, string lastName, string email, string mobile, string password);
// }

// public abstract class UserFactoryBase : IUserFactory
// {

//     public UserEntity Create(string firstName,string middleName, string lastName, string email, string mobile, string password)
//     {
//         var id = EntityID.NewId();
//         var name = new FullName(firstName, middleName, lastName);
//         var emailVo = new Email(email);
//         var mobileVo = new Phone(mobile);
//         var passwordVo = new Password(password);

//         var user = CreateEntity(id, name, emailVo, mobileVo,passwordVo);

//         return user;
//     }

//     protected abstract UserEntity CreateEntity(EntityID id, FullName name, Email email, Phone mobile, Password password);
// }