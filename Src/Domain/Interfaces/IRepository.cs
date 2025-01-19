namespace backend.Src.Domain.Repositories.Intefaces{

    public interface IRepository<T> where T : class
    {
        public Task<List<T>> BuscarTodos();
        Task<T> BuscarPorId(int id);
        Task<bool> Criar(T entity);
        Task<T> Atualizar(T entity, int id);
        Task<bool> Deletar(int id);
    }


}