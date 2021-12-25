using AutoMapper;
using LibraryManagementSystem.Application.Dtos.Authors;
using LibraryManagementSystem.Application.Dtos.Books;
using LibraryManagementSystem.Application.Dtos.Borrows;
using LibraryManagementSystem.Application.Dtos.Customers;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Shared.Models.Accounts;
using LibraryManagementSystem.Shared.Models.Authors;
using LibraryManagementSystem.Shared.Models.Books;
using LibraryManagementSystem.Shared.Models.Borrows;
using LibraryManagementSystem.Shared.Models.Customers;

namespace LibraryManagementSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, GetBookDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();

            CreateMap<Author, GetAuthorDto>().ReverseMap();
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();

            CreateMap<Borrow, GetBorrowDto>().ReverseMap();
            CreateMap<Borrow, CreateBorrowDto>().ReverseMap();
            CreateMap<Borrow, UpdateBorrowDto>().ReverseMap();

            CreateMap<Customer, GetCustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();

            CreateMap<GetBookDto, GetBookModel>().ReverseMap();
            CreateMap<CreateBookDto, CreateBookModel>().ReverseMap();
            CreateMap<UpdateBookDto, UpdateBookModel>().ReverseMap();
            CreateMap<GetBookDto, UpdateBookModel>().ReverseMap();

            CreateMap<GetAuthorDto, GetAuthorModel>().ReverseMap();
            CreateMap<CreateAuthorDto, CreateAuthorModel>().ReverseMap();
            CreateMap<UpdateAuthorDto, UpdateAuthorModel>().ReverseMap();
            CreateMap<GetAuthorDto, UpdateAuthorModel>().ReverseMap();

            CreateMap<GetBorrowDto, GetBorrowModel>().ReverseMap();
            CreateMap<CreateBorrowDto, CreateBorrowModel>().ReverseMap();
            CreateMap<UpdateBorrowDto, UpdateBorrowModel>().ReverseMap();
            CreateMap<GetBorrowDto, UpdateBorrowModel>().ReverseMap();

            CreateMap<GetCustomerDto, GetCustomerModel>().ReverseMap();
            CreateMap<CreateCustomerDto, CreateCustomerModel>().ReverseMap();
            CreateMap<UpdateCustomerDto, UpdateCustomerModel>().ReverseMap();
            CreateMap<GetCustomerDto, UpdateCustomerModel>().ReverseMap();
        }
    }
}
