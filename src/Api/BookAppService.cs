using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

public class BookAppService : ApplicationService
{
    private readonly IRepository<Book, Guid> repository;

    public BookAppService(IRepository<Book, Guid> repository)
    {
        this.repository = repository;
    }

    public async Task<Book> CreateAsync(string name){
        var book = new Book(name);
        var newBook = await repository.InsertAsync(book);
        return newBook;
    }

    public async Task<Book> GetAsync(Guid id){
        return await repository.GetAsync(id);
    }

    public async Task<Book> UpdateAsync(Guid id, string name){
        var book = await repository.GetAsync(id);
        book.Name = name;
        return await repository.UpdateAsync(book);
    }

    public async Task DeleteAsync(Guid id){
        await repository.DeleteAsync(id);
    }

    public async Task<List<Book>> GetListAsync(){
        return await repository.GetListAsync();
    }
}